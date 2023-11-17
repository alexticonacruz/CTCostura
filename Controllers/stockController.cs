using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;
using SistemaCos_001.ViewModels;

namespace SistemaCos_001.Controllers
{
    public class stockController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IStockRepository _stockRepository;
       
        public stockController(IProductoRepository productoRepository, IStockRepository stockRepository)
        {
            _productoRepository = productoRepository;
            _stockRepository = stockRepository;

        }
        public IActionResult Index()
        {
            return View(_stockRepository.GetStocks);
        } 
        public IActionResult Agregar() 
        {
            stock stock = new stock();
            StockViewModel model = new StockViewModel(_productoRepository.AllProductos, stock);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(StockViewModel model)
        {
            if(model.newStock != null)
            {
                _stockRepository.saveStock(model.newStock);
                return RedirectToAction("Index");
            }
            
           
            return RedirectToAction("Index", "stock");

        }
        public IActionResult ultimos()
        {
            var newStock = _stockRepository.Ultimos();
            return View(newStock);
        }
    }
}
