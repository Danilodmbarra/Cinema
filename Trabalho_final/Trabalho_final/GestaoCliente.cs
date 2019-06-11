﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class GestaoCliente
    {
        public void GestaoDeCliente(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios)
        {
            ConsoleKeyInfo lertecla;

            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("              ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS              ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Escolha a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("F1) Cadastrar novo funcionário.");
            Console.WriteLine();
            Console.WriteLine("F2) Editar cadastro de funcionário.");
            Console.WriteLine();
            Console.WriteLine("F3) Excluir cadastro de funcionário.");
            Console.WriteLine();
            Console.WriteLine("F4) Consultar funcionários cadastrados.");
            Console.WriteLine();
            Console.WriteLine("F5) Retornar à área do administrador.");

            lertecla = Console.ReadKey();

            switch (lertecla.Key)
            {
                case ConsoleKey.F1:
                    {
                        CadastrarFuncionario(spMatrizDeFuncionarios, ref plinhaMatrizFuncionarios);
                        break;
                    }
                case ConsoleKey.F2:
                    {
                        EditarFuncionario(ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                        break;
                    }
                case ConsoleKey.F3:
                    {
                        ExcluirFuncionario(ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                        break;
                    }
                case ConsoleKey.F4:
                    {
                        ConsultarFuncionario(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                        break;

                    }
                case ConsoleKey.F5:
                    {
                        Menu metodoparaMenuFuncionarios = new Menu();
                        metodoparaMenuFuncionarios.MenuFuncionarios(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                        break;
                    }
            }
        }
        public static bool validarCPF(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;


            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");


            if (CPF.Length != 11)
                return false;


            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];


            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;


            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;


            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];


            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;


            Digito = Digito + resto.ToString();


            return CPF.EndsWith(Digito);
        }
        public void CadastrarFuncionario(string[,] spMatrizDeFuncionarios, ref int plinhaMatrizFuncionarios)
        {
            plinhaMatrizFuncionarios += 1;
            string nome, cpfaValidar, telefone, cidade, email;
            int codigo;


            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("            ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - CADASTRO           ");
            Console.WriteLine("==========================================================================");

            codigo = plinhaMatrizFuncionarios;
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0] = codigo.ToString();

            Console.Write("Informe o nome do cliente: ");
            nome = Console.ReadLine();
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1] = nome;
            Console.Write("Informe o CPF do cliente: ");
            cpfaValidar = Console.ReadLine();
            if (validarCPF(cpfaValidar))
            {
                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2] = cpfaValidar;
            }
            else
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("CPF inválido. \nFavor digitar um CPF válido: ");
                    cpfaValidar = Console.ReadLine();
                } while (validarCPF(cpfaValidar) == false);
            }
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2] = cpfaValidar;

            Console.Write("Informe o telefone do cliente: ");
            telefone = Console.ReadLine();
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3] = telefone;
            Console.Write("Informe a cidade do cliente: ");
            cidade = Console.ReadLine();
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 4] = cidade;
            Console.Write("Informe o email do cliente: ");
            email = Console.ReadLine();
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 5] = email;

            Console.WriteLine();
            Console.WriteLine("Cliente cadastrado com sucesso: ");
            Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0]);
            Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1]);
            Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2]);
            Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3]);
            Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 4]);
            Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 5]);
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
            Console.ReadKey();
        }
        public void EditarFuncionario(ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios)
        {
            ConsoleKeyInfo lertecla;
            string nome, telefone, cpfaValidar, editar, cidade, email;
            int conteditar = 0;
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("          ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - EDITAR               ");
            Console.WriteLine("==========================================================================");
            Console.Write("Informe o código de cadastro do cliente que deseja editar: ");
            editar = Console.ReadLine();
            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
            {
                if (spMatrizDeFuncionarios[i, 0] == editar)
                {
                    conteditar++;
                    Console.WriteLine("Cliente encontrado! Cadastro atual: ");
                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0]);
                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1]);
                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 4]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 5]);
                    Console.WriteLine();
                    Console.WriteLine("Pressione a tecla referente ao campo do cadastro que deseja editar:");
                    Console.WriteLine();
                    Console.WriteLine("F1) Nome");
                    Console.WriteLine();
                    Console.WriteLine("F2) CPF");
                    Console.WriteLine();
                    Console.WriteLine("F3) Telefone");
                    Console.WriteLine();
                    Console.WriteLine("F4) Cidade");
                    Console.WriteLine();
                    Console.WriteLine("F5) E-mail");
                    lertecla = Console.ReadKey();
                    Console.WriteLine();

                    switch (lertecla.Key)
                    {
                        case ConsoleKey.F1:
                            {
                                Console.Write("Informe o novo nome a ser atribuído ao cadastro do cliente: ");
                                nome = Console.ReadLine();
                                spMatrizDeFuncionarios[i, 1] = nome;
                                break;
                            }
                        case ConsoleKey.F2:
                            {
                                Console.WriteLine();
                                Console.Write("Informe o novo CPF a ser atribuído ao cadastro do funcionário: ");
                                cpfaValidar = Console.ReadLine();
                                if (validarCPF(cpfaValidar))
                                {
                                    spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2] = cpfaValidar;
                                }
                                else
                                {
                                    do
                                    {
                                        Console.WriteLine();
                                        Console.Write("CPF inválido. \nFavor digitar um CPF válido: ");
                                        cpfaValidar = Console.ReadLine();
                                    } while (validarCPF(cpfaValidar) == false);
                                }
                                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2] = cpfaValidar;
                                break;
                            }
                        case ConsoleKey.F3:
                            {
                                Console.Write("Informe o novo Telefone do funcionário: ");
                                telefone = Console.ReadLine();
                                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3] = telefone;
                                break;
                            }
                        case ConsoleKey.F4:
                            {
                                Console.Write("Informe o novo Cidade do funcionário: ");
                                cidade = Console.ReadLine();
                                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 4] = cidade;
                                break;
                            }
                        case ConsoleKey.F5:
                            {
                                Console.Write("Informe o novo E-mail do funcionário: ");
                                email = Console.ReadLine();
                                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 5] = email;
                                break;
                            }
                    }
                }
            }
            if (conteditar == 0)
            {
                Console.WriteLine("Cadastro de funcionário não encontrado.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                Console.ReadKey();
            }
            else if (conteditar > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Edição do cadastrado realizada com sucesso.\nPressione qualquer tecla para retornar ao menu de gestão de funcionários.");
                Console.ReadKey();
            }
        }
        public void ExcluirFuncionario(ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios)
        {
            string excluir, confirmaexcluir;
            int excluircodigo = -1, contexcluir = 0;
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("            ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - EXCLUIR            ");
            Console.WriteLine("==========================================================================");
            Console.Write("Informe o código de cadastro do cliente que deseja excluir: ");
            excluir = Console.ReadLine();
            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
            {
                if (spMatrizDeFuncionarios[i, 0] == excluir)
                {
                    contexcluir++;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0]);
                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1]);
                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 4]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 5]);
                    Console.WriteLine();
                    Console.WriteLine("Deseja mesmo excluir o cadastro demonstrado? (S/N) ");
                    confirmaexcluir = Console.ReadLine().ToLower();
                    if (confirmaexcluir == "s")
                    {
                        excluircodigo = Convert.ToInt32(excluir);

                        spMatrizDeFuncionarios[excluircodigo, 0] = null;
                        spMatrizDeFuncionarios[excluircodigo, 1] = null;
                        spMatrizDeFuncionarios[excluircodigo, 2] = null;
                        spMatrizDeFuncionarios[excluircodigo, 3] = null;
                        spMatrizDeFuncionarios[excluircodigo, 4] = null;
                        spMatrizDeFuncionarios[excluircodigo, 5] = null;
                        Console.WriteLine();
                        Console.WriteLine("Cadastro excluído.");
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
                    }
                    else if (confirmaexcluir == "n")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Cadastro mantido.");
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Opção inválida. Cadastro mantido.");
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
                    }
                    Console.ReadKey();
                    break;
                }
            }
            if (contexcluir == 0)
            {
                Console.WriteLine("Cadastro de funcionário não encontrado.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de gestão de funcionários.");
                Console.ReadKey();
            }
        }
        public void ConsultarFuncionario(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios)
        {
            ConsoleKeyInfo lertecla;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================================================================");
                Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - CONSULTA            ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("Escolha a opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("F1) Consulta por nome");
                Console.WriteLine();
                Console.WriteLine("F2) Consulta por código");
                Console.WriteLine();
                Console.WriteLine("F3) Consultar por CPF");
                Console.WriteLine();
                Console.WriteLine("F4) Listar todos os funcionários cadastrados.");
                Console.WriteLine();
                Console.WriteLine("F5) Retornar à área de gestão de funcionários.");

                lertecla = Console.ReadKey();

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            string nome;
                            int contnome = 0;

                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("      ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - CONSULTA POR NOME        ");
                            Console.WriteLine("==========================================================================");
                            Console.Write("Informe o nome do cliente: ");
                            nome = Console.ReadLine();

                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 1] == nome)
                                {
                                    contnome++;
                                    Console.WriteLine();
                                    Console.WriteLine("Cliente encontrado!");
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                    Console.WriteLine("Telefone: {0}", spMatrizDeFuncionarios[i, 3]);
                                    Console.WriteLine("Cidade: {0}", spMatrizDeFuncionarios[i, 4]);
                                    Console.WriteLine("E-mail: {0}", spMatrizDeFuncionarios[i, 5]);
                                    Console.WriteLine();
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                    break;
                                }
                            }
                            if (contnome == 0)
                            {
                                Console.WriteLine("Cliente não encontrado.");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            string codigoconsulta;
                            int contcodigo = 0;
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("      ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - CONSULTA POR CÓDIGO      ");
                            Console.WriteLine("==========================================================================");
                            Console.Write("Informe o codigo do cliente: ");
                            codigoconsulta = Console.ReadLine();

                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 0] == codigoconsulta)
                                {
                                    contcodigo++;
                                    Console.WriteLine();
                                    Console.WriteLine("Cliente encontrado!");
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                    Console.WriteLine("Telefone: {0}", spMatrizDeFuncionarios[i, 3]);
                                    Console.WriteLine("Cidade: {0}", spMatrizDeFuncionarios[i, 4]);
                                    Console.WriteLine("E-mail: {0}", spMatrizDeFuncionarios[i, 5]);
                                    Console.WriteLine();
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                    break;
                                }
                            }
                            if (contcodigo == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Cliente não encontrado.");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            string cpfConsulta;
                            int contCpf = 0;
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("       ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - CONSULTA POR CPF        ");
                            Console.WriteLine("==========================================================================");
                            Console.Write("Informe o CPF do cliente: ");
                            cpfConsulta = Console.ReadLine();

                            if (validarCPF(cpfConsulta))
                            {
                                for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                                {
                                    if (spMatrizDeFuncionarios[i, 2] == cpfConsulta)
                                    {
                                        contCpf++;
                                        Console.WriteLine();
                                        Console.WriteLine("Cliente encontrado!");
                                        Console.WriteLine();
                                        Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                        Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                        Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                        Console.WriteLine("Telefone: {0}", spMatrizDeFuncionarios[i, 3]);
                                        Console.WriteLine("Cidade: {0}", spMatrizDeFuncionarios[i, 4]);
                                        Console.WriteLine("E-mail: {0}", spMatrizDeFuncionarios[i, 5]);
                                        Console.WriteLine();
                                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                        break;
                                    }
                                }
                                if (contCpf == 0)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Cliente não encontrado.");
                                    Console.WriteLine();
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                }
                            }
                            else
                                Console.WriteLine("CPF inválido.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("        ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES - LISTAR CLIENTES        ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine();
                            Console.WriteLine("Os seguintes clientes estão cadastrados no sistema:");
                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 0] != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                    Console.WriteLine("Telefone: {0}", spMatrizDeFuncionarios[i, 3]);
                                    Console.WriteLine("Cidade: {0}", spMatrizDeFuncionarios[i, 4]);
                                    Console.WriteLine("E-mail: {0}", spMatrizDeFuncionarios[i, 5]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            GestaoDeCliente(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                            break;
                        }
                }
            } while (lertecla.Key != ConsoleKey.F4);
        }
    }
}

