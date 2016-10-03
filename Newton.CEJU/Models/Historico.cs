using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Historico
    {
        public Historico()
        {
            this.Solicitacao = new HashSet<Solicitacao>();
        }

        [Key]
        public int Id { get; set; }
       
        
        [Required]
        public DateTime Data { get; set; }

        
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}