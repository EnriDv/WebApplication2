using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Pages
{
    public class Login : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private static int countErrors = 0;

        public string mensaje = "";

        public Login(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public void OnPost()
        {
            var datos = Request.Form;
            
            if (datos != null)
            {
                if (string.IsNullOrEmpty(datos["usuario"]))
                {
                    mensaje = "debe ingresar su correo";
                    ViewData["msg"] = mensaje;
                    ViewData["user"] = datos["usuario"];
                    return;
                }
                if (string.IsNullOrEmpty(datos["contrasena"]))
                {
                    mensaje = "debe ingresar su password";
                    ViewData["msg"] = mensaje;
                    ViewData["user"] = datos["usuario"];
                    return;
                }
                var pass = datos["pass"];
                if (pass.Equals("123"))
                {
                    mensaje = "hola";
                }
                else
                {
                    var nerrores = datos["nerror"];
                    ViewData["count"] = nerrores.Equals("") ? 0: Convert.ToInt32(nerrores) + 1;
                
                    if(nerrores != "3")
                    {
                        mensaje = "Le quedan " + (2 - Convert.ToInt32(nerrores)).ToString()
                               + " intentos, sera Bloqueado en el ultimo intento.";
                        ViewData["user"] = datos["usuario"];
                    }
                }
                ViewData["msg"] = mensaje;
            }
        }
    }
}
