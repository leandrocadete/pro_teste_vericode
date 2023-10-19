
using Domain.Interfaces.Services;
using Domain.Entities;
using Service.TarefaService;
using Domain.Interfaces.Adapter.Receiver;
using Domain.Interfaces.Adapter.Sender;
using Adapter.RabbitMQ.Sender;
using Model.Interfaces.Repository;
using Adapter.Repository;
using Service;

var process = System.Diagnostics.Process.GetCurrentProcess();
Console.Title = $"WebApi: {process.Id}";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddTransient<ITarefaService, TarefaService>()
    .AddTransient<ITarefaSenderAdapter, TarefaSenderAdapter>()    
    .AddTransient<ITarefaRepository, TarefaRepository>()
    
    .AddTransient<ILogRepository, LogRepository>()
    .AddTransient<ILogService, LogService>()
    ;


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x
.AllowAnyHeader()
.AllowAnyOrigin()
.AllowAnyMethod()
);
app.Run();
