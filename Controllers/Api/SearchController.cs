using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;

namespace SistemasWeb01.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public SearchController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _stockRepository.GetStocks;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_stockRepository.GetStocks.Any(p => p.productoId == id))
                return NotFound();
            //return new JsonResult(_pieRepository.AllPies.Where(p =>p.PieId == id);
            return Ok(_stockRepository.GetStocks.Where(p => p.stockId == id));
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<stock> stocks = new List<stock>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                stocks = _stockRepository.SearchProducto(searchQuery);
            }
            return new JsonResult(stocks);
        }
    }
}
