using Domain.Interfaces.Adapter.Receiver;
using Domain.Entities;

namespace Adapter.RabbitMQ.Receiver
{
    public class TarefaReceiverAddapter : ITarefaReceiverAdapter
    {
        const string queueName = "add_tarefa_queue";
        public bool Add(Tarefa tarefa)
        {
            throw new NotImplementedException("Adapter não implementado");
        }
    }
}