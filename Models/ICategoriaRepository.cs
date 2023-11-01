using SistemaCos_001.Models;

namespace SistemaCos_001.Models
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> AllCategorias { get;}
        IEnumerable<Categoria> Categorias { get;}
        Categoria GetById(int id);
        void CreateCategory(Categoria category);
        void UpdateCategory(Categoria category);
        void DeleteCategory(Categoria category);
        
    }
}
