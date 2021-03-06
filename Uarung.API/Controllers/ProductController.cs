﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Uarung.API.Utility;
using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Model;
using Product = Uarung.Model.Product;

namespace Uarung.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IDacProduct _dacProduct;
        private readonly IDacProductCategory _dacProductCategory;
        private readonly IDistributedCache _distributedCache;
        private readonly IDacProductImage _dacProductImage;
        

        public ProductController(IDacProduct dacProduct, IDacProductImage dacProductImage,
            IDacProductCategory dacProductCategory, IDistributedCache distributedCache)
        {
            _dacProduct = dacProduct;
            _dacProductImage = dacProductImage;
            _dacProductCategory = dacProductCategory;
            _distributedCache = distributedCache;
        }
        
        [HttpPost]
        public ActionResult<BaseResponse> Create(ProductRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var productId = GenerateId();
                var userId = GetUserId(Request, _distributedCache);

                var product = new Data.Entity.Product
                {
                    Id = productId,
                    UserId = userId,
                    CategoryId = request.CategoryId,
                    Name = request.Name,
                    Price = request.Price
                };

                if (request.Images.Any())
                    product.ProductImages = CreateProductImage(request.Images, productId);

                _dacProduct.Insert(product);
                _dacProduct.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }

        [CashierAllowed]
        [HttpGet("{id=}")]
        public ActionResult<CollectionResponse<Product>> Get(string id)
        {
            var response = new CollectionResponse<Product>();

            try
            {
                var products = (string.IsNullOrEmpty(id)
                        ? _dacProduct.All()
                        : new[] {_dacProduct.Single(id)})
                    .ToList();

                response.Collections = products
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Images = _dacProductImage
                            .Where(pi => pi.ProductId.Equals(p.Id))
                            .Select(pi => pi.Url)
                            .ToList(),
                        CategoryName = _dacProductCategory.Single(p.CategoryId)?
                            .Name ?? string.Empty
                    })
                    .ToList();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }
        
        [HttpDelete("{id}")]
        public ActionResult<BaseResponse> Delete(string id)
        {
            var response = new BaseResponse();

            try
            {
                var product = _dacProduct.Single(id);

                if (product == null)
                    throw new Exception("data is not exist");

                _dacProduct.Delete(product);
                _dacProduct.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }
        
        [HttpPut]
        public ActionResult<BaseResponse> Update(ProductRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var product = _dacProduct.Single(request.Id);

                if (product == null)
                    throw new Exception("data is not exist");

                var isImageChanges = string.Join(".", product.ProductImages.Select(p => p.Url)) != string.Join(".", request.Images);

                if (request.Images.Any() && isImageChanges)
                {
                    _dacProductImage.DeleteWhere(p => p.ProductId.Equals(product.Id));
                    product.ProductImages = CreateProductImage(request.Images, product.Id);
                }

                if (request.Name != product.Name)
                    product.Name = request.Name;

                if (request.CategoryId != product.CategoryId)
                    product.CategoryId = request.CategoryId;

                if(request.Price != product.Price)
                    product.Price = request.Price;

                _dacProduct.Update(product);
                _dacProduct.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e);
            }

            return response;
        }

        private static List<ProductImage> CreateProductImage(IEnumerable<string> imageUrl, string productId)
        {
            return imageUrl
                .Select(i => new ProductImage
                {
                    Id = GenerateId(),
                    ProductId = productId,
                    Url = i
                })
                .ToList();
        }
    }
}