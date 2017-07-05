using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newton.CJU.Models;
using Newton.CJU.Models.Enum;
using System.Reflection;

namespace Newton.CJU.ViewModel
{
    public class SolicitacaoEdicaoViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Assunto")]
        public string FatoCotidiano { get; set; }

        [DisplayName("Situação")]
        public SituacaoEnum Situacao { get; set; }

        [DisplayName("Dúvida")]
        public string Duvida { get; set; }

        [DisplayName("Partes Envolvidas")]
        public string IdentificacaoPartes { get; set; }

        [DisplayName("Descrição do caso")]
        public string Descricao { get; set; }

        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Parecer")]
        public string Parecer { get; set; }

        [DisplayName("Fundamentação")]
        public string Fundamentacao { get; set; }

        [DisplayName("Correção")]
        public string Correcao { get; set; }

        [DisplayName("Monitor")]
        public string GuidMonitor { get; set; }

        public List<Usuario> Monitores { get; set; }

        public string GetSituacaoDescription()
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = Situacao.GetType().GetField(Situacao.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return Situacao.ToString();
            }
        }
    }
}