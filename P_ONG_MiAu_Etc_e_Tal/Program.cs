using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace PONG_MiAu_Etc_e_Tal
{
    internal class Program
    {
        static void Menu()
        {
            do
            {
                int opcMenu = 9;
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("******** ♥ BEM VINDO A NOSSA ONG MIAU ETC E TAL ♥ *******");
                Console.WriteLine();
                Console.WriteLine("*********************MENU**********************");
                Console.WriteLine("|                                             |");
                Console.WriteLine("|  0 - Encerrar:                              |");
                Console.WriteLine("|  1 - Cadastrar novo Adotante:               |");
                Console.WriteLine("|  2 - Cadastrar novo Animal:                 |");
                Console.WriteLine("|  3 - Atualizar Cadastro do Adotante:        |");
                Console.WriteLine("|  4 - Atualizar Cadastro do Animal:          |");
                Console.WriteLine("|  5 - Exibir lista de Adotantes Cadastrados: |");
                Console.WriteLine("|  6 - Exibir lista de Animais Cadastrados:   |");
                Console.WriteLine("|  7 - Inserir/Registrar Adoções:             |");
                Console.WriteLine("|  8 - Exibir lista de Adoções:               |");
                Console.WriteLine("|  Opção:                                     |");
                Console.WriteLine("|_____________________________________________|");
                Console.WriteLine();
                try
                {
                    opcMenu = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                }

                switch (opcMenu)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        CadastroAdotante cdtadot = new CadastroAdotante();
                        cdtadot.Cadastro();
                        cdtadot.InsertTableAdotante();
                        break;
                    case 2:
                        CadastroAnimal cdtanim = new CadastroAnimal();
                        cdtanim.Cadastro();
                        cdtanim.InsertTableAnimal();
                        break;
                    case 3:
                        CadastroAdotante updadot = new CadastroAdotante();
                        updadot.UpdateCadastro();
                        break;
                    case 4:
                        CadastroAnimal updanim = new CadastroAnimal();
                        updanim.UpdateCadastro();
                        break;
                    case 5:
                        ControleAdocoes ctroladt = new ControleAdocoes();
                        ctroladt.SelectAdotante();
                        break;
                    case 6:
                        ControleAdocoes ctrolanim = new ControleAdocoes();
                        ctrolanim.SelectAnimal();
                        break;
                    case 7:
                        ControleAdocoes inseadt = new ControleAdocoes();
                        inseadt.InsertAdocao();
                        break;
                    case 8:
                        ControleAdocoes seladt = new ControleAdocoes();
                        seladt.SelectAdocoes();
                        break;

                }

            } while (true);

        }

        static void Main(string[] args)
        {

            Menu();


        }
    }
}
