using System;
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
        public ActionResult<BaseReponse> Create(Transaction request)
        {
            var response = new BaseReponse();

            try
            {
                var transactionId = GenerateId();
                var userId = GetUserId(Request, _redisWrapper);

                var transaction = new Data.Entity.Transaction
                {
                    Id = transactionId,
                    UserId = userId,
                    DiscountCode = request.Discount.Code,
                    PaymentStatus = request.PaymentStatus,
                    PaymentType = request.PaymentType
                };

                if (request.SelectedProducts.Any())
                {
                    var totalPrice = 0m;

                    foreach (var sp in request.SelectedProducts)
                    {
                        var subTotal = sp.Quantity * sp.Product.Price;
                        var selectedProduct = new SelectedProduct   
                        {
                            Id = GenerateId(),
                            ProductId = sp.Product.Id,
                            TransactionId = transactionId,
                            Notes = sp.Notes,
                            Quantity = sp.Quantity,
                            TotalPrice = subTotal
                        };

                        transaction.SelectedProducts.Add(selectedProduct);
                        totalPrice += subTotal;
                    }

                    transaction.TotalPrice = totalPrice;
                }

                _dacTransaction.Insert(transaction);
                _dacTransaction.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpPost("Paid")]
        public ActionResult<BaseReponse> Paid([FromBody] string id)
        {
            var response = new BaseReponse();

            try
            {
                var transaction = _dacTransaction.Single(id);

                if (transaction == null)
                    throw new Exception("transaction does not exist");

                if (transaction.PaymentStatus.Equals(Constant.TransactionStatus.Paid))
                    throw new Exception("this transaction already paid");

                transaction.PaymentStatus = Constant.TransactionStatus.Paid;

                _dacTransaction.Update(transaction);
                _dacTransaction.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status.SetError(e);
            }

            return response;
        }

        [HttpGet("{id=}")]
        public ActionResult<CollectionResponse<Transaction>> Get(string id)
        {
            var response = new CollectionResponse<Transaction>();

            try
            {
                var transactions = (string.IsNullOrEmpty(id)
                        ? _dacTransaction.All()
                        : new[] {_dacTransaction.Single(id)})
                    .ToList();

                foreach (var t in transactions)
                {
                    var transaction = new Transaction
                    {
                        Id = t.Id,
                        PaymentType = t.PaymentType,
                        PaymentStatus = t.PaymentStatus,
                        CreatedDate = t.CreatedDate,
                        TotalPrice = t.TotalPrice,
                        SelectedProducts = _dacSelectedProduct
                            .Where(sp => sp.TransactionId.Equals(t.Id))
                            .Select(sp =>
                            {
                                var product = _dacProduct.Single(sp.ProductId);

                                return new Model.SelectedProduct
                                {
                                    TotalPrice = sp.TotalPrice,
                                    Quantity = sp.Quantity,
                                    Notes = sp.Notes,
                                    Product = new Product
                                    {
                                        Id = product?.Id,
                                        Name = product?.Name,
                                        Price = product?.Price ?? 0
                                    }
                                };
                            })
                            .ToList()
                    };

                    var discount = _dacDiscount.Single(t.DiscountCode);

                    if (discount != null)
                        transaction.Discount = new Discount
                        {
                            Code = discount.Id,
                            Type = discount.Type,
                            Value = discount.Value
                        };

                    response.Collection.Add(transaction);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                response.Status.SetError(e);
            }

            return response;
        }
    }
}