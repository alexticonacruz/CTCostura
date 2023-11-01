using System.Net.Mail;
using System.Net;
//using Microsoft.Identity.Client;
using SistemaCos_001.Models;

namespace SistemaCos_001.Models
{
    public class VentaRepository : IVentaRepository
    {
        private readonly CTCosturaDbContext _cTCosturaDbContext;

        private readonly IShoppingCart _shoppingCart;

        public VentaRepository(CTCosturaDbContext bethesdaPieShopDbContext, IShoppingCart shoppingCart)
        {
            _cTCosturaDbContext = bethesdaPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Venta newVenta)
        {
            newVenta.fecha = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            newVenta.total = _shoppingCart.GetShoppingCartTotal();

            newVenta.listaVentas = new List<DetalleVenta>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new DetalleVenta
                {
                    cantidad = shoppingCartItem.Amount,
                    stockId = shoppingCartItem.Producto.stockId,
                    precio = shoppingCartItem.Producto.precioMenor
                };

                newVenta.listaVentas.Add(orderDetail);
            }

            _cTCosturaDbContext.VentasDbSet.Add(newVenta);

            _cTCosturaDbContext.SaveChanges();
        }
        public string detalleOrden (Venta venta, IEnumerable<Producto> produtosList) 
        {
            string nombre = "Lista de productos Comprados\n-----------------------------------";
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var objeto = produtosList.FirstOrDefault(s => s.productoId == shoppingCartItem.Producto.productoId);
                nombre = nombre + "\nproducto " +  objeto.modelo + " precio :" +shoppingCartItem.Producto.precioMenor + " Cantidad "+ shoppingCartItem.Amount;
                
            }
            nombre = nombre + "\nTotal : "+ venta.total;
            return nombre;
        }
        public void correoSend(string informacion, string Email)
        {

            string destinatario = Email;
            string asunto = "Correo de prueba";
            string contenido = informacion;

            // Configurar la información del remitente y el servidor SMTP
            string remitente = "alex29cruz09ticona@gmail.com";
            string contraseña = "kmdljfvakjzomaed";
            string servidorSmtp = "smtp.gmail.com";
            int puertoSmtp = 587;

            try
            {
                // Crear el objeto MailMessage con el contenido del correo
                MailMessage correo = new MailMessage(remitente, destinatario, asunto, contenido);

                // Configurar el cliente SMTP
                SmtpClient clienteSmtp = new SmtpClient(servidorSmtp, puertoSmtp);
                clienteSmtp.Credentials = new NetworkCredential(remitente, contraseña);
                clienteSmtp.EnableSsl = true;

                // Enviar el correo
                clienteSmtp.Send(correo);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
