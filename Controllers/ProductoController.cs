using Microsoft.AspNetCore.Mvc;
using SistemaCos_001.Models;
using SistemaCos_001.ViewModels;

namespace SistemaCos_001.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ICategoriaRepository _categoryRepository;
        private readonly IProductoRepository _productoRepository;
        public ProductoController(ICategoriaRepository categoryRepository, IProductoRepository productoRepository)
        {
            _categoryRepository = categoryRepository;
            _productoRepository = productoRepository;
        }
        public IActionResult Index()
        {
            ProductoListViewModel productos = new ProductoListViewModel(_categoryRepository.Categorias,_productoRepository.filtroDelete);
            //return View(_productoRepository.AllProductos);
            return View(productos);
        }
        public IActionResult Crear()
        {

            return View(_categoryRepository.Categorias);
        }
        public IActionResult Agregar()
        {
            Producto varProducto = new Producto();
            ViewModel models = new ViewModel(_categoryRepository.Categorias, _productoRepository.productosList,varProducto);
            return View(models);
        }
        [HttpPost]
        public async Task <IActionResult> Agregar(ViewModel model, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                var fileName = Path.GetFileName(imagen.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }


                model.productoClass.urlImagen = fileName; // Guardamos el nombre de la imagen en el atributo imagen del modelo Producto
            }
            _productoRepository.CreateProducto(model.productoClass);
            return RedirectToAction("Index", "Producto");
            
        }
        public IActionResult delete(int id)
        {
            Producto prod = _productoRepository.GetById(id);
            if (prod != null)
            {
                return View(prod);
            }

            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult delete(Producto _producto)
        {
            Producto prod = _productoRepository.GetById(_producto.productoId);
            prod.estado = _producto.estado;
            _productoRepository.deleteUpdate(prod);
            return RedirectToAction("Index", "producto");


        }
        /* ------------------------ */
        public ViewResult List(string category)
        {
            IEnumerable<Producto> productos;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                productos = _productoRepository.AllProductos.OrderBy(p => p.productoId);
                currentCategory = "All pies";
            }
            else
            {
                productos = _productoRepository.AllProductos.Where(p => p.Categoria.nombre == category)
                    .OrderBy(p => p.productoId);
                currentCategory = _categoryRepository.Categorias.FirstOrDefault(c => c.nombre == category)?.nombre;
            }

            return View(new ProductoListViewModel(_categoryRepository.Categorias, productos));
        }

        public IActionResult Details(int id)
        {
            Producto producto = _productoRepository.GetProductosById(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }
        public IActionResult Search() { return View(); }
       

    }
}
