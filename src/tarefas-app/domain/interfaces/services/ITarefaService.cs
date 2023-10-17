using System;
using Domain.Entities;

namespace Domain.Interfaces.Services {
    public interface ITarefaService {
        public bool Add(Tarefa tarefa);
        
        public IEnumerable<Tarefa> Search(Tarefa tarefa);
    }
}