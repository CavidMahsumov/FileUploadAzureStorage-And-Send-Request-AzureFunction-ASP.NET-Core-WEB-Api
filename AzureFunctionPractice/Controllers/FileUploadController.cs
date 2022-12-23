using AzureFunctionPractice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

namespace AzureFunctionPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration;

        public FileUploadController(IStorageService storageService, IConfiguration configuration)
        {
            _storageService = storageService;
            _configuration = configuration;
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok("File Upload Running ..");
        }

        [HttpPost(nameof(UploadFile))]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            await _storageService.Upload(file);
            return Ok("File Uploaded Successfully");
        }
    }
}
