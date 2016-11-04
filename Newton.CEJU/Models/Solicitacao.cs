using Newton.CJU.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Solicitacao
    {
        public Solicitacao()
        {
            this.Historico = new HashSet<Historico>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public SituacaoEnum Situacao { get; set; }
        [Required]
        public Guid UsuarioClienteId { get; set; }
        public Guid? UsuarioAlunoId { get; set; }
        [Required]
        public int AtividadeSemestralId { get; set; }

        public int FatoCotidianoId { get; set; }

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

       // [ForeignKey("UsuarioClienteId")]
        public virtual Usuario UsuarioCliente { get; set; }
        public virtual FatoCotidiano FatoCotidiano { get; set; }
      //  [ForeignKey("UsuarioAlunoId")]
        public virtual Usuario UsuarioAluno { get; set; }

        public virtual ICollection<Historico> Historico { get; set; }
        public virtual AtividadeSemestral AtividadeSemestral { get; set; }
    }
}