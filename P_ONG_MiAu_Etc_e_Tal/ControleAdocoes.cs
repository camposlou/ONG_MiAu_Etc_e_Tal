using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PONG_MiAu_Etc_e_Tal
{
    internal class ControleAdocoes
    {
        public int NumChip { get; set; }
        public string CPF { get; set; }
        public DateTime DataAdocao { get; set; }

        private static ConexaoBanco Conn = new ConexaoBanco();
        private static SqlConnection Conexaosql = new SqlConnection(Conn.AbrirConexao());

        public ControleAdocoes()
        {

        }
        //Mostra na Tela todos os animais cadastrados
        public void SelectAnimal()
        {
            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select NUM_CHIP, Nome, Raca, Sexo, Familia From Animal ";
            cmd.Connection = Conexaosql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine(">>> ♥ LISTA DO AMOR ♥ <<<\n");
                    Console.WriteLine($"Número do Chip do animal: {reader.GetInt32(0)}");
                    Console.WriteLine($"Nome: {reader.GetString(1)}");
                    Console.WriteLine($"Raça: {reader.GetString(2)}");
                    Console.WriteLine($"Sexo: {reader.GetString(3)}");
                    Console.WriteLine($"Familia: {reader.GetString(4)}");
                    Console.WriteLine();
                }
            }

            cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para continuar");
            Console.ReadKey();
            Conexaosql.Close();
        }
        //Pesquisa o animal pelo CHIP
        public void SelectAnimal(int chip)
        {

            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"Select NUM_CHIP, Nome, Raca, Sexo, Familia From Animal WHERE NUM_CHIP = {chip} ";
            cmd.Connection = Conexaosql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("♥ SUA DOSE DE ALEGRIA DIÁRIA ABAIXO ♥\n");
                    Console.WriteLine($"Número do Chip do animal: {reader.GetInt32(0)}");
                    Console.WriteLine($"Nome: {reader.GetString(1)}");
                    Console.WriteLine($"Raça: {reader.GetString(2)}");
                    Console.WriteLine($"Sexo: {reader.GetString(3)}");
                    Console.WriteLine($"Família: {reader.GetString(4)}");
                    Console.WriteLine();
                }
            }

            cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para continuar");
            Console.ReadKey();
            Conexaosql.Close();
        }
        //Mostra na tela todos os adotantes cadastrados
        public void SelectAdotante()
        {
            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select CPF, Nome, Data_Nasc, Sexo, Telefone, Logradouro, Numero, Complemento, Bairro, CEP, Cidade, UF From Adotante";
            cmd.Connection = Conexaosql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine(">>>LISTA DE ADOTANTES<<<\n");
                    Console.WriteLine($"CPF do Adotante: {reader.GetString(0)}");
                    Console.WriteLine($"Nome: {reader.GetString(1)}");
                    Console.WriteLine($"Data de Nascimento: {reader.GetDateTime(2)}");
                    Console.WriteLine($"Sexo: {reader.GetString(3)}");
                    Console.WriteLine($"Telefone: {reader.GetString(4)}");
                    Console.WriteLine($"Logradouro: {reader.GetString(5)}");
                    Console.WriteLine($"Número: {reader.GetString(6)}");
                    Console.WriteLine($"Complemento: {reader.GetString(7)}");
                    Console.WriteLine($"Bairro: {reader.GetString(8)}");
                    Console.WriteLine($"CEP: {reader.GetString(9)}");
                    Console.WriteLine($"Cidade: {reader.GetString(10)}");
                    Console.WriteLine($"UF: {reader.GetString(11)}");
                    Console.WriteLine();
                }
            }

            cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para continuar");
            Console.ReadKey();
            Conexaosql.Close();
        }
        //Busca o adotante pelo CPF
        public void SelectAdotante(string cpf)
        {
            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"Select CPF, Nome, Data_Nasc, Sexo, Telefone, Logradouro, Numero, Complemento, Bairro, CEP, Cidade, UF From Adotante WHERE CPF = {cpf}";
            cmd.Connection = Conexaosql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine();
                    Console.WriteLine(">>>CANDIDADO(A) Á ADOÇÃO:<<<\n");
                    Console.WriteLine($"CPF do Adotante: {reader.GetString(0)}");
                    Console.WriteLine($"Nome: {reader.GetString(1)}");
                    Console.WriteLine($"Data de Nascimento: {reader.GetDateTime(2)}");
                    Console.WriteLine($"Sexo: {reader.GetString(3)}");
                    Console.WriteLine($"Telefone: {reader.GetString(4)}");
                    Console.WriteLine($"Logradouro: {reader.GetString(5)}");
                    Console.WriteLine($"Número: {reader.GetString(6)}");
                    Console.WriteLine($"Complemento: {reader.GetString(7)}");
                    Console.WriteLine($"Bairro: {reader.GetString(8)}");
                    Console.WriteLine($"CEP: {reader.GetString(9)}");
                    Console.WriteLine($"Cidade: {reader.GetString(10)}");
                    Console.WriteLine($"UF: {reader.GetString(11)}");
                    Console.WriteLine();
                }
            }

            cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para continuar");
            Console.ReadKey();
            Conexaosql.Close();
        }
        public void SelectAdocoes()
        {
            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select a.CPF, a.Nome, a.Telefone, an.NUM_CHIP, an.Nome, an.Familia, c.Data_Adocao From Controle_Adocoes c, Adotante a, Animal an";
            cmd.Connection = Conexaosql;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {

                while (reader.Read())
                {
                    Console.WriteLine("ADOTANTE");
                    Console.WriteLine($"CPF: {reader.GetString(0)}");
                    Console.WriteLine($"Nome: {reader.GetString(1)}");
                    Console.WriteLine($"Telefone: {reader.GetString(2)}\n");
                    Console.WriteLine("ANIMALZINHO ");
                    Console.WriteLine($"Numero do chip do animal: {reader.GetInt32(3)}");
                    Console.WriteLine($"Nome do animal: {reader.GetString(4)}");
                    Console.WriteLine($"Familia: {reader.GetString(5)}");
                    Console.WriteLine($"Data da adoção: {reader.GetDateTime(6).ToString("dd/MM/yyyy")}\n");

                }

            }
            cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para continuar");
            Console.ReadKey();
            Conexaosql.Close();
        }

        public void InsertAdocao()
        {
            Console.WriteLine(">>> REGISTRO DE ADOÇÃO: <<< \n");
            Console.WriteLine("Digite o CPF do adotante: ");
            CPF = Console.ReadLine();
            SelectAdotante(CPF);
            Console.WriteLine("Digite o Numero do CHIP do animal: ");
            NumChip = int.Parse(Console.ReadLine());
            SelectAnimal(NumChip);
            DataAdocao = DateTime.Now;

            Conexaosql.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Controle_Adocoes(NUM_CHIP, CPF, Data_Adocao) VALUES (@Num_chip, @Cpf, @Data_Adocao)";
            cmd.Connection = Conexaosql;

            //Comando vulnerável. Necessita de um tratamento de segurança                                          
            cmd.Parameters.Add(new SqlParameter("@Num_chip", this.NumChip));
            cmd.Parameters.Add(new SqlParameter("@Cpf", this.CPF));
            cmd.Parameters.Add(new SqlParameter("@Data_Adocao", this.DataAdocao));


            Console.WriteLine("Confirma a Adoção?[S/N]:  ");
            string confirma;
            do
            {
                confirma = Console.ReadLine().ToUpper();
                if (confirma == "N")
                    return;

                if (confirma != "S" && confirma != "N")
                {
                    Console.WriteLine("Dado Inválido!!!!");
                    Thread.Sleep(2000);
                }
            } while (confirma != "S" && confirma != "N");

            cmd.ExecuteNonQuery();
            Console.WriteLine();
            Console.WriteLine(" Inserida Adoção com Sucesso!!!!");
            Console.WriteLine();
            Console.WriteLine("Tecle ENTER para sair");
            Console.ReadKey();
            Conexaosql.Close();

        }

        public bool VerifCpfExistente(string dado, string campo, string tabela)
        {
            string queryString = $"SELECT {campo} FROM {tabela} WHERE {campo} = '{dado}'";
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

        public string TratamentoDado(string dado)
        {
            string dadoTratado = dado.Replace(".", "").Replace("-", "").Replace("'", "").Replace("]", "").Replace("[", "");
            return dadoTratado;
        }

    }
}