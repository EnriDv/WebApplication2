using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string usuario { get; set; }
        [BindProperty]
        public string password { get; set; } 

        private static int countErrors = 0;

        public string mensaje = "";

        public IndexModel(ILogger<IndexModel> logger)
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
                    ViewData["count"] = nerrores.Equals("") ? 0 : Convert.ToInt32(nerrores) + 1;

                    if (nerrores != "3")
                    {
                        mensaje = "Le quedan " + (2 - Convert.ToInt32(nerrores)).ToString()
                               + " intentos, sera Bloqueado en el ultimo intento.";
                        ViewData["user"] = datos["usuario"];
                    }
                }
                ViewData["msg"] = mensaje;
            }

            /*
            var datos = Request.Form; //el formulario lo maneja como una Coleccion
            var pass = datos["contrasena"];
            if (string.IsNullOrEmpty(datos["usuario"]))
            {
                mensaje = "debe ingresar su email";
            }
            if (string.IsNullOrEmpty(datos["contrasena"]))
            {
                mensaje = "debe ingresar su contrasena";
            }
            if (pass.Equals("123"))
            {
                countErrors++;
                mensaje = "Usuario o Contrasena fallido, le quedan " + (3 - countErrors) + " intentos disponible";
            }
            ViewData["msg"] = mensaje;
            */


            /*
            if (Usuario == UsserCorrecta && Contrasena == PasswordCorrecta)
            {
                countErrors = 0; // Restablecer intentos si es correcto
                return RedirectToPage("Privacy" );
            }
            else
            {
                countErrors++; // Aumentar intentos fallidos
                if (countErrors >= 3)
                {
                    return RedirectToPage("Error"); // Bloquear después de 3 intentos
                }
                
                //throw new Exception("Usuario o contraseña incorrectos. Intento " + countErrors + " de 3.");
                return Page(); // Recargar la página con mensaje de error
            }
            */
        }
    }
}
