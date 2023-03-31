using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.Interfaces.Messages
{
    /// <summary>
    /// Interface para abstração do producer/piblisher
    /// </summary>
    public interface IMessageProducer
    {
        /// <summary>
        /// Método para incluir uma mensagem na fila
        /// </summary>
        void Send(string message);
    }
}
