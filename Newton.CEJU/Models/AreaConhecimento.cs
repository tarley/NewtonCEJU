using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Newton.CJU.Models
{
    public class AreaConhecimento
    {
        public AreaConhecimento()
        {
            AtividadeSemestral = new HashSet<AtividadeSemestral>();
            FatoCotidiano = new HashSet<FatoCotidiano>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; }

        public virtual ICollection<AtividadeSemestral> AtividadeSemestral { get; set; }
        public virtual ICollection<FatoCotidiano> FatoCotidiano { get; set; }
    }
}