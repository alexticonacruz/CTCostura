using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;
using SistemaCos_001.ViewModels;

namespace SistemaCos_001.Controllers
{
    public class pagoPedidoController : Controller
    {
        private readonly IpagoPedido _pagoPedido;
        private readonly IPedidoRepository pedidoRepository;
        public pagoPedidoController(IpagoPedido ipagoPedido, IPedidoRepository pedidoRepository)
        {
            _pagoPedido = ipagoPedido;
            this.pedidoRepository = pedidoRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult crear()
        {
            var lista = pedidoRepository.GetAll;
            var model = new pagoPedidoViewModel
            {
                pagoPedido = new pagoPedido(),
                Pedidos = lista
            };
            return View(model);
        }
        public IActionResult editar(int id)
        {
            Pedido cat = pedidoRepository.GetById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
    }
}
