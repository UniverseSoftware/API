using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApplicationAPI.Models.Fatura
{
    public class Fatura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFatura { get; set; }
        public DateTime DteFatura { get; set; }
        public DateTime DtvFatura { get; set; }
        public double TotFatura { get; set; }
        public double VldFatura { get; set; }
        public double VlpFatura { get; set; }
    }
}