using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Solicitacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SituacaoId { get; set; }
        [Required]
        public int HistoricoId { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        [Required]
        public int AtividadeSemestralId { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }
        [Required]
        public string Duvida { get; set; }
        public string Parecer { get; set; }
        public string FatoJuridico { get; set; }
        public string Fundamentacao { get; set; }
        public string IdentificacaoPartes { get; set; }
        public string Descricao { get; set; }
        public string Correcao { get; set; }

        public virtual Situacao Situacao { get; set; }
        public virtual Historico Historico { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual AtividadeSemestral AtividadeSemestral { get; set; }
    }
}