using AzureFunctionPractice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public FileUploadController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public IActionResult Get()
        {
            return Ok("File Upload Running ..");
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {

            _storageService.Upload(file);

            return Ok("File Upload Succesfuly");

        }
    }
}
