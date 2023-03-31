using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Domain.DTOs
{
    /// <summary>
    /// Modelo de dados para o conteudo que será
    /// gravado na fila da mensageria do RabbitMQ
    /// </summary>
    public class EmailMessageDTO
    {
        public string? MailTo { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
