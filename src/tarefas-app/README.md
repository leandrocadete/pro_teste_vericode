# Instruções básicas

## New Class library
`dotnet new classlib`
## Add reference 
`dotnet add service.csproj reference ../model/model.csproj`
`dotnet add web-api.csproj reference ../../adapter/repository/repository.csproj`
## Remove reference 
`dotnet remove service.csproj reference ../model/model.csproj`

## RabbitMQ pelo DOCKER
`sudo docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.12-management`
