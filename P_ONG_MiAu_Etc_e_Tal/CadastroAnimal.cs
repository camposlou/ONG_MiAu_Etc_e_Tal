using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace PONG_MiAu_Etc_e_Tal
{
    internal class CadastroAnimal
    {
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public string Raca { get; set; }
        public string Familia { get; set; }

        private static ConexaoBanco Conn = new ConexaoBanco();
        private static SqlConnection Conexaosql = new SqlConnection(Conn.AbrirConexao());
        public CadastroAnimal()
        {

        }
        public CadastroAnimal(string nome, char sexo, string raca, string familia)
        {
            this.Nome = nome;
            this.Sexo = sexo;
            this.Raca = raca;
            this.Familia = familia;

        }

        public void Cadastro()
        {
            Console.WriteLine(">>> ♥ CADASTRO DO ANIMALZINHO ♥ <<<\n");
            Console.WriteLine("DIGITE AS INFORMAÇÕES DO ANIMAL ABAIXO: ");
            Console.WriteLine("Nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Raça: ");
            Raca = Console.ReadLine();
            Console.WriteLine("Sexo: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Familia: ");
            Familia = Console.ReadLine();


        }
        public override string ToString()
        {
            return "\nNome: " + Nome + "\nSexo: " + Sexo + "\nRaça: " + Raca + "\nFamilia: " + Familia;
        }

        public void InsertTableAnimal()
        {
            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Animal(Nome, Sexo, Raca, Familia) VALUES (@nome, @sexo, @raca, @familia)";

            //Necessita de um tratamento de segurança                                          
            cmd.Parameters.Add(new SqlParameter("@nome", this.Nome));
            cmd.Parameters.Add(new SqlParameter("@sexo", this.Sexo));
            cmd.Parameters.Add(new SqlParameter("@raca", this.Raca));
            cmd.Parameters.Add(new SqlParameter("@familia", this.Familia));

            cmd.Connection = Conexaosql;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Cadastro concluído com sucesso!!!!\n");
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para sair");
            Console.ReadKey();
            Conexaosql.Close();

        }

        public void UpdateCadastro()
        {
            Console.WriteLine("Digite o nome do animal que deseja alterar o cadastro:\n ");
            string alt = Console.ReadLine();
            Console.WriteLine("Novo Nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Raça: ");
            Raca = Console.ReadLine();
            Console.WriteLine("Sexo: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Familia: ");
            Familia = Console.ReadLine();

            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand("UPDATE Animal SET Nome = @nome, Raca = @raca, Sexo = @sexo, " +
                "Familia = @familia WHERE Nome = @novo;");

            SqlParameter novo = new SqlParameter("@novo", System.Data.SqlDbType.VarChar, 50);
            SqlParameter nome = new SqlParameter("@nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter raca = new SqlParameter("@raca", System.Data.SqlDbType.VarChar, 20);
            SqlParameter sexo = new SqlParameter("@sexo", System.Data.SqlDbType.Char, 1);
            SqlParameter familia = new SqlParameter("familia", System.Data.SqlDbType.VarChar, 30);

            novo.Value = alt;
            nome.Value = Nome;
            raca.Value = Raca;
            sexo.Value = Sexo;
            familia.Value = Familia;

            cmd.Parameters.Add(novo);
            cmd.Parameters.Add(nome);
            cmd.Parameters.Add(raca);
            cmd.Parameters.Add(sexo);
            cmd.Parameters.Add(familia);

            cmd.Connection = Conexaosql;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Cadastro alterado com sucesso!!!!\n");
            Console.WriteLine("Tecle ENTER para sair");
            Console.ReadKey();
            Conexaosql.Close();
        }

        public bool VerifChipExistente(int dado, string campo, string tabela)
        {
            string queryString = $"SELECT {campo} FROM {tabela} WHERE {campo} = {dado}";

            try
            {
                SqlCommand command = new SqlCommand(queryString, Conexaosql);

                Conexaosql.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Conexaosql.Close();
                        return true;
                    }
                    else
                    {
                        Conexaosql.Close();
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                Conexaosql.Close();
                Console.WriteLine($"Erro ao acessar o Banco de Dados!!!\n{e.Message}");
                Console.WriteLine("Tecle Enter para continuar....");
                Console.ReadKey();
                return false;
            }



        }


    }
}
