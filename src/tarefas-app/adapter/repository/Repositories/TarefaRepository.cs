
using System;
using Domain.Entities;
using Model.Interfaces.Repository;
using Dapper;
using System.Data.SQLite;
using System.Data;
using System.Reflection;

namespace Adapter.Repository;

public class TarefaRepository : ITarefaRepository
{
    private const string strConnection = "Data Source=tarefas.db;version=3;";
    public bool Add(Tarefa tarefa)
    {
        System.Console.WriteLine("Vai adicionar!");
        string sql = @"
INSERT INTO Tarefa 
    (Descricao, Status, DataCriacao) 
VALUES 
    (@Descricao, @Status, @DataCriacao);
        ";
        try
        {
            using (var conn = new SQLiteConnection(strConnection))
            {
                conn.Query(sql, new
                {
                    Descricao = tarefa.Descricao,
                    Status = tarefa.Status,
                    DataCriacao = tarefa.DataCriacao.Value.ToString("yyyy-MM-ddTHH:mm:ss:fff")
                });
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Erro no Add: {0}", ex);
            Console.ReadLine();
        }
        return true;
    }

    public IEnumerable<Tarefa> Search(Tarefa tarefa)
    {
        string sql = @"
SELECT Id, Descricao, Status, DataCriacao FROM Tarefa 
WHERE @Descricao like '%' + @Descricao + '%'
        ";
        using (var conn = new SQLiteConnection(strConnection))
        {
            ;
            var ret = conn.Query<Tarefa>(sql, tarefa);
            return ret;
        }
    }
}