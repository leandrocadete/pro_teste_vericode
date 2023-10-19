using System.Data.SQLite;
using Dapper;
using Model.Interfaces.Repository;

namespace Adapter.Repository {
    public class LogRepository : ILogRepository
    {
        string _dbPath = "webapi_log.db";
        private string strConnection = "";
        public LogRepository()
        {
#if DEBUG

            _dbPath = "../../adapter/repository/webapi_log.db";

#endif
            strConnection = $"Data Source={_dbPath};version=3;";
        }
        public void GravarLogErro(string mensagem, string detalhe)
        {
             System.Console.WriteLine("Vai adicionar logErro!");
            string sql = @"
INSERT INTO Logerro
	(Mensagem, Detalhe, DataCadastro) 
VALUES 
	(@Mensagem, @Detalhe, @DataCadastro)
        ";
            try
            {
                using (var conn = new SQLiteConnection(strConnection))
                {
                    conn.Execute(sql, new
                    {
                        Mensagem = mensagem,
                        Detalhe = detalhe,
                        DataCadastro = DateTime.Now.ToOADate()
                    });
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Erro no Add: {0}", ex);
                throw; 
            }
            
        }

        public void GravarLogInfo(string mensagem, string detalhe)
        {
            System.Console.WriteLine("Vai adicionar logInfo!");
            string sql = @"
INSERT INTO LogInfo
	(Mensagem, Detalhe, DataCadastro) 
VALUES 
	(@Mensagem, @Detalhe, @DataCadastro)
        ";
            try
            {
                using (var conn = new SQLiteConnection(strConnection))
                {
                    conn.Execute(sql, new
                    {
                        Mensagem = mensagem,
                        Detalhe = detalhe,
                        DataCadastro = DateTime.Now.ToOADate()
                    });
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Erro no Add: {0}", ex);
                throw; 
            }
        }
    }


}