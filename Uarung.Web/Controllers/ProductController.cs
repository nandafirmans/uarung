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
            var response = new CollectionResponse<Product>();

            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);
                response = Requestor().Get<CollectionResponse<Product>>(url);

                CheckResponse(response);
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(response.Collections);
        }

        public IActionResult Add()
        {
            var model = new ProductAddViewModel();

            try
            {
                model = new ProductAddViewModel
                {
                    Categories = GetCategories()
                };
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Edit(string id)
        {
            var model = new ProductEditViewModel();
            ViewData[Constant.ConfigKey.ApiHost] = GetConfigValue(Constant.ConfigKey.ApiHost);

            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct)}{id}";
                var response = Requestor().Get<CollectionResponse<Product>>(url);

                CheckResponse(response);

                model.Categories = GetCategories();
                model.Product = response.Collections.FirstOrDefault();
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                var url = $"{CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct)}{id}";
                var response = Requestor().Delete<BaseReponse>(url);

                CheckResponse(response);

                return RedirectToAction("Index", new { ok = "delete success" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { err = e.Message });
            }
        }

        [HttpPost]
        public IActionResult Insert(List<IFormFile> images, string name, string categoryId, decimal price)
        {
            var requestor = Requestor();

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
                    productRequest.Images = UploadImages(images, requestor).ListPath
                        .Select(path => path)
                        .ToList();

                var response = requestor.Post<BaseReponse>(url, productRequest);

                CheckResponse(response);

                return RedirectToAction("Index", new {ok = "insert success"});
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new {err = e.Message});
            }
        }

        [HttpPost]
        public IActionResult Update(List<IFormFile> images, string updatedImages, string id, string name,
            string categoryId, decimal price)
        {
            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);
                var requestor = Requestor();

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
                    var fileResponse = UploadImages(images, requestor);

                    if (fileResponse.ListPath.Any())
                        productRequest.Images = productRequest.Images
                            .Concat(fileResponse.ListPath.Select(path => path))
                            .ToList();
                }

                var response = requestor.Put<BaseReponse>(url, productRequest);

                CheckResponse(response);

                return RedirectToAction("Index", new { ok = "update success" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { err = e.Message });
            }
        }

        public IActionResult Category()
        {
            var model = new List<ProductCategory>();

            try
            {
                model = GetCategories();
            }
            catch (Exception e)
            {
                SetErrorMessage(e);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult InsertCategory(string name)
        {
            
            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);
                var response = Requestor().Post<BaseReponse>(url, new ProductCategory { Name = name });

                CheckResponse(response);

                return RedirectToAction("Category", new { ok = "insert success" });
            }
            catch (Exception e)
            {   
                return RedirectToAction("Category", new { err = e.Message });
            }
        }

        public IActionResult DeleteCategory(string id)
        {
            try
            {
                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);
                var response = Requestor().Delete<BaseReponse>($"{url}{id}");

                CheckResponse(response);

                return RedirectToAction("Category", new { ok = "delete success" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Category", new { err = e.Message });
            }

        }

        private List<ProductCategory> GetCategories()
        {
            var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlProductCategory);
            var response = Requestor().Get<CollectionResponse<ProductCategory>>(url);

            CheckResponse(response);

            return response.Collections ?? new List<ProductCategory>();
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

        private FileResponse UploadImages(IReadOnlyCollection<IFormFile> images, Requestor requestor)
        {
            if (!images.Any()) return new FileResponse();

            using (var content = new MultipartFormDataContent())
            {
                foreach (var image in images)
                    content.Add(CreateFileContent(image.OpenReadStream(), image.FileName, image.ContentType));

                var url = CreateServiceUrl(Constant.ConfigKey.ApiUrlFileUpload);

                return Requestor().PostContent<FileResponse>(url, content);
            }
        }
    }
}