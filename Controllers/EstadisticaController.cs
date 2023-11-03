using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;

namespace SistemaCos_001.Controllers
{
    public class EstadisticaController : Controller
    {
        private readonly IVentaRepository _ventaRepository;
        public EstadisticaController(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }
        public IActionResult Index()
        {
            var venta = _ventaRepository.ventasActual();
            return View(venta);
        }
    }
}
