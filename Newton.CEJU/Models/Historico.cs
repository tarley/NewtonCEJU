using Newton.CJU.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Historico
    {

        [Key]
        public int Id { get; set; }

        public SituacaoEnum Situacao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        public int SolicitacaoId { get; set; }

        public virtual Solicitacao Solicitacao { get; set; }
    }
}