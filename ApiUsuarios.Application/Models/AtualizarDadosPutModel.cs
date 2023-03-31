using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Application.Models
{
    public class AtualizarDadosPutModel
    {
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,150}$",
            ErrorMessage = "Por favor, informe um nome válido de 6 a 150 caracteres.")]
        public string? Nome { get; set; }

        [RegularExpression("^[0-9]{11}$",
            ErrorMessage = "Por favor, informe um telefone com somente 11 dígitos numéricos.")]
        public string? Telefone { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$",
            ErrorMessage = "Por favor, informe a senha com pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número, 1 símbolo e de 8 a 20 caracteres.")]
        public string? Senha { get; set; }
    }
}
