using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaBLL.FileSave
{
    public class fileService : IFileService
    {
        private readonly IHostingEnvironment environment;

        public fileService(IHostingEnvironment environment)
        {
            this.environment = environment;
        }
        public async Task<string> SaveOnDriveAsync(IFormFile file)
        {
            try
            {
                var uploads = Path.Combine(environment.ContentRootPath, "uploads");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }

                var filePath = Path.Combine(uploads, file.FileName);

                if (File.Exists(filePath))
                    File.Delete(filePath);


                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return filePath;
            }
            catch (Exception e)
            {
                // place to add logging
                throw e;
            }
        }
    }
}
