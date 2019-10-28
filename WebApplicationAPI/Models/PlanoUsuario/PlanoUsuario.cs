using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.PlanoUsuario
{
    public class PlanoUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuarioPlano { get; set; }
        public int IdPlano { get; set; }
        public int IdUsuario { get; set; }
        public int ValidUsuarioPlano { get; set; }
    }
}