using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SistemaCos_001.Models
{
    public class CTCosturaDbContext: IdentityDbContext
    {
        public CTCosturaDbContext(DbContextOptions<CTCosturaDbContext> options) : base(options)
        {
            Database.Migrate();// this will migrate the database on startup

        }
        public DbSet<Venta> VentasDbSet { get; set; }
        public DbSet<DetalleVenta> detalleVentasDbSet { get; set; }
        public DbSet<Producto> ProductosDbSet { get; set; }
        public DbSet<Categoria> CategoriasDbSet { get; set; }
        public DbSet<stock> StocksDbSet { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItemsDbSet { get; set; }
        public DbSet<Pedido> pedidosDbSet { get; set; }
        public DbSet<DetallePedido> detallePedidosDbSet { get; set; }

    }
}
