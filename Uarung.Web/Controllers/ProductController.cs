using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Uarung.Model;
using Uarung.Web.Models;
using Uarung.Web.Utility;

namespace Uarung.Web.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        public ProductController(IConfiguration configuration)
            : base(configuration)
        {
        }

        public IActionResult Index()
        {
            var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);

            var response = new Requestor(GetApiSessionIdHeader())
                .Get<CollectionResponse<Product>>(url);

            return View(response.Collection);
        }

        public IActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Categories = GetCategories()
            };

            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var model = new ProductEditViewModel();
            ViewData[Constant.ConfigKey.ApiHost] = GetConfigValue(Constant.ConfigKey.ApiHost);

            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct)}{id}";
                var response = new Requestor(GetApiSessionIdHeader())
                    .Get<CollectionResponse<Product>>(url);

                model.Categories = GetCategories();

                if (response.Collection.Any())
                    model.Product = response.Collection.FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            var response = new BaseReponse();

            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct)}{id}";

                response = new Requestor(GetApiSessionIdHeader())
                    .Delete<BaseReponse>(url);

                if (response.Status.Type.Equals(Constant.Status.TypeError))
                    throw new Exception(response.Status.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                response.Status.SetError(e.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Insert(List<IFormFile> images, string name, string categoryId, decimal price)
        {
            var response = new BaseReponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);
                var productRequest = new ProductRequest
                {
                    CategoryId = categoryId,
                    Name = name,
                    Price = price
                };

                if (images.Any())
                {
                    var fileResponse = UploadImages(images);

                    productRequest.Images = fileResponse.ListPath
                        .Select(path => path)
                        .ToList();
                }

                response = new Requestor(GetApiSessionIdHeader())
                    .Post<BaseReponse>(url, productRequest);
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(List<IFormFile> images, string updatedImages, string id, string name,
            string categoryId, decimal price)
        {
            var response = new BaseReponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);

                var productRequest = new ProductRequest
                {
                    Id = id,
                    CategoryId = categoryId,
                    Name = name,
                    Price = price,
                    Images = updatedImages?
                        .Split(new[] {"||"}, StringSplitOptions.None)
                        .ToList()
                };

                if (images.Any())
                {
                    var fileResponse = UploadImages(images);

                    if (fileResponse.ListPath.Any())
                        productRequest.Images = productRequest.Images
                            .Concat(fileResponse.ListPath.Select(path => path))
                            .ToList();
                }

                response = new Requestor(GetApiSessionIdHeader())
                    .Put<BaseReponse>(url, productRequest);
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Category()
        {
            var model = GetCategories();

            return View(model);
        }

        [HttpPost]
        public IActionResult InsertCategory(string name)
        {
            var response = new BaseReponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);

                response = new Requestor(GetApiSessionIdHeader())
                    .Post<BaseReponse>(url, new ProductCategory {Name = name});
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return RedirectToAction("Category");
        }

        public IActionResult DeleteCategory(string id)
        {
            var response = new BaseReponse();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);

                response = new Requestor(GetApiSessionIdHeader())
                    .Delete<BaseReponse>($"{url}{id}");
            }
            catch (Exception e)
            {
                response.Status.SetError(e);
            }

            return RedirectToAction("Category");
        }

        private List<ProductCategory> GetCategories()
        {
            var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);

            var response = new Requestor(GetApiSessionIdHeader())
                .Get<CollectionResponse<ProductCategory>>(url);

            return response.Collection ?? new List<ProductCategory>();
        }

        private static StreamContent CreateFileContent(Stream stream, string fileName, string contentType)
        {
            var fileContent = new StreamContent(stream);

            fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "\"files\"",
                FileName = $"\"{fileName}\""
            };

            fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return fileContent;
        }

        private FileResponse UploadImages(IReadOnlyCollection<IFormFile> images)
        {
            if (!images.Any()) return new FileResponse();

            using (var uploadContent = new MultipartFormDataContent())
            {
                foreach (var image in images)
                    uploadContent.Add(CreateFileContent(image.OpenReadStream(), image.FileName,
                        image.ContentType));

                var uploadUrl = CreateServiceUrl(Constant.ConfigKey.ApiUrlFileUpload);

                return new Requestor(GetApiSessionIdHeader())
                    .PostContent<FileResponse>(uploadUrl, uploadContent);
            }
        }
    }
}