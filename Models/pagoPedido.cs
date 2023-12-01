using SistemaCos_001.Clients;
using System.ComponentModel.DataAnnotations;

namespace SistemaCos_001.Models
{
    public class pagoPedido
    {
        public int pagoPedidoId { get; set; }
        public int pedidoId { get; set; }
        [Display(Name = " a cuenta")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El valor debe ser mayor que cero.")]
        public decimal acuenta { get; set; }
        public decimal saldo { get; set; }
        public decimal total { get; set; }
        public DateTime fecha { get; set; }
        public Pedido? Pedido { get; set; } = default!;

    }
}
