using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaCos_001.Models;

namespace SistemaCos_001.Controllers
{
    public class CategoriaController : Controller
    {
       
        private readonly ICategoriaRepository _categoryRepository;
        public CategoriaController(ICategoriaRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.Categorias);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Categoria category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.CreateCategory(category);
                return RedirectToAction("index");
            }

            return View(category);

        }
        public IActionResult CategoryCreated()
        {
            ViewBag.CategorCreatedMessage = "Thanks for your adding new Caregory for your products!";
            return View();
        }
        public IActionResult listCategoria()
        {
            
            return View(_categoryRepository.Categorias);
        }
        public IActionResult editar(int id)
        {
            Categoria cat = _categoryRepository.GetById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost]
        public IActionResult editar(Categoria _categoria)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(_categoria);
                return RedirectToAction("Index", "Categoria");
            }
            else
            {
                return View(_categoria);
            }
        }
        /* Detalles*/
        public IActionResult detalle(int id)
        {
            Categoria cat = _categoryRepository.GetById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }

        public IActionResult delete(int id)
        {
            Categoria cat = _categoryRepository.GetById(id);
            if (cat != null)
            {
                return View(cat);
            }

            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult delete(Categoria _categoria)
        {
            Categoria cat = _categoryRepository.GetById(_categoria.categoriaId);
            
            _categoryRepository.DeleteCategory(cat);
            return RedirectToAction("Index", "Categoria");
            
            
        }
    }
}
