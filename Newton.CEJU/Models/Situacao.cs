using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Newton.CJU.Models
{
    public class Situacao
    {
        public Situacao()
        {
            Solicitacao = new HashSet<Solicitacao>();
            Historico = new HashSet<Historico>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
        public virtual ICollection<Historico> Historico { get; set; }
    }
}