# pro_teste_vericode
Projeto teste: angular + webApi C# + RabbitMQ

# Características do da Web API
* Dotnet core 6;
* Framework para SQL DApper
* Arquitetura hexagonal
* Possibilita cadastro e consulta de "tarefas"
    a) O cadastro é feito utilizando fila pelo RabbitMQ;
    b) A consulta é feita pela web-api

# Caracteríticas do Worker
* Utiliza as portas padrões 5672 e 15672

# Pré requisitos para executar
* Dotnet 6
* NodeJS 16+

# Execução de Debug

## Projeto Angular 
* Para executar o projeto angular deve-se executar `npm start` dentro da raiz do projeto
e em seguida `npm start` ou `ng serve`
* Como alternativa pode-se executar o script bash `run_angular.sh`

## Projeto Web-Api
* A Api pode ser executada pelo dotnet cli: `dotnet run` na raiz pro projeto (src/tarefas-app/View/web-api/)
* Ou como alternativa executar o script `run_api.sh`

## Projeto worker
* Worker do RabbitMQ pode ser executado pelo dotnet cli: `dotnet run` na raiz pro projeto (src/tarefas-app/View/worker/)
* Ou como alternativa executar o script `run_worker.sh`

## RabbitMQ
* Para executar o rabbitmq foi utiliza a pelo docker 24.0.6
* Existe o script `run_docker_rabbitMQ.sh` como opção
