using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.ServicoEmpresa
{
    public class ServicoEmpresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdServicoEmpresa { get; set; }
        public int IdEmpresa { get; set; }
        public int IdServico { get; set; }
        public double VlServicoEmpresa { get; set; }
    }
}