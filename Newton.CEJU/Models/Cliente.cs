using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Cliente
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome ")]
        [MinLength(5, ErrorMessage = "O tamanho mínimo do nome são 5 caracteres.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo são 50 caracteres.")]
        [Column(Order = 1)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o CPF ")]
        [MaxLength(11, ErrorMessage = "O tamanho maximo do cfp são 11 digitos.")]
        [Column(Order = 2)]
        public int cpf { get; set; }

        [Required(ErrorMessage = "Digite o e-mail.")]
        [MaxLength(50, ErrorMessage = "O tamanho maximo do cfp são 50 digitos.")]
        [Column(Order = 3)]
        public string email { get; set; }

        [MinLength(5, ErrorMessage = "O tamanho mínimo da senha são 5 caracteres.")]
        [MaxLength(20, ErrorMessage = "O tamanho maximo da senha são 20 digitos.")]
        [Column(Order = 4)]
        public string senha { get; set; }
    }
}