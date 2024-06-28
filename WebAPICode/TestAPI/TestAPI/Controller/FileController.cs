using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Services.FileService;

namespace TestAPI.Controller
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }


        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                await Task.Run(() => _fileService.Upload(ms, file.Name));
            }
            
            return Ok(file);
        }

        
    }
}
