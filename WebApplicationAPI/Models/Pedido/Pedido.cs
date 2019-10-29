using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.Pedido
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPagamento { get; set; }
        public int IdPet { get; set; }
        public double TotPedido { get; set; }
    }
}