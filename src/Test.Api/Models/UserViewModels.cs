using System.ComponentModel.DataAnnotations;

namespace Test.Api.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "The property {0} is must")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(40, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
