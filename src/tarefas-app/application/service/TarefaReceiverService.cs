using System;
using Domain.Entities;
using Domain.Interfaces.Adapter.Receiver;
using Domain.Interfaces.Adapter.Sender;
using Domain.Interfaces.Services;
using Model.Interfaces.Repository;



namespace Service.TarefaService {
    public class TarefaReceiverService : ITarefaReceiverService
    {
        private ITarefaReceiverAdapter _tarefaReceiverAdapter;

        public TarefaReceiverService(ITarefaReceiverAdapter tarefaReceiverAdapter)
        {
            _tarefaReceiverAdapter = tarefaReceiverAdapter;
        }

        public void RunWorker() {
            _tarefaReceiverAdapter.RunWorker();
        }
    }
}

