using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models.Pet
{
    public class Pet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPet { get; set; }
        public int IdPessoa { get; set; }
        public int IdSubespecie { get; set; }
        public string RGPet { get; set; }
        public string ObsPet { get; set; }
        public string NomePet { get; set; }
    }
}