using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.ItemPedido
{
    public class ItemPedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItemPedido { get; set; }
        public int IdPedido { get; set; }
        public int itemPedido { get; set; }
        public int IdServicoEmpresa { get; set; }
        public int QtdServico { get; set; }
        public double VlServico { get; set; }
        public double TotServico { get; set; }
        public string ObsServico { get; set; }
        public int IdFatura { get; set; }
    }
}