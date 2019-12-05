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
        public string NomeEmpresa { get; set; }
        public int IdPagamento { get; set; }
        public string DescPagamento { get; set; }
        public int IdPet { get; set; }
        public string NomePet { get; set; }
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }
        public double TotPedido { get; set; }
    }
}