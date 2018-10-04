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
            var model = new ProductAddViewModel()
            {
                Categories = GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Insert(List<IFormFile> images, string name, string categoryId, decimal price)
        {
            var response = new BaseReponse();

            try
            {
                
                var uploadResponse = new FileResponse();

                if(images.Any())
                    using (var uploadContent = new MultipartFormDataContent())
                    {
                        foreach (var image in images)
                            uploadContent.Add(CreateFileContent(image.OpenReadStream(), image.FileName, image.ContentType));

                        var uploadUrl = CreateServiceUrl(Constant.ConfigKey.ApiUrlFileUpload);

                        uploadResponse = new Requestor(GetApiSessionIdHeader())
                            .PostContent<FileResponse>(uploadUrl, uploadContent);
                    }

                var addProductUrl = CreateServiceUrl(Constant.ConfigKey.ApiUrlProduct);
                var productRequest = new ProductRequest()
                {
                    CategoryId = categoryId,
                    Name = name,
                    Price = price,
                    Images = uploadResponse.ListPath
                        .Select(path => path)
                        .ToList()
                };

                response = new Requestor(GetApiSessionIdHeader())
                    .Post<BaseReponse>(addProductUrl, productRequest);
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
                    .Post<BaseReponse>(url, new ProductCategory{ Name = name });
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

            return response.Collection;
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
    }
}