using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;

namespace SistemaCos_001.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult crear(Cliente newCliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.agregar(newCliente);
                return RedirectToAction("Index");
            }
            return View(newCliente);
        }
        [HttpPost]
        public IActionResult agregar(Cliente newCliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.agregar(newCliente);
                // Devolver un resultado JSON con el estado de la operación y el objeto creado
                return Json(new { success = true, data = newCliente });
            }


            else
            {
                var errores = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                // Devolver un resultado JSON con el estado de la operación y los errores de validación
                return Json(new { success = false, errors = errores });
            }
        }
       
    }
}
