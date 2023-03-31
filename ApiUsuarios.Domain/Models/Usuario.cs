using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Models
{
    /// <summary>
    /// Modelo de domínio
    /// </summary>
    public class Usuario
    {
        #region Atributos

        private Guid? _idUsuario;
        private string? _nome;
        private string? _email;
        private string? _telefone;
        private string? _senha;
        private DateTime? _dataHoraCriacao;

        #endregion

        #region Propriedades

        public Guid? IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Email { get => _email; set => _email = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public string? Senha { get => _senha; set => _senha = value; }
        public DateTime? DataHoraCriacao { get => _dataHoraCriacao; set => _dataHoraCriacao = value; }

        #endregion
    }
}
