using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.Avaliacao
{
    public class Avaliacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAvaliacao { get; set; }
        public int IdPedido { get; set; }
        public double NotaAvaliacao { get; set; }
        public string NFantasiaEmpresa { get; set; }
        public string TituloAvaliacao { get; set; }
        public string ComentAvaliacao { get; set; }
    }
}