using System;
using System.Text;
using System.Text.Json;
using Domain.Entities;
using Domain.Interfaces.Services;
using Model.Interfaces.Repository;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Worker
{
    public class App
    {
        private ITarefaReceiverService _tarefaReceiverService;

        public App(
        ITarefaReceiverService tarefaReceiverService)
        {
            _tarefaReceiverService = tarefaReceiverService;
        }

        public void Run(string[] args)
        {
            _tarefaReceiverService.RunWorker();
           
        }
    }
}