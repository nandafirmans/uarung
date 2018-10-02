using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Uarung.Data.Contract;
using Uarung.Data.Entity;
using Uarung.Model;
using Product = Uarung.Model.Product;

namespace Uarung.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IDacProduct _dacProduct;
        private readonly IDacProductImage _dacProductImage;
        private readonly IDacUser _dacUser;

        public ProductController(IDacProduct dacProduct, IDacUser dacUser, IDacProductImage dacProductImage)
        {
            _dacProduct = dacProduct;
            _dacUser = dacUser;
            _dacProductImage = dacProductImage;
        }

        [HttpPost]
        public ActionResult<BaseReponse> Create(ProductRequest request)
        {
            var response = new BaseReponse();

            try
            {
                var productId = GenerateId();
                var product = new Data.Entity.Product
                {
                    Id = productId,
                    CategoryId = request.CategoryId,
                    UserId = request.UserId,
                    Name = request.Name,
                    Price = request.Price
                };

                if (request.Images.Any())
                    product.ProductImages = request.Images
                        .Select(i => new ProductImage
                        {
                            Id = GenerateId(),
                            ProductId = productId,
                            Url = i
                        })
                        .ToList();

                _dacProduct.Insert(product);
                _dacProduct.Commit();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }

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

                response.Collection = products
                    .Select(p => new Product
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Images = _dacProductImage
                            .Where(pi => pi.ProductId.Equals(p.Id))
                            .Select(pi => pi.Url)
                            .ToList()
                    })
                    .ToList();

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return response;
        }
    }
}