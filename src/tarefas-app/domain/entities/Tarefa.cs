namespace Domain.Entities;
public class Tarefa : Entidade
{
    public string Descricao { get; set; }
    public DateTime? DataCriacao { get; set; }
    public EStatus Status { get; set; }


    public enum EStatus {
        Pendente = 1,
        EmExecucao = 2,
        Finalizada = 3,
        Cancelada = 4
    }

}

