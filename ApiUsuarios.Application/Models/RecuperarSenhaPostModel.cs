using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Application.Models
{
    public class RecuperarSenhaPostModel
    {
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]
        [Required(ErrorMessage = "Por favor, informe o email do usuário.")]
        public string? Email { get; set; }
    }
}
