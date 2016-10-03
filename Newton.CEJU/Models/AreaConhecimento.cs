using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class AreaConhecimento
    {
        public AreaConhecimento()
        {
            this.AtividadeSemestral = new HashSet<AtividadeSemestral>();
            this.FatoCotidiano = new HashSet<FatoCotidiano>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Status")]
        public bool Ativo { get; set; }

        public virtual ICollection<AtividadeSemestral> AtividadeSemestral { get; set; }
        public virtual ICollection<FatoCotidiano> FatoCotidiano { get; set; }
    }
}