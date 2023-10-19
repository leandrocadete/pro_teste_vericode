using Domain.Interfaces.Services;
using Model.Interfaces.Repository;

namespace Service;
public class LogService : ILogService
{
    private ILogRepository _logRepository;

    public LogService(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }
    public void GravarLogErro(string mensagem, string detalhe)
    {
        _logRepository.GravarLogErro(mensagem, detalhe);
    }

    public void GravarLogInfo(string mensagem, string detalhe)
    {
        _logRepository.GravarLogInfo(mensagem, detalhe);
    }
}
