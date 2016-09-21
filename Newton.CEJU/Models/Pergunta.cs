using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Newton.CJU.Models
{
    public class Pergunta
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Escolha o tipo de assunto")]
        [Required(ErrorMessage = "Seleção do assunto é obrigatória!")]
        public int AssuntoID { get; set; }

        [DisplayName("Identificação das partes")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, digite os nomes das partes.")]
        public string Partes { get; set; }

        [DisplayName("Informe sua dúvida")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, descreva de forma resumida sua dúvida.")]
        public string Duvida { get; set; }

        [DisplayName("Descrição do caso (500 caracteres)")]
        [StringLength(500)]
        [Required(ErrorMessage ="Descrição é obrigatória!")]
        public string Descricao { get; set; }

        public virtual Assunto Assunto { get; set; }


    }
}