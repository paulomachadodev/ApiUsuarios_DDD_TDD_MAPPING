using ApiUsuarios.Domain.Interfaces.Messages;
using ApiUsuarios.Infra.Messages.Settings;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Messages.Producers
{
    public class MessageProducer : IMessageProducer
    {
        //atributo
        private readonly RabbitMQSettings? _rabbitMQSettings;

        //construtor para injeção de dependência
        public MessageProducer(IOptions<RabbitMQSettings>? rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        public void Send(string message)
        {
            //capturando o endereço para conexão no servidor da mensageria.
            var factory = new ConnectionFactory { Uri = new Uri(_rabbitMQSettings.Host) };

            //abrindo conexão com o servidor de mensageria
            using (var connection = factory.CreateConnection())
            {
                //acessando a fila do servidor
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _rabbitMQSettings.Queue, //nome da fila
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    //escrevendo a mensagem na fila
                    channel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: _rabbitMQSettings.Queue,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(message) //mensagem
                        );
                }
            }
        }
    }
}



