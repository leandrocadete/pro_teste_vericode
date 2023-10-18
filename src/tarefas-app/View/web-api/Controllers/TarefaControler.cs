using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Domain.Interfaces.Services;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefaController : ControllerBase
{
    private ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpPost()]
    public IActionResult Post([FromBody] Tarefa tarefa)
    {

        try
        {
            _tarefaService.Add(tarefa);
            return Ok(new { message = "Adicionado!" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Erro ao tentar adicionar. Motivo: {ex.Message}" });
        }
    }

    [HttpGet("{descricao}")]
    public IActionResult Get(string descricao)
    {
        try
        {
            var r = _tarefaService.Search(new Tarefa() { Descricao = descricao});
            return Ok(r);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = $"Erro ao buscar tarefas {ex.Message}" });
        }
    }
}