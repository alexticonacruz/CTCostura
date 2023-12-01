using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;
using Newtonsoft.Json;
using SistemaCos_001.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaCos_001.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IpagoPedido _pagoPedidoRepository;
        public PedidoController(IProductoRepository productoRepository, IPedidoRepository pedidoRepository, IClienteRepository clienteRepository,IpagoPedido pagoPedidoRepository )
        {
            _pedidoRepository = pedidoRepository;
            _productoRepository = productoRepository;
            _clienteRepository = clienteRepository;
            _pagoPedidoRepository  = pagoPedidoRepository;
        }
        public IActionResult Index()
        {
            
            var model = new PedidoViewModel
            {
                productos = _productoRepository.AllProductos,
                newPedido = new Pedido(),
                newCliente = new Cliente(),
                clientes = _clienteRepository.GetAll,
                newPago = new pagoPedido()
            };
            return View(model);
        }
        [HttpPost]
        public  IActionResult Agregar(PedidoViewModel model)
        {
            try
            {
                var jsonString = model.newPedido.jsonCadena;
                var dato = jsonString.Replace("\\", "");

                // Eliminar la primera comilla doble
                dato = dato.Substring(1);

                // Eliminar la última comilla doble
                dato = dato.Substring(0, dato.Length - 1);
                var lista = new List<DetallePedido>();
                Console.WriteLine(dato);
                var listaObjetos = JsonConvert.DeserializeObject<List<DetallePedido>>(dato);
                foreach (var producto in listaObjetos)
                {
                    var objeto = new DetallePedido
                    {
                        productoId = producto.productoId,
                        cantidad = producto.cantidad,
                        total = producto.total,
                    };
                    lista.Add(objeto);
                }
                model.newPedido.DetallePedidos = lista;


                _pedidoRepository.agregar(model.newPedido);

                var se = 5;
                // registra el primer pago 

                model.newPago.saldo = model.newPedido.montoTotal - model.newPago.acuenta;
                model.newPago.total = model.newPedido.montoTotal;
                model.newPago.pedidoId = model.newPedido.pedidoId;
                _pagoPedidoRepository.agregar(model.newPago);


                return RedirectToAction("crear","pagoPedido");
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al deserializar el JSON: " + ex.Message);
                return  RedirectToAction ("index");
            }

        }
    }
}
