using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebApplication2.Pages
{
    public class Register : PageModel
    {
        private readonly ILogger<Register> _logger;

        [BindProperty]
        public string Nombre { get; set; }
        [BindProperty]
        public string Apellido { get; set; }
        [BindProperty]
        public string CarnetIdentidad { get; set; }
        [BindProperty]
        public string Telefono { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Genero { get; set; }
        [BindProperty]
        public string Carrera { get; set; }

        public Register(ILogger<Register> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) ||
                string.IsNullOrWhiteSpace(CarnetIdentidad) || string.IsNullOrWhiteSpace(Telefono) ||
                string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Genero) ||
                string.IsNullOrWhiteSpace(Carrera))
            {
                ViewData["Message"] = "Todos los campos son obligatorios.";
                return Page(); // Recargar la página con el mensaje
            }

            // Simulación de almacenamiento (puedes guardarlo en la base de datos aquí)
            ViewData["Message"] = "Registro exitoso. Bienvenido, " + Nombre + "!";

            return Page();
        }
    }
}
