using Newton.CJU.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newton.CJU.ViewModel
{
    public class SolicitacaoViewModel
    {
        [DisplayName("Escolha o tipo de assunto")]
        [Required(ErrorMessage = "Seleção do assunto é obrigatória!")]
        public int IdFatoCotidiano { get; set; }

        [DisplayName("Informe sua dúvida")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, descreva de forma resumida sua dúvida.")]
        public string Duvida { get; set; }

        [DisplayName("Identificação das partes")]
        [StringLength(100)]
        [Required(ErrorMessage = "Este campo é obrigatório! Por favor, digite os nomes das partes.")]
        public string IdentificacaoPartes { get; set; }

        [DisplayName("Descrição do caso (500 caracteres)")]
        [StringLength(500)]
        [Required(ErrorMessage = "Descrição é obrigatória!")]
        public string Descricao { get; set; }

        public List<FatoCotidiano> FatosCotidianos { get; set; }
    }
}
