
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
    string _dbPath = "tarefas.db";

    private string strConnection = "";
    public TarefaRepository()
    {
        #if DEBUG
        
        _dbPath = "../../adapter/repository/tarefas.db";
        
        #endif

        strConnection = $"Data Source={_dbPath};version=3;";
    }
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
                    DataCriacao = tarefa.DataCriacao
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
SELECT 
     Id, Descricao, Status, DataCriacao
FROM 
    Tarefa 
where 
    Descricao like @Descricao
        ";
        using (var conn = new SQLiteConnection(strConnection))
        {
            Console.WriteLine(sql);
            var ret = conn.Query<Tarefa>(sql, new { Descricao = $"%{tarefa.Descricao}%" });
            System.Console.WriteLine(ret.Count());
            return ret;
        }
    }
}