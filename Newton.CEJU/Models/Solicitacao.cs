using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public int? HistoricoId { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
        [Required]
        public int AtividadeSemestralId { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Informe sua dúvida")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, descreva de forma resumida sua dúvida.")]
        public string Duvida { get; set; }
        public string Parecer { get; set; }

        public string FatoJuridico { get; set; }
        public string Fundamentacao { get; set; }

        [DisplayName("Identificação das partes")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, digite os nomes das partes.")]
        public string IdentificacaoPartes { get; set; }

        [DisplayName("Descrição do caso (500 caracteres)")]
        [StringLength(500)]
        [Required(ErrorMessage = "Descrição é obrigatória!")]
        public string Descricao { get; set; }
        public string Correcao { get; set; }

        public virtual Situacao Situacao { get; set; }
        public virtual Historico Historico { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual AtividadeSemestral AtividadeSemestral { get; set; }
    }
}