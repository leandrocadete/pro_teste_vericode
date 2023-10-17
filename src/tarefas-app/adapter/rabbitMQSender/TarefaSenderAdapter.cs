using Domain.Interfaces.Adapter.Sender;
using Domain.Entities;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace Adapter.RabbitMQ.Sender
{
    public class TarefaSenderAdapter : ITarefaSenderAdapter
    {
        public bool Add(Tarefa tarefa)
        {
            const string queueName = "add_tarefa_queue";
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            string msg;
            channel.QueueDeclare(
                queueName,
                durable: true, // keep the queue in the rabbitmq server even if it was shutdown
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var body = Encoding.UTF8.GetBytes(msg = JsonSerializer.Serialize(tarefa));
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: properties,
                body: body
            );

            Console.WriteLine(" [x] Sent {0}", msg);
            return true;
        }
    }
}