using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Clients;
using SistemaCos_001.Models;

namespace SistemaCos_001.Controllers
{
    public class PaypalController : Controller
    {
        private readonly PaypalClient _paypalClient;
        private readonly IShoppingCart _shoppingCart;
        public PaypalController(PaypalClient paypalClient, IShoppingCart shoppingCart)
        {
            this._paypalClient = paypalClient;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            // ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
            ViewBag.ClientId = _paypalClient.ClientId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            decimal total = _shoppingCart.GetShoppingCartTotal();

            try
            {
                // set the transaction price and currency
                var price = Convert.ToString(total);
                var newPrice = price.Replace(",", ".");
                //var price = "10,50";
                var currency = "USD";

                // "reference" is the transaction key
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(newPrice, currency, reference);

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderId);

                var reference = response.purchase_units[0].reference_id;
                string id_transaccion = response.purchase_units[0].payments.captures[0].id;

                TempData["Informacion"] = id_transaccion;
                // Put your logic to save the transaction here
                // You can use the "reference" variable as a transaction key

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public IActionResult Success(string transactionId)
        {
            var informacion = TempData["Informacion"] as string;
            // Pasa el ID de la transacción a la vista
            ViewBag.TransactionId = informacion;
            return View();
        }
    }
}
