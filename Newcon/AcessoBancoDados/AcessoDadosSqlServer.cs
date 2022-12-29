using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AcessoBancoDados
{
    public class AcessoDadosSqlServer
    {
        public SqlConnection CriarConexao()
        {

            string conexao = "Data Source=DESKTOP-B8IKT1S\\SQLEXPRESS;Initial Catalog=PontoTuristico;Integrated Security=true";
            var sqlConection = new SqlConnection(conexao);
            sqlConection.Open();
            return sqlConection;
        }
    }
}