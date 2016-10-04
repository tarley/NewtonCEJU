using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class AtividadeSemestral
    {
        public AtividadeSemestral()
        {
            this.Solicitacao = new HashSet<Solicitacao>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Usuário")]
        public Guid UsuarioId { get; set; }
        [Required]
        [Display(Name = "Área Conhecimento")]
        public int AreaConhecimentoId { get; set; }

        [Required]
        public int Ano { get; set; }
        [Required]
        [EnumDataType(typeof(SemestreEnum))]
        public SemestreEnum Semestre { get; set; }
        [Required]
        public bool Ativo { get; set; }
        

        public virtual Usuario Usuario { get; set; }
        public virtual AreaConhecimento AreaConhecimento { get; set; }
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
    }
    public enum SemestreEnum
    {
        Primeiro = 1,
        Segundo = 2
    }
}