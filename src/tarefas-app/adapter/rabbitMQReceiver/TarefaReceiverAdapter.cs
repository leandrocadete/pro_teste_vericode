using Domain.Interfaces.Adapter.Receiver;
using Domain.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Model.Interfaces.Repository;

namespace Adapter.RabbitMQ.Receiver
{
    public class TarefaReceiverAdapter : ITarefaReceiverAdapter
    {
        const string queueName = "add_tarefa_queue";
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaReceiverAdapter(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        
        public void RunWorker()
        {
            System.Console.WriteLine("Worker iniciado ...");
            
            const string queueName = "add_tarefa_queue";

            var factory = new ConnectionFactory { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queueName,
                durable: true, // keep the queue in the rabbitmq server even if it was shutdown
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            // not to give more than one message to a worker at a time
            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var process = System.Diagnostics.Process.GetCurrentProcess();
            Console.Title = $"Worker: {process.Id}";
            Console.WriteLine(" [*] Esperando por novas tarefas.");

            var consumer = new EventingBasicConsumer(channel);

            //Console.WriteLine(" Press [enter] to exit.");

            #region ........ Call Back ...........
            consumer.Received += (model, ea) =>
            {
                System.Console.WriteLine("Call back");
                var body = ea.Body.ToArray();
                string messages = Encoding.UTF8.GetString(body);
                // Console.WriteLine(">{0}", messages);

                // int dots = messages.Split('.').Length - 1;
                // for (int i = 0; i < dots; i++)
                // {
                //     System.Threading.Tasks.Task.Delay(1000).Wait();
                //     Console.Write(".");
                // }
                System.Console.WriteLine("Mensagem Json: {0}", messages);
                var tarefa = JsonSerializer.Deserialize<Tarefa>(messages);
                //System.Console.WriteLine("TarefaRepository == null? {0}", _tarefaRepository == null);
                bool ok = _tarefaRepository.Add(tarefa);
                if(ok)
                    Console.WriteLine($"\n{ok} - Nova tarefa cadastrada!");
                else {
                    Console.WriteLine($"\n{ok} - Não cadastrada!");
                }
                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            #endregion .............................

            channel.BasicConsume(queueName, autoAck: false, consumer: consumer);
            Thread.Sleep(Timeout.Infinite);
        }
    }
}