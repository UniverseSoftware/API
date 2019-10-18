using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.Plano
{
    public class Plano
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPlano { get; set; }
        public int TipoPlano { get; set; }
        public string DescPlano { get; set; }
        public int DuraPlano { get; set; }
        public double ValorPlano { get; set; }
    }
}