using System.ComponentModel.DataAnnotations;

namespace Newton.CJU.ViewModel
{
    public class ProfessorViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}