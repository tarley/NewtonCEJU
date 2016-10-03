using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Situacao
    {
        public Situacao()
        {
            this.Solicitacao = new HashSet<Solicitacao>();
            this.Historico = new HashSet<Historico>();
        }

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
    }
}