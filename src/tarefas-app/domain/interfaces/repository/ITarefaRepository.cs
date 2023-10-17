using System;
using Domain.Entities;

namespace Model.Interfaces.Repository
{
    
    public interface ITarefaRepository {
        public bool Add(Tarefa tarefa);

        public IEnumerable<Tarefa> Search(Tarefa tarefa);
    }
}