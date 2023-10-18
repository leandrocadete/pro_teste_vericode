using System;
using Domain.Entities;
using Domain.Interfaces.Adapter.Receiver;
using Domain.Interfaces.Adapter.Sender;
using Domain.Interfaces.Services;
using Model.Interfaces.Repository;



namespace Service.TarefaService {
    public class TarefaService : ITarefaService
    {
        private ITarefaSenderAdapter _tarefaSenderAdapter;
        private ITarefaRepository _tarefaRepository;
        private ITarefaReceiverAdapter _tarefaReceiverAdapter;

        public TarefaService(ITarefaSenderAdapter tarefaSenderAdapter, ITarefaRepository tarefaRepository)
        {
            _tarefaSenderAdapter = tarefaSenderAdapter;
            _tarefaRepository = tarefaRepository;
        }
        /// <summary>
        /// Chama o adapter que envia o objeto para RabbitMQ
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public bool Add(Tarefa tarefa)
        {
            tarefa.DataCriacao = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff");
            return _tarefaSenderAdapter.Add(tarefa); 
        }
        /// <summary>
        /// Busca direto no banco de dados
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public IEnumerable<Tarefa> Search(Tarefa tarefa)
        {
            return _tarefaRepository.Search(tarefa);
        }

    }
}

