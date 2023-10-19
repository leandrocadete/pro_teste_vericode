

using Microsoft.VisualBasic;

namespace Model.Interfaces.Repository
{

    public interface ILogRepository
    {
        void GravarLogErro(string mensagem, string detalhe);
        void GravarLogInfo(string mensagem, string detalhe);
    }

}