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

        [Required(ErrorMessage = "Seleção da área jurídica é obrigatória!")]
        public int AssuntoID { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, descreva de forma resumida sua dúvida.")]
        public string Duvida { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage ="Descrição é obrigatória!")]
        public string Descricao { get; set; }

        public virtual Assunto Assunto { get; set; }


    }
}