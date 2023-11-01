using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
using SistemaCos_001.Models;

namespace SistemaCos_001.Models
{
    public class CategoriaRepository: ICategoriaRepository
    {

        private readonly CTCosturaDbContext _cTCosturaDbContext;

        public CategoriaRepository(CTCosturaDbContext bethesdaPieShopDbContext)
        {
            _cTCosturaDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<Categoria> AllCategorias => _cTCosturaDbContext.CategoriasDbSet.OrderBy(p => p.nombre);

        public void CreateCategory(Categoria category)
        {
            _cTCosturaDbContext.CategoriasDbSet.Add(category);
            _cTCosturaDbContext.SaveChanges();

        }
        public void UpdateCategory(Categoria category)
        {
            _cTCosturaDbContext.CategoriasDbSet.Update(category);
            _cTCosturaDbContext.SaveChanges();

        }
        /* Mostrar categorias*/
        public IEnumerable<Categoria> Categorias => _cTCosturaDbContext.CategoriasDbSet.ToList();

        /* Buscar por ID*/
        public Categoria GetById(int id)
        {
            return _cTCosturaDbContext.CategoriasDbSet.FirstOrDefault(p => p.categoriaId == id);
        }
        /* borrar*/
        public void  DeleteCategory(Categoria category)
        {
            _cTCosturaDbContext.CategoriasDbSet.Remove(category);
            _cTCosturaDbContext.SaveChanges();
        }


    }
}
