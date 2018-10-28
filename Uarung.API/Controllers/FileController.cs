using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uarung.Model;

namespace Uarung.API.Controllers
{
    [Route("[controller]")]
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public FileController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<ActionResult<FileResponse>> Upload(List<IFormFile> files)
        {
            var response = new FileResponse();
            var index = 0;

            try
            {
                ValidateImageFiles(files);

                var wwwrootPath = $"{_environment.ContentRootPath}\\wwwroot";
                var physicalPath = $"{wwwrootPath}\\uploads\\{DateTime.Now:yyMMdd}\\";

                Directory.CreateDirectory(physicalPath);

                foreach (var f in files)
                {
                    var fileName = $"{physicalPath}{f.FileName}";

                    using (var stream = new FileStream(fileName, FileMode.Create))
                    {
                        await f.CopyToAsync(stream);
                    }

                    var pathResult = fileName
                        .Replace(wwwrootPath, string.Empty)
                        .Replace("\\", "/");

                    response.ListPath.Add(pathResult);

                    index++;
                }

                response.Status.SetSuccess();
            }
            catch (Exception e)
            {
                response.Status.SetError($"{e.Message} | error at index {index} | {e.InnerException?.Message} | {e.StackTrace}");
            }

            return response;
        }

        private void ValidateImageFiles(List<IFormFile> files) 
        {
            var supportedTypes = new[] { "jpg", "jpeg", "png" };

            foreach (var file in files)
            {
                var extension = Path.GetExtension(file.FileName).Substring(1).ToLower();

                if (!supportedTypes.Contains(extension))
                    throw new Exception($"this extension [{extension}] is not supported");
            }
        }
    }
}