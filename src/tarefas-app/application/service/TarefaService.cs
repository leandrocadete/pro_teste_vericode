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
        private ILogService _logService;        

        public TarefaService(
            ITarefaSenderAdapter tarefaSenderAdapter, 
            ITarefaRepository tarefaRepository,
            ILogService logService
            )
        {
            _tarefaSenderAdapter = tarefaSenderAdapter;
            _tarefaRepository = tarefaRepository;
            _logService = logService;
        }
        /// <summary>
        /// Chama o adapter que envia o objeto para RabbitMQ
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public bool Add(Tarefa tarefa)
        {
            try {
                tarefa.DataCriacao = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff");
                bool r = _tarefaSenderAdapter.Add(tarefa); 
                _logService.GravarLogInfo("Nova tarefa na api", tarefa.Descricao);
                return r;
            } catch (Exception ex) {
                _logService.GravarLogErro("Erro ao adicionar tarefa", ex.ToString());
                throw;
            }
        }
        /// <summary>
        /// Busca direto no banco de dados
        /// </summary>
        /// <param name="tarefa"></param>
        /// <returns></returns>
        public IEnumerable<Tarefa> Search(Tarefa tarefa)
        {
            try {
                return _tarefaRepository.Search(tarefa);
            } catch (Exception ex) {
                _logService.GravarLogErro("Erro ao buscar tarefas", ex.ToString());
                throw;
            }
        }

    }
}

