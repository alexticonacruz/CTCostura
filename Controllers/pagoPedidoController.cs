﻿using Microsoft.AspNetCore.Mvc;
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
            var pagos = _pagoPedido.GetPedidos;
            return View(pagos);
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
            var ultimoPago = _pagoPedido.ultimoPago(id);

            if (cat != null)
            {
                var model = new pagoPedidoViewModel
                {
                    newPedido = cat,
                    pagoPedido = new pagoPedido(),
                    saldoTemporal = ultimoPago
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult crear(pagoPedidoViewModel newPago)
        {
            //var ob = pedidoRepository.GetById(newPago.pagoPedido.pedidoId);
            //newPago.pagoPedido.total = ob.montoTotal;
            //newPago.pagoPedido.saldo = ob.montoTotal - newPago.pagoPedido.acuenta;
            ////pedidoRepository.update(ob);
            _pagoPedido.agregar(newPago.pagoPedido);
            return Redirect("primerPago");
            
        }
        public IActionResult primerPago()
        {
            return View();
        }
    }
}
