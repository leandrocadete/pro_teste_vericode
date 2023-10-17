
using System.ComponentModel;
using Domain.Entities;

namespace Domain.Interfaces.Adapter.Receiver;

public interface ITarefaReceiverAdapter {

    public bool Add(Tarefa tarefa);
}