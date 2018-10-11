﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Model;
using SelectedProduct = Uarung.Data.Entity.SelectedProduct;

namespace Uarung.API.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly IDacDiscount _dacDiscount;
        private readonly IDacProduct _dacProduct;
        private readonly IDacSelectedProduct _dacSelectedProduct;
        private readonly IDacTransaction _dacTransaction;
        private readonly RedisWrapper _redisWrapper;

        public TransactionController(IDacTransaction dacTransaction, IDacSelectedProduct dacSelectedProduct,
            IDacProduct dacProduct, IDacDiscount discount, IDistributedCache distributedCache)
        {
            _dacTransaction = dacTransaction;
            _dacSelectedProduct = dacSelectedProduct;
            _dacProduct = dacProduct;
            _dacDiscount = discount;
            _redisWrapper = new RedisWrapper(distributedCache);
        }

        [HttpPost]
        public ActionResult<CollectionResponse<Transaction>> Create(Transaction request)
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                if (!request.SelectedProducts.Any())
                    throw new Exception("selected product cannot be empty");

                var transactionId = GenerateId();
                var userId = GetUserId(Request, _redisWrapper);

                var transaction = new Data.Entity.Transaction
                {
                    Id = transactionId,
                    UserId = userId,
                    PaymentType = ValidatePaymentType(request.PaymentType),
                    Notes = request.Notes,
                    TotalPrice = 0m,
                    PaymentStatus = GetPaymentStatus(request.PaymentStatus),
                    SelectedProducts = FillSelectedProducts(request.SelectedProducts, transactionId, out var totalPrice),
                    DiscountCode = FillDiscount(request.Discount.Code, totalPrice, out var discountValue)
                };

                transaction.TotalPrice = totalPrice;
                transaction.DiscountValue = discountValue;

                _dacTransaction.Insert(transaction);
                _dacTransaction.Commit();

                response.Collections = Get(transactionId).Value.Collections;
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status.SetError(e.Message);
            }

            return response;
        }

        [HttpPut]
        public ActionResult<BaseReponse> Update(Transaction request)
        {
            var response = new BaseReponse();

            try
            {
                var transaction = _dacTransaction.Single(request.Id);

                if (transaction == null)
                    throw new Exception("transaction does not exist");

                if (transaction.PaymentStatus.Equals(Constant.PaymentStatus.Paid))
                    throw new Exception("this transaction already paid");

                if (transaction.PaymentStatus != request.PaymentStatus)
                    transaction.PaymentStatus = GetPaymentStatus(request.PaymentStatus);

                if(transaction.PaymentType != request.PaymentType)
                    transaction.PaymentType = ValidatePaymentType(request.PaymentType);

                if (transaction.TotalPrice != request.TotalPrice && request.SelectedProducts.Any())
                {
                    _dacSelectedProduct.DeleteWhere(sp => sp.TransactionId.Equals(transaction.Id));

                    transaction.SelectedProducts = FillSelectedProducts(request.SelectedProducts, transaction.Id, out var totalPrice);
                    transaction.TotalPrice = totalPrice;
                }

                if (transaction.DiscountCode != request.Discount.Code && !string.IsNullOrEmpty(request.Discount.Code))
                {
                    transaction.DiscountCode = FillDiscount(request.Discount.Code, transaction.TotalPrice, out var discountValue);
                    transaction.DiscountValue = discountValue;
                }

                _dacTransaction.Update(transaction);
                _dacTransaction.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status.SetError(e.Message);
            }

            return response;
        }

        [HttpGet("{id=}")]
        public ActionResult<CollectionResponse<Transaction>> Get(string id)
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                var transactions = string.IsNullOrEmpty(id)
                    ? _dacTransaction.All()
                    : new[] {_dacTransaction.Single(id)};

                response.Collections = TranslateToModel(transactions);
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpGet("HoldOnly")]
        public ActionResult<CollectionResponse<Transaction>> GetHoldOnly()
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                var transactions = _dacTransaction
                    .Where(t => t.PaymentStatus.Equals(Constant.PaymentStatus.Hold));

                response.Collections = TranslateToModel(transactions);
                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

        private List<SelectedProduct> FillSelectedProducts(IEnumerable<Model.SelectedProduct> request,
            string transactionId, out decimal totalPrice)
        {
            var result = new List<SelectedProduct>();
            totalPrice = 0;

            foreach (var sp in request)
            {
                var product = _dacProduct.Single(sp.Product.Id);

                if (product == null)
                    continue;

                var subTotal = sp.Quantity * product.Price;
                var selectedProduct = new SelectedProduct
                {
                    Id = GenerateId(),
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    TransactionId = transactionId,
                    Notes = sp.Notes,
                    Quantity = sp.Quantity,
                    TotalPrice = subTotal
                };

                result.Add(selectedProduct);
                totalPrice += subTotal;
            }

            return result;
        }

        private string FillDiscount(string discountCode, decimal totalPrice, out decimal discountValue)
        {
            var discount = _dacDiscount.Single(discountCode);
            discountValue = discount?.Value ?? 0;

            if (discount == null) return null;
            
            if (discount.Type.Equals(Constant.DiscountType.Percentage))
                discountValue = totalPrice * (discountValue / 100);

            return discount.Id;
        }

        private static string GetPaymentStatus(string paymentStatus)
        {
            return paymentStatus.Equals(Constant.PaymentStatus.Paid, StringComparison.OrdinalIgnoreCase)
                ? Constant.PaymentStatus.Paid
                : Constant.PaymentStatus.Hold;
        }

        private static string ValidatePaymentType(string paymentType)
        {
            if (paymentType.Equals(string.Empty))
                return paymentType;

            var paymentTypes = new[]
            {
                Constant.PaymentType.Card,
                Constant.PaymentType.Cash,
                Constant.PaymentType.Other
            };

            if (!paymentTypes.Contains(paymentType))
                throw new Exception("Payment type not valid");

            return paymentType;
        }

        private List<Transaction> TranslateToModel(IEnumerable<Data.Entity.Transaction> transactions)
        {
            return transactions
                .Select(t => new Transaction
                {
                    Id = t.Id,
                    PaymentType = t.PaymentType,
                    PaymentStatus = t.PaymentStatus,
                    CreatedDate = t.CreatedDate,
                    TotalPrice = t.TotalPrice,
                    Notes = t.Notes,
                    Discount = new Discount
                    {
                        Code = t.DiscountCode ?? string.Empty,
                        Value = t.DiscountValue
                    },
                    SelectedProducts = _dacSelectedProduct
                        .Where(sp => sp.TransactionId.Equals(t.Id))
                        .Select(sp => new Model.SelectedProduct
                        {
                            TotalPrice = sp.TotalPrice,
                            Quantity = sp.Quantity,
                            Notes = sp.Notes,
                            Product = new Product
                            {
                                Id = sp.ProductId,
                                Name = sp.ProductName,
                                Price = sp.ProductPrice
                            }
                        })
                        .ToList()
                })
                .ToList();
        }
    }
}