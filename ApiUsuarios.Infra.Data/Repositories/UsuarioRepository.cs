using ApiUsuarios.Domain.Interfaces.Repositories;
using ApiUsuarios.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Data.Repositories
{
    /// <summary>
    /// Classe de repositório para Usuario
    /// </summary>
    public class UsuarioRepository : BaseRepository<Usuario, Guid>, IUsuarioRepository
    {

    }
}