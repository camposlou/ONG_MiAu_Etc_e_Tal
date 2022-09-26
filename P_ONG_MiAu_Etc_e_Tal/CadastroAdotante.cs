using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PONG_MiAu_Etc_e_Tal
{
    internal class CadastroAdotante
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        private static ConexaoBanco Conn = new ConexaoBanco();
        private static SqlConnection Conexaosql = new SqlConnection(Conn.AbrirConexao());
        public CadastroAdotante()
        {

        }

        public CadastroAdotante(string cpf, string nome, DateTime datanasc, char sexo, string tel, string logr, string num, string compl, string bairro, string cep, string cidd, string uf)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.DataNasc = datanasc;
            this.Sexo = sexo;
            this.Telefone = tel;
            this.Logradouro = logr;
            this.Numero = num;
            this.Complemento = compl;
            this.Bairro = bairro;
            this.CEP = cep;
            this.Cidade = cidd;
            this.UF = uf;
        }

        public void Cadastro()
        {
            ControleAdocoes db = new ControleAdocoes();
            Console.WriteLine("\n>>>DIGITE AS INFORMAÇÕES DO ADOTANTE ABAIXO<<<:\n ");

            do
            {
                Console.WriteLine("CPF: ");
                CPF = db.TratamentoDado(Console.ReadLine());
                if (CPF == "0")
                    return;
                if (!ValidaCPF(CPF))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                    Thread.Sleep(2000);
                }

                bool verifica = db.VerifCpfExistente(CPF, "CPF", "Adotante");
                if (verifica)
                {
                    Console.WriteLine("CPF Já cadastrado!!!");
                    Thread.Sleep(2000);
                    CPF = "";
                }


            } while (!ValidaCPF(CPF));

            Console.WriteLine("Nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Data de Nascimento: ");
            DataNasc = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Sexo: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Telefone: ");
            Telefone = Console.ReadLine();
            Console.WriteLine("Logradouro: ");
            Logradouro = Console.ReadLine();
            Console.WriteLine("Número: ");
            Numero = Console.ReadLine();
            Console.WriteLine("Complemento: ");
            Complemento = Console.ReadLine();
            Console.WriteLine("Bairro: ");
            Bairro = Console.ReadLine();
            Console.WriteLine("CEP: ");
            CEP = Console.ReadLine();
            Console.WriteLine("Cidade: ");
            Cidade = Console.ReadLine();
            Console.WriteLine("UF: ");
            UF = Console.ReadLine();


        }
        public override string ToString()
        {
            return "\nCPF: " + this.CPF + "\nNome: " + this.Nome + "\nDataNasc: " + this.DataNasc + "\nSexo: " + this.Sexo +
                "\nTelefone: " + this.Telefone + "\nLogradouro: " + this.Logradouro + "\nNumero: " + this.Numero +
                "\nComplemento: " + this.Complemento + "\nBairro: " + this.Bairro + "\nCEP: " + this.CEP + "\nCidade: " + this.Cidade + "\nUF: " + this.UF;
        }
        public void InsertTableAdotante()
        {
            try
            {
                Conexaosql.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Adotante(CPF, Nome, Data_Nasc, Sexo, Telefone, Logradouro, Numero," +
                "Complemento, Bairro, CEP, Cidade, UF)VALUES(@cpf, @nome, @datanasc, @sexo, @telefone, @logradouro, @numero, @complemento, @bairro," +
                "@cep, @cidade, @UF)";

                //comando SqlParameter com segurança contra SqlInjection 
                SqlParameter cpf = new SqlParameter("@cpf", System.Data.SqlDbType.VarChar, 11);
                SqlParameter nome = new SqlParameter("@nome", System.Data.SqlDbType.VarChar, 50);
                SqlParameter datanasc = new SqlParameter("@datanasc", System.Data.SqlDbType.Date);
                SqlParameter sexo = new SqlParameter("@sexo", System.Data.SqlDbType.Char, 1);
                SqlParameter telefone = new SqlParameter("@telefone", System.Data.SqlDbType.VarChar, 11);
                SqlParameter logradouro = new SqlParameter("@logradouro", System.Data.SqlDbType.VarChar, 50);
                SqlParameter numero = new SqlParameter("@numero", System.Data.SqlDbType.VarChar, 10);
                SqlParameter complemento = new SqlParameter("@complemento", System.Data.SqlDbType.VarChar, 10);
                SqlParameter bairro = new SqlParameter("@bairro", System.Data.SqlDbType.VarChar, 50);
                SqlParameter cep = new SqlParameter("@cep", System.Data.SqlDbType.VarChar, 20);
                SqlParameter cidade = new SqlParameter("@cidade", System.Data.SqlDbType.VarChar, 50);
                SqlParameter uf = new SqlParameter("@UF", System.Data.SqlDbType.VarChar, 2);

                cpf.Value = CPF;
                nome.Value = Nome;
                datanasc.Value = DataNasc;
                sexo.Value = Sexo;
                telefone.Value = Telefone;
                logradouro.Value = Logradouro;
                numero.Value = Numero;
                complemento.Value = Complemento;
                bairro.Value = Bairro;
                cep.Value = CEP;
                cidade.Value = Cidade;
                uf.Value = UF;


                cmd.Parameters.Add(cpf);
                cmd.Parameters.Add(nome);
                cmd.Parameters.Add(datanasc);
                cmd.Parameters.Add(sexo);
                cmd.Parameters.Add(telefone);
                cmd.Parameters.Add(logradouro);
                cmd.Parameters.Add(numero);
                cmd.Parameters.Add(complemento);
                cmd.Parameters.Add(bairro);
                cmd.Parameters.Add(cep);
                cmd.Parameters.Add(cidade);
                cmd.Parameters.Add(uf);

                cmd.Connection = Conexaosql;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Cadastro concluído com sucesso!!!!\n");
                Console.WriteLine("Tecle ENTER para sair");
                Console.ReadKey();
                Conexaosql.Close();
            }
            catch (Exception ex)
            {
                Conexaosql.Close();
                Console.WriteLine($"NÃO FOI POSSÍVEL CONECTAR AO BANCO DE DADOS \n{ex.Message}\n Tecle ENTER para continuar");
                Console.ReadKey();
            }

        }
        public void UpdateCadastro()
        {
            Console.WriteLine("Digite o nome que deseja alterar o contato:\n ");
            string alt = Console.ReadLine();
            Console.WriteLine("Novo Nome: ");
            Nome = Console.ReadLine();
            Console.WriteLine("Data de Nascimento: ");
            DataNasc = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Sexo: ");
            Sexo = char.Parse(Console.ReadLine());
            Console.WriteLine("Telefone: ");
            Telefone = Console.ReadLine();
            Console.WriteLine("Logradouro: ");
            Logradouro = Console.ReadLine();
            Console.WriteLine("Número: ");
            Numero = Console.ReadLine();
            Console.WriteLine("Complemento: ");
            Complemento = Console.ReadLine();
            Console.WriteLine("Bairro: ");
            Bairro = Console.ReadLine();
            Console.WriteLine("CEP: ");
            CEP = Console.ReadLine();
            Console.WriteLine("Cidade: ");
            Cidade = Console.ReadLine();
            Console.WriteLine("UF: ");
            UF = Console.ReadLine();
            Console.WriteLine();

            Conexaosql.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Adotante SET Nome = @nome, Data_Nasc = @datanasc, Sexo = @sexo, Telefone = @telefone, Logradouro = @logradouro, Numero = @numero, Complemento = @complemento, " +
                "Bairro = @bairro, CEP = @cep, Cidade = @cidade, UF = @UF WHERE Nome = @novo;");

            SqlParameter novo = new SqlParameter("@novo", System.Data.SqlDbType.VarChar, 50);
            SqlParameter nome = new SqlParameter("@nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter datanasc = new SqlParameter("@datanasc", System.Data.SqlDbType.Date);
            SqlParameter sexo = new SqlParameter("@sexo", System.Data.SqlDbType.Char, 1);
            SqlParameter telefone = new SqlParameter("@telefone", System.Data.SqlDbType.VarChar, 11);
            SqlParameter logradouro = new SqlParameter("@logradouro", System.Data.SqlDbType.VarChar, 50);
            SqlParameter numero = new SqlParameter("@numero", System.Data.SqlDbType.VarChar, 10);
            SqlParameter complemento = new SqlParameter("@complemento", System.Data.SqlDbType.VarChar, 10);
            SqlParameter bairro = new SqlParameter("@bairro", System.Data.SqlDbType.VarChar, 50);
            SqlParameter cep = new SqlParameter("@cep", System.Data.SqlDbType.VarChar, 20);
            SqlParameter cidade = new SqlParameter("@cidade", System.Data.SqlDbType.VarChar, 50);
            SqlParameter uf = new SqlParameter("@UF", System.Data.SqlDbType.VarChar, 2);

            novo.Value = alt;
            nome.Value = Nome;
            datanasc.Value = DataNasc;
            sexo.Value = Sexo;
            telefone.Value = Telefone;
            logradouro.Value = Logradouro;
            numero.Value = Numero;
            complemento.Value = Complemento;
            bairro.Value = Bairro;
            cep.Value = CEP;
            cidade.Value = Cidade;
            uf.Value = UF;

            cmd.Parameters.Add(novo);
            cmd.Parameters.Add(nome);
            cmd.Parameters.Add(datanasc);
            cmd.Parameters.Add(sexo);
            cmd.Parameters.Add(telefone);
            cmd.Parameters.Add(logradouro);
            cmd.Parameters.Add(numero);
            cmd.Parameters.Add(complemento);
            cmd.Parameters.Add(bairro);
            cmd.Parameters.Add(cep);
            cmd.Parameters.Add(cidade);
            cmd.Parameters.Add(uf);

            cmd.Connection = Conexaosql;
            cmd.ExecuteNonQuery();
            Console.WriteLine("Cadastro alterado com sucesso!!!!\n");
            Console.WriteLine("Tecle ENTER para sair");
            Console.ReadKey();
            Conexaosql.Close();

        }
        private static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }






    }
}
