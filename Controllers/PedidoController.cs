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
        public PedidoController(IProductoRepository productoRepository, IPedidoRepository pedidoRepository, IClienteRepository clienteRepository )
        {
            _pedidoRepository = pedidoRepository;
            _productoRepository = productoRepository;
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            string jsonString = "[{\"id\":\"2\",\"nombre\":\"Nombre del producto\",\"precio\":\"2\",\"cantidad\":\"1\",\"total\":\"2\"},{\"id\":\"3\",\"nombre\":\"Nombre del producto\",\"precio\":\"34\",\"cantidad\":\"2\",\"total\":\"68\"}]";
            var listaProductos = JsonConvert.DeserializeObject<List<DetallePedido>>(jsonString);

            foreach (var producto in listaProductos)
            {
                // Trabajar con cada objeto (producto)
            }
            var newPedido = new Pedido();
            var datos = _clienteRepository.GetAll;
            var model = new PedidoViewModel(_productoRepository.AllProductos,newPedido, new Cliente(), datos);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(PedidoViewModel model)
        {
            try
            {
                var jsonString = model.newPedido.jsonCadena;
                var dato = jsonString.Replace("\\", "");

                // Eliminar la primera comilla doble
                dato = dato.Substring(1);

                // Eliminar la última comilla doble
                dato = dato.Substring(0, dato.Length - 1);
                var totalSaldo = 0;
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
                    totalSaldo += objeto.total;
                    lista.Add(objeto);
                }
                model.newPedido.DetallePedidos = lista;
                model.newPedido.montoTotal = totalSaldo;
                model.newPedido.monto = totalSaldo;
                _pedidoRepository.agregar(model.newPedido);
                return RedirectToAction("crear","pagoPedido");
            }
            catch (Exception ex)
            {
                // Manejo de la excepción
                Console.WriteLine("Error al deserializar el JSON: " + ex.Message);
            }

            return View(model);
        }
    }
}
