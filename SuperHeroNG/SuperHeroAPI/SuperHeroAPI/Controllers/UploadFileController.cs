using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        public static IWebHostEnvironment _environment;
        public UploadFileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public string Get()
        {
            string texto = " Web API - UploadImageController em execução : " + DateTime.Now.ToLongTimeString();
            texto += $"\n Ambiente :  {_environment.EnvironmentName}";
            return texto;
        }

        [HttpPost("upload")]
        public async Task<string> EnviaArquivo([FromForm] IFormFile arquivo)
        {
            if (arquivo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\arquivos\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\arquivos\\");
                    }
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\arquivos\\" + arquivo.FileName))
                    {
                        await arquivo.CopyToAsync(filestream);
                        filestream.Flush();
                        return "\\arquivos\\" + arquivo.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Ocorreu uma falha no envio do arquivo...";
            }
        }
    }
}
