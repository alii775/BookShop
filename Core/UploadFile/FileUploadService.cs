﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UploadFile
{
    public class FileUploadService : IFileUploadService
    {
        private readonly string _storagePath;
        public FileUploadService(IConfiguration configuration)
        {
            _storagePath = configuration["FileUpload:StoragePath"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (!Directory.Exists(_storagePath)) 
            {
                Directory.CreateDirectory(_storagePath);
            }
            if (file == null || file.Length == 0) 
            {
                throw new ArgumentNullException("File Is Empty or Not Provided");

            }
            var fileName= Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);
            var fulPath= Path.Combine(_storagePath, fileName);
            using (var stream = new FileStream(fulPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);

            }
            return fileName;
        }
    }
}
