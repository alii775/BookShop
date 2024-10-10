using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminBookShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly string _storagePath;
        public FileController(IConfiguration configuration)
        {
            _storagePath = configuration["FileUpload:StoragePath"];
        }
        [HttpGet("GetFile")]
        public IActionResult DownloadFile (string fileName) 
        {
            var fullpath= Path.Combine(_storagePath, fileName);
            if (!System.IO.File.Exists(fullpath)) 
            {
                return NotFound("File Not Found");
      
            }
            var fileBytes=System.IO.File.ReadAllBytes(fullpath);
            var contentType = "application/octet-stream";

            return PhysicalFile(fullpath,contentType,fileName);

        
        
        
        }

    }
}
