using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class GestaoFuncionarios
    {
        public void GestaoDeFuncionarios(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, ref int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios, string[,] spMatrizDeComprasFeita, ref int pLinhaMatrizClientes)
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
                        CadastrarFuncionario(spMatrizUsuariosSenhas, spMatrizDeFuncionarios, ref plinhaMatrizFuncionarios);
                        break;
                    }
                case ConsoleKey.F2:
                    {
                        EditarFuncionario(ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios,spMatrizUsuariosSenhas);
                        break;
                    }
                case ConsoleKey.F3:
                    {
                        ExcluirFuncionario(ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                        break;
                    }
                case ConsoleKey.F4:
                    {
                        ConsultarFuncionario(pUsuario, pSenha, spMatrizUsuariosSenhas, ref pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                        break;

                    }
                case ConsoleKey.F5:
                    {
                        Menu metodoparaMenuAdministracao = new Menu();
                        metodoparaMenuAdministracao.MenuAdministracao(pUsuario, pSenha, spMatrizUsuariosSenhas, ref pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
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
        public void CadastrarFuncionario(string[,] spMatrizUsuariosSenhas, string[,] spMatrizDeFuncionarios, ref int plinhaMatrizFuncionarios)
        {
            plinhaMatrizFuncionarios += 1;
            string nome, cpfaValidar, cargo;
            string confirma, cpfValidado = "";
            int codigo;


            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("         ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - CADASTRO        ");
            Console.WriteLine("==========================================================================");

            codigo = plinhaMatrizFuncionarios;
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0] = codigo.ToString();

            Console.Write("Informe o nome do funcionário: ");
            nome = Console.ReadLine();
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1] = nome;
            Console.Write("Informe o CPF do funcionário: ");
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

            Console.Write("Informe o cargo do funcionário: ");
            cargo = Console.ReadLine();
            spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3] = cargo;
            cargo = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Deseja confirmar o cadastro do funcionario com as informações acima? (S/N): ");
            confirma = Console.ReadLine().ToLower();

            if (confirma != "s" && confirma != "n")
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Opção inválida, pressione a tecla 'S' para confirmar o cadastro ou 'N' para cancelá-lo: ");
                    confirma = Console.ReadLine().ToLower();

                } while (confirma != "s" && confirma != "n");
            }
            if (confirma == "s")
            {
                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0] = codigo.ToString();
                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1] = nome;
                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2] = cpfValidado;
                spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3] = cargo;
                Console.WriteLine();
                Console.WriteLine("Funcionário cadastrado com sucesso!");
                Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0]);
                Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1]);
                Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2]);
                Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3]);
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
            }
            else if (confirma == "n")
            {
                plinhaMatrizFuncionarios -= 1;
                Console.WriteLine();
                Console.WriteLine("Cadastro de funcionário cancelado.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
            }
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("Funcionário cadastrado com sucesso: ");
            Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0]);
            Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1]);
            Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2]);
            Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3]);
            CadastrarUsuarioSenhaFuncionario(spMatrizUsuariosSenhas, spMatrizDeFuncionarios, ref plinhaMatrizFuncionarios);

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
            Console.ReadKey();
        }
        public string[,] CadastrarUsuarioSenhaFuncionario(string[,] spMatrizUsuariosSenhas, string[,] spMatrizDeFuncionarios, ref int plinhaMatrizFuncionarios)
        {
            string usuario, senha, codigo, palavraChave, confirma= "";

            do
            {
                Console.WriteLine("Digite o Usuario");
                usuario = Console.ReadLine();
                Console.WriteLine("Digite a Senha");
                senha = Console.ReadLine();
                Console.WriteLine("Digite a Palavra Chave");
                palavraChave = Console.ReadLine();
                if (usuario.Equals("") || senha.Equals("") || palavraChave.Equals(""))
                {
                    Console.WriteLine("Campo Vazio ");
                    Console.WriteLine("Tente Novamente");
                }
            } while (usuario.Equals("") || senha.Equals("") || palavraChave.Equals(""));


            if (spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3].Equals("Gerente"))
            {
                codigo = "2";
            }
            else
            {
                codigo = "1";
            }
        
         
            if (confirma == "s")
            {
                for (int IndiceLinhas = 0; IndiceLinhas < spMatrizUsuariosSenhas.GetLength(0); IndiceLinhas++)
                {

                    spMatrizUsuariosSenhas[plinhaMatrizFuncionarios, 0] = usuario;
                    spMatrizUsuariosSenhas[plinhaMatrizFuncionarios, 1] = senha;
                    spMatrizUsuariosSenhas[plinhaMatrizFuncionarios, 2] = codigo;
                    spMatrizUsuariosSenhas[plinhaMatrizFuncionarios, 3] = palavraChave;
                }
            }
            else if (confirma == "n")
            {
                
                Console.WriteLine();
                Console.WriteLine("Cadastro de funcionário cancelado.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
            }
            return spMatrizUsuariosSenhas;
        }
        public void EditarFuncionario(ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios, string [,] spMatrizUsuariosSenhas)
        {
            ConsoleKeyInfo lertecla;
            string nome, cargo, cpfaValidar, cpfValidado = "", editar, cadastrar, alterar;
            int conteditar = 0;
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("          ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - EDITAR         ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Funcionários cadastrados no sistema: ");
            Console.WriteLine();
            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
            {
                if (spMatrizDeFuncionarios[i, 0] != null)
                {
                    Console.WriteLine("{0} - {1}", spMatrizDeFuncionarios[i, 0], spMatrizDeFuncionarios[i, 1]);
                }
            }
            Console.WriteLine();
            Console.Write("Informe o código do cadastro de funcionário que deseja editar: ");
            editar = Console.ReadLine();
            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
            {
                if (spMatrizDeFuncionarios[i, 0] == editar)
                {
                    conteditar++;
                    Console.WriteLine("Funcionário encontrado! Cadastro atual: ");
                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 0]);
                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 1]);
                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3]);
                    Console.WriteLine();
                    Console.WriteLine("Pressione a tecla referente ao campo do cadastro que deseja editar:");
                    Console.WriteLine();
                    Console.WriteLine("F1) Nome");
                    Console.WriteLine();
                    Console.WriteLine("F2) CPF");
                    Console.WriteLine();
                    Console.WriteLine("F3) Cargo");
                    lertecla = Console.ReadKey();
                    switch (lertecla.Key)
                    {
                        case ConsoleKey.F1:
                            {
                                Console.WriteLine();
                                Console.Write("Informe o novo nome a ser atribuído ao cadastro do funcionário: ");
                                nome = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Deseja confirmar a alteração realizada acima? (S/N): ");
                                alterar = Console.ReadLine().ToLower();
                                while (alterar != "s" && alterar != "n")
                                {
                                    Console.WriteLine();
                                    Console.Write("Opção inválida, pressione a tecla 'S' para confirmar a alteração acima ou 'N' para cancelar: ");
                                    alterar = Console.ReadLine().ToLower();
                                }
                                if (alterar == "s")
                                {
                                    Console.WriteLine();
                                    spMatrizDeFuncionarios[i, 1] = nome;
                                    Console.WriteLine("Alteração do cadastro realizada com sucesso.");
                                }
                                else if (alterar == "n")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Alteração do cadastro cancelada.");
                                }
                                break;
                            }
                        case ConsoleKey.F2:
                            {
                                Console.WriteLine();
                                Console.Write("Informe o novo CPF a ser atribuído ao cadastro do funcionário: ");
                                cpfaValidar = Console.ReadLine();
                                if (validarCPF(cpfaValidar))
                                {
                                    cpfValidado = cpfaValidar;
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
                                cpfValidado = cpfaValidar;
                                Console.WriteLine();
                                Console.Write("Deseja confirmar a alteração realizada acima? (S/N): ");
                                alterar = Console.ReadLine().ToLower();
                                while (alterar != "s" && alterar != "n")
                                {
                                    Console.WriteLine();
                                    Console.Write("Opção inválida, pressione a tecla 'S' para confirmar a alteração acima ou 'N' para cancelar: ");
                                    alterar = Console.ReadLine().ToLower();
                                }
                                if (alterar == "s")
                                {
                                    Console.WriteLine();
                                    spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 2] = cpfValidado;
                                    Console.WriteLine("Alteração do cadastro realizada com sucesso.");
                                }
                                else if (alterar == "n")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Alteração do cadastro cancelada.");
                                }
                                break;
                            }
                        case ConsoleKey.F3:
                            {
                                Console.WriteLine();
                                Console.Write("Informe o novo cargo do funcionário: ");
                                cargo = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Deseja confirmar a alteração realizada acima? (S/N): ");
                                alterar = Console.ReadLine().ToLower();
                                while (alterar != "s" && alterar != "n")
                                {
                                    Console.WriteLine();
                                    Console.Write("Opção inválida, pressione a tecla 'S' para confirmar a alteração acima ou 'N' para cancelar: ");
                                    alterar = Console.ReadLine().ToLower();
                                }
                                if (alterar == "s")
                                {
                                    Console.WriteLine();
                                    spMatrizDeFuncionarios[plinhaMatrizFuncionarios, 3] = cargo;
                                    Console.WriteLine("Alteração do cadastro realizada com sucesso.");
                                }
                                else if (alterar == "n")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Alteração do cadastro cancelada.");
                                }
                                break;
                            }
                        default:
                            {
                                Console.WriteLine();
                                Console.Write("Opção inválida.");
                                break;
                            }
                    }
                }
            }
            if (conteditar == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Funcionário não encontrado no sistema. Gostaria de cadastrá-lo? (S/N): ");
                cadastrar = Console.ReadLine().ToLower();
                while (cadastrar != "s" && cadastrar != "n")
                {
                    Console.WriteLine();
                    Console.Write("Opção inválida, favor pressionar a tecla 'S' para ser direcionado à tela de cadastro ou 'N' para retornar ao menu de gestão de funcionários: ");
                    cadastrar = Console.ReadLine().ToLower();
                }
                if (cadastrar == "s")
                {
                    CadastrarFuncionario(spMatrizUsuariosSenhas, spMatrizDeFuncionarios, ref plinhaMatrizFuncionarios);
                }
                else if (cadastrar == "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
                    Console.ReadKey();
                }
            }
            else if (conteditar > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de funcionários.");
                Console.ReadKey();
            }
        }
        public void ExcluirFuncionario(ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios)
        {
            string excluir, confirmaexcluir;
            int excluircodigo = -1, contexcluir = 0;
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("        ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - EXCLUIR          ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Funcionários cadastrados no sistema: ");
            Console.WriteLine();
            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
            {
                if (spMatrizDeFuncionarios[i, 0] != null)
                {
                    Console.WriteLine("{0} - {1}", spMatrizDeFuncionarios[i, 0], spMatrizDeFuncionarios[i, 1]);
                }
            }
            Console.WriteLine();
            Console.Write("Informe o código de cadastro do funcionário que deseja excluir: ");
            excluir = Console.ReadLine();
            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
            {
                if (spMatrizDeFuncionarios[i, 0] == excluir)
                {
                    contexcluir++;
                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[i, 3]);
                    Console.WriteLine();
                    Console.WriteLine("Deseja mesmo excluir o cadastro demonstrado? (S/N): ");
                    confirmaexcluir = Console.ReadLine().ToLower();
                    if (confirmaexcluir == "s")
                    {
                        excluircodigo = Convert.ToInt32(excluir);

                        spMatrizDeFuncionarios[excluircodigo, 0] = null;
                        spMatrizDeFuncionarios[excluircodigo, 1] = null;
                        spMatrizDeFuncionarios[excluircodigo, 2] = null;
                        spMatrizDeFuncionarios[excluircodigo, 3] = null;
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
                Console.WriteLine();
                Console.WriteLine("Cadastro de funcionário não encontrado.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de gestão de funcionários.");
                Console.ReadKey();
            }
        }
        public void ConsultarFuncionario(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, ref int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios,string [,] spMatrizDeComprasFeita,ref int pLinhaMatrizClientes)
        {
            ConsoleKeyInfo lertecla;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================================================================");
                Console.WriteLine("        ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - CONSULTA         ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("Escolha a opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("F1) Consulta por nome");
                Console.WriteLine();
                Console.WriteLine("F2) Consulta por CPF");
                Console.WriteLine();
                Console.WriteLine("F3) Listar todos os funcionários cadastrados");
                Console.WriteLine();
                Console.WriteLine("F4) Retornar à área de gestão de funcionários");

                lertecla = Console.ReadKey();

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            string nome;
                            int contnome = 0;

                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("    ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - CONSULTA POR NOME    ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Funcionários cadastrados no sistema: ");
                            Console.WriteLine();
                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 0] != null)
                                {
                                    Console.WriteLine("{0} - {1}", spMatrizDeFuncionarios[i, 0], spMatrizDeFuncionarios[i, 1]);
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Informe o nome do funcionário cujo cadastro deseja consultar: ");
                            nome = Console.ReadLine();
                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 1] == nome)
                                {
                                    contnome++;
                                    Console.WriteLine();
                                    Console.WriteLine("Funcionário encontrado!");
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[i, 3]);
                                    Console.WriteLine();
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                    break;
                                }
                            }
                            if (contnome == 0)
                            {
                                Console.WriteLine("Funcionário não encontrado.");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            string cpfconsulta;
                            int contcpf = 0;
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("     ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - CONSULTA POR CPF    ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Funcionários cadastrados no sistema: ");
                            Console.WriteLine();
                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 0] != null)
                                {
                                    Console.WriteLine("{0} - CPF: {1}", spMatrizDeFuncionarios[i, 1], spMatrizDeFuncionarios[i, 2]);
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Informe o CPF do funcionário cujo cadastro deseja consultar: ");
                            cpfconsulta = Console.ReadLine();
                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 2] == cpfconsulta)
                                {
                                    contcpf++;
                                    Console.WriteLine();
                                    Console.WriteLine("Funcionário encontrado!");
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[i, 3]);
                                    Console.WriteLine();
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                    break;
                                }
                            }
                            if (contcpf == 0)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Funcionário não encontrado.");
                                Console.WriteLine();
                                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("   ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS - LISTAR FUNCIONÁRIOS   ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine();
                            Console.WriteLine("Os seguintes funcionários estão cadastrados no sistema:");
                            for (int i = 0; i < spMatrizDeFuncionarios.GetLength(0); i++)
                            {
                                if (spMatrizDeFuncionarios[i, 0] != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeFuncionarios[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeFuncionarios[i, 1]);
                                    Console.WriteLine("CPF: {0}", spMatrizDeFuncionarios[i, 2]);
                                    Console.WriteLine("Cargo: {0}", spMatrizDeFuncionarios[i, 3]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            GestaoDeFuncionarios(pUsuario, pSenha, spMatrizUsuariosSenhas,ref pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                            break;
                        }
                }
            } while (lertecla.Key != ConsoleKey.F4);
        }
    }
}

