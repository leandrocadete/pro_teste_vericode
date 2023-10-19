

namespace Domain.Interfaces.Services
{
    public interface ILogService
    {
        public void GravarLogErro(string mensagem, string detalhe);
        public void GravarLogInfo(string mensagem, string detalhe);
    }
}