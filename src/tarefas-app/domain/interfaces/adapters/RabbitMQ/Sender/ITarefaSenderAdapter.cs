
using System.ComponentModel;
using Domain.Entities;

namespace Domain.Interfaces.Adapter.Sender;

public interface ITarefaSenderAdapter {

    public bool Add(Tarefa tarefa);
}