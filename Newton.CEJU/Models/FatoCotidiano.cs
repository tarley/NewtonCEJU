using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Newton.CJU.Models
{
    public class FatoCotidiano
    {
        public FatoCotidiano()
        {
            Solicitacao = new HashSet<Solicitacao>();
        }

        [Key]
        public int Id { get; set; }

        public int AreaConhecimentoId { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual AreaConhecimento AreaConhecimento { get; set; }
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
}