using System.Net.Mail;
using System.Net;
//using Microsoft.Identity.Client;
using SistemaCos_001.Models;
using Microsoft.EntityFrameworkCore;

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
        public List<string> ventasActual()
        {
            // Obtiene la fecha actual
            DateTime fechaActual = DateTime.Now;

            // Obtiene el mes y el año del mes actual
            int mesActual = fechaActual.Month;
            int anioActual = fechaActual.Year;

            // Obtiene el mes y el año del mes anterior
            int mesAnterior = mesActual - 1;
            int anioAnterior = anioActual;

            if (mesAnterior == 0) // Maneja el caso de diciembre, donde el mes anterior es noviembre del año anterior
            {
                mesAnterior = 12;
                anioAnterior--;
            }

            DateTime now = DateTime.Now;
            string nombreDelMes = now.ToString("MMMM");

            DateTime fechaEspecifica = new DateTime(anioAnterior, mesAnterior, 1); // Puedes usar la fecha que desees
            string nombreDelMesAnterior = fechaEspecifica.ToString("MMMM");


            // Realiza una consulta LINQ para sumar el Total de las ventas del mes actual
            var ventasMesActual = _cTCosturaDbContext.VentasDbSet
                .Where(venta => venta.fecha.Month == mesActual && venta.fecha.Year == anioActual)
                .ToList();

            decimal totalVentasMesActual = ventasMesActual.Sum(venta => venta.total);

            // Realiza una consulta LINQ para sumar el Total de las ventas del mes anterior
            var ventasMesAnterior = _cTCosturaDbContext.VentasDbSet
                .Where(venta => venta.fecha.Month == mesAnterior && venta.fecha.Year == anioAnterior)
                .ToList();

            decimal totalVentasMesAnterior = ventasMesAnterior.Sum(venta => venta.total);

            // Obtén la fecha de inicio y fin del mes actual
            DateTime fechaInicioMes = new DateTime(anioActual, mesActual, 1);
            DateTime fechaFinMes = fechaInicioMes.AddMonths(1).AddDays(-1);

            // Realiza la consulta para contar las ventas en el mes actual
            int ventasEnMesActual = _cTCosturaDbContext.VentasDbSet
                .Where(venta => venta.fecha >= fechaInicioMes && venta.fecha <= fechaFinMes)
                .Count();

            // Obtén la fecha de inicio y fin del mes anterior
            //DateTime fechaInicioMesAnterior = new DateTime(anioAnterior, mesAnterior, 1);
            //DateTime fechaFinMesAnterior = fechaInicioMesAnterior.AddMonths(1).AddDays(-1);

            DateTime fechaInicioMesAnterior = new DateTime(anioAnterior, mesAnterior, 1);
            DateTime fechaFinMesAnterior = fechaInicioMesAnterior.AddMonths(1).AddSeconds(-1);


            // Realiza la consulta para contar las ventas en el mes anterior
            int ventasEnMesAnterior = _cTCosturaDbContext.VentasDbSet
                .Where(venta => venta.fecha >= fechaInicioMesAnterior && venta.fecha <= fechaFinMesAnterior)
                .Count();

            List<string> result = new List<string>();
            result.Add(nombreDelMes.ToString()); // Mes actual en cadena
            result.Add(ventasEnMesActual.ToString()); // N ventas en el mes actual
            result.Add(totalVentasMesActual.ToString()); // Dinero ganado este mes


            result.Add(nombreDelMesAnterior.ToString()); // Mes anterior en cadena
            result.Add(ventasEnMesAnterior.ToString()); // N ventas en el mes anterior
            result.Add(totalVentasMesAnterior.ToString()); // Dinero ganado el mes anterior
            

            return result;
        }
    }
}
