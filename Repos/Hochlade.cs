using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.AspNetCore.Hosting;
using Personal_Server_App.Interfaces;

namespace Personal_Server_App.Repos
{
    public class Hochlade : IHochladen
    {

        private readonly IWebHostEnvironment _env;
        
        
       public Hochlade(IWebHostEnvironment env)
        {
            _env = env;
        }



        public void RemoveFile(string picName)
        {
            throw new NotImplementedException();
        }

        public async Task UploadFile(IFileListEntry file, string picName)
        {
            try
            {
                var ms = new MemoryStream();
                await file.Data.CopyToAsync(ms);

                var path = $"{_env.WebRootPath}\\hochladen\\{picName}";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    ms.WriteTo(fs);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UploadFile(IFileListEntry file, MemoryStream msFile, string picName)
        {
            try
            {
                var path = $"{_env.WebRootPath}\\hochladen\\{picName}";

                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    msFile.WriteTo(fs);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }




}
