using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private static int countErrors = 0; // Variable estática para contar intentos fallidos

        [BindProperty]
        public string Usuario { get; set; }

        [BindProperty]
        public string Contrasena { get; set; }

        private const string PasswordCorrecta = "admin123"; // Simulación de contraseña correcta

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnPost()
        {
            if (Usuario == "admin" && Contrasena == PasswordCorrecta)
            {
                countErrors = 0; // Restablecer intentos si es correcto
                return RedirectToPage("Privacy");
            }
            else
            {
                countErrors++; // Aumentar intentos fallidos

                if (countErrors >= 3)
                {
                    return RedirectToPage("Error"); // Bloquear después de 3 intentos
                }

                ViewData["ErrorMessage"] = "Usuario o contraseña incorrectos. Intento " + countErrors + " de 3.";
                return Page(); // Recargar la página con mensaje de error
            }
        }
    }
}
