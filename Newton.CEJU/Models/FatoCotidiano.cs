using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class FatoCotidiano
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AreaConhecimentoId { get; set; }
        [Required]
        public string Nome { get; set; }

        public virtual AreaConhecimento AreaConhecimento { get; set; }
    }
}