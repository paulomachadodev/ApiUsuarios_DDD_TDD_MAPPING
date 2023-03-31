using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Messages.Settings
{
    /// <summary>
    /// Modelo de dados para capturas as configurações
    /// definidas no arquivo /appsettings.json
    /// </summary>
    public class RabbitMQSettings
    {
        public string? Host { get; set; }
        public string? Queue { get; set; }
    }
}
