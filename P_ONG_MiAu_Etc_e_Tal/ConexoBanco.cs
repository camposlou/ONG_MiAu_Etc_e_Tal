using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PONG_MiAu_Etc_e_Tal
{
    internal class ConexaoBanco
    {
        string Conexao = "Data Source=localhost; Initial Catalog=ONG_MiAu_Etc_e_Tal; User Id=sa; Password=MiliBe1@;";

        public ConexaoBanco()
        {

        }
        public string AbrirConexao()
        {
            return Conexao;
        }


    }

}
