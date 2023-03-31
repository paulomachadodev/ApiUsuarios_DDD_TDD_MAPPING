using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface de repositório específica para Usuário
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario, Guid>
    {

    }
}
