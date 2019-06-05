using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Menu
    {
        public void AberturaDeMenus(int pAutentificacao, string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizProdutos, ref int plinhaMatrizProdutos)
        {
            if (pAutentificacao == 1)
            {
                MenuAdministracao(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
            }
            else if (pAutentificacao == 2)
            {
                MenuFuncionarios(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
            }
        }
        public void MenuAdministracao(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizProdutos, ref int plinhaMatrizProdutos)
        {
            Login MetodosDeInicializacao = new Login();
            bool condicao = true;
            ConsoleKeyInfo lertecla;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================================================================");
                Console.WriteLine("                           ÁREA DO ADMINISTRADOR                          ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("Bem vindo, Administrador! Pressione a tecla referente à opção desejada: ");
                Console.WriteLine();
                Console.WriteLine("F1) Gestão de Funcionários");
                Console.WriteLine();
                Console.WriteLine("F4) Retornar à tela de Login");
                lertecla = Console.ReadKey();

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("              ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS              ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Método em desenvolvimento! Pressione qualquer tecla para retornar ao menu.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            MetodosDeInicializacao.TelaDeAbertura();
                            MetodosDeInicializacao.TelaDeCarregamento();
                            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
                            condicao = false;

                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("                           ÁREA DO ADMINISTRADOR                          ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Opção Inválida. Pressione qualquer tecla para retornar ao menu.");
                            Console.ReadKey();
                            break;
                        }
                }
            } while (condicao);
            MetodosDeInicializacao.TelaDeAbertura();
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
        }
        public void MenuFuncionarios(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizProdutos, ref int plinhaMatrizProdutos)
        {
            Login MetodosDeInicializacao = new Login();
            ConsoleKeyInfo lertecla;
            bool condicao = true;
            do
            {
                Console.Clear();
                Console.WriteLine("==========================================================================");
                Console.WriteLine("                           ÁREA DO FUNCIONÁRIO                            ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("Bem vindo, {0}! Pressione a tecla referente à opção desejada: ", pUsuario);
                Console.WriteLine();
                Console.WriteLine("F1) Gestão de Clientes");
                Console.WriteLine();
                Console.WriteLine("F2) Gestão Financeira");
                Console.WriteLine();
                Console.WriteLine("F3) Gestão de Produtos");
                Console.WriteLine();
                Console.WriteLine("F4) Retornar à tela de Login");
                lertecla = Console.ReadKey();

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("                 ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES                 ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Método em desenvolvimento! Pressione qualquer tecla para retornar ao menu.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("                 ÁREA DO FUNCIONÁRIO - GESTÃO FINANCEIRA                  ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Método em desenvolvimento! Pressione qualquer tecla para retornar ao menu.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            do
                            {
                                GestaoProdutos(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
                            } while (lertecla.Key != ConsoleKey.F5);
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            condicao = false;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("                           ÁREA DO FUNCIONÁRIO                            ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Opção Inválida. Pressione qualquer tecla para retornar ao menu.");
                            Console.ReadKey();
                            break;
                        }
                }
            } while (condicao);

            MetodosDeInicializacao.TelaDeAbertura();
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
        }

        public void GestaoProdutos(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizProdutos, ref int plinhaMatrizProdutos)
        {
            ConsoleKeyInfo lertecla;
            Random nrandom = new Random();

            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                 ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS                 ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Escolha a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("F1) Cadastrar novo produto.");
            Console.WriteLine();
            Console.WriteLine("F2) Editar produto.");
            Console.WriteLine();
            Console.WriteLine("F3) Excluir produto.");
            Console.WriteLine();
            Console.WriteLine("F4) Consultar produto.");
            Console.WriteLine();
            Console.WriteLine("F5) Retornar à área do funcionário.");

            lertecla = Console.ReadKey();

            switch (lertecla.Key)
            {
                case ConsoleKey.F1:
                    {
                        plinhaMatrizProdutos += 1;
                        string nome, descricao, quantidade, preço;
                        double preçoteste;
                        int codigo, quantidadeteste;

                        Console.Clear();
                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - CADASTRO            ");
                        Console.WriteLine("==========================================================================");

                        codigo = plinhaMatrizProdutos;
                        spMatrizProdutos[plinhaMatrizProdutos, 0] = codigo.ToString();

                        Console.Write("Informe o nome do produto: ");
                        nome = Console.ReadLine();
                        spMatrizProdutos[plinhaMatrizProdutos, 1] = nome;

                        Console.WriteLine();
                        Console.Write("Informe o preço do produto: ");
                        preçoteste = Convert.ToDouble(Console.ReadLine());
                        if (preçoteste <= 0)
                        {
                            do
                            {
                                Console.WriteLine("O preço do produto não pode ser inferior nem igual a zero!");
                                Console.WriteLine();
                                Console.Write("Informe o preço do produto: ");
                                preçoteste = Convert.ToDouble(Console.ReadLine());
                                if (preçoteste > 0)
                                {
                                    preço = preçoteste.ToString();
                                    spMatrizProdutos[plinhaMatrizProdutos, 2] = preço;
                                }
                            } while (preçoteste <= 0);
                        }
                        else
                        {
                            preço = preçoteste.ToString();
                            spMatrizProdutos[plinhaMatrizProdutos, 2] = preço;
                        }

                        Console.WriteLine();
                        Console.Write("Informe a quantidade em estoque do produto: ");
                        quantidadeteste = Convert.ToInt32(Console.ReadLine());
                        if (quantidadeteste < 0)
                        {
                            do
                            {
                                Console.WriteLine("A quantidade em estoque do produto não pode ser inferior a zero!");
                                Console.WriteLine();
                                Console.Write("Informe a quantidade em estoque do produto: ");
                                quantidadeteste = Convert.ToInt32(Console.ReadLine());
                                if (quantidadeteste >= 0)
                                {
                                    quantidade = quantidadeteste.ToString();
                                    spMatrizProdutos[plinhaMatrizProdutos, 3] = quantidade;
                                }
                            } while (quantidadeteste < 0);
                        }
                        else
                        {
                            quantidade = quantidadeteste.ToString();
                            spMatrizProdutos[plinhaMatrizProdutos, 3] = quantidade;
                        }

                        Console.WriteLine();
                        Console.Write("Informe a descrição do produto: ");
                        descricao = Console.ReadLine();
                        spMatrizProdutos[plinhaMatrizProdutos, 4] = descricao;

                        Console.WriteLine();
                        Console.WriteLine("Produto registrado com sucesso!");
                        Console.WriteLine("Código de cadastro: {0}", spMatrizProdutos[plinhaMatrizProdutos, 0]);
                        Console.WriteLine("Nome: {0}", spMatrizProdutos[plinhaMatrizProdutos, 1]);
                        Console.WriteLine("Preço: R${0}", spMatrizProdutos[plinhaMatrizProdutos, 2]);
                        Console.WriteLine("Quantidade em estoque: {0}", spMatrizProdutos[plinhaMatrizProdutos, 3]);
                        Console.WriteLine("Descrição: {0}", spMatrizProdutos[plinhaMatrizProdutos, 4]);
                        Console.WriteLine();
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                        Console.ReadKey();
                        break;
                    }
                case ConsoleKey.F2:
                    {
                        string nome, descricao, quantidade, preço, editar;
                        int quantidadeteste, conteditar = 0;
                        double preçoteste;
                        Console.Clear();
                        Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - EDITAR              ");
                        Console.WriteLine("==========================================================================");
                        Console.Write("Informe o código do produto que deseja editar: ");
                        editar = Console.ReadLine();
                        for (int i = 0; i < spMatrizProdutos.GetLength(0); i++)
                        {
                            if (spMatrizProdutos[i, 0] == editar)
                            {
                                conteditar++;
                                Console.WriteLine("Produto encontrado! Cadastro atual: ");
                                Console.WriteLine("Código de cadastro: {0}", spMatrizProdutos[i, 0]);
                                Console.WriteLine("Nome: {0}", spMatrizProdutos[i, 1]);
                                Console.WriteLine("Preço: R${0}", spMatrizProdutos[i, 2]);
                                Console.WriteLine("Quantidade em estoque: {0}", spMatrizProdutos[i, 3]);
                                Console.WriteLine("Descrição: {0}", spMatrizProdutos[i, 4]);
                                Console.WriteLine();
                                Console.WriteLine("Pressione a tecla referente ao campo que deseja editar deste produto:");
                                Console.WriteLine();
                                Console.WriteLine("F1) Nome");
                                Console.WriteLine();
                                Console.WriteLine("F2) Preço");
                                Console.WriteLine();
                                Console.WriteLine("F3) Quantidade em estoque");
                                Console.WriteLine();
                                Console.WriteLine("F4) Descrição.");
                                lertecla = Console.ReadKey();
                                Console.WriteLine();

                                switch (lertecla.Key)
                                {
                                    case ConsoleKey.F1:
                                        {
                                            Console.Write("Informe o novo nome do produto: ");
                                            nome = Console.ReadLine();
                                            spMatrizProdutos[i, 1] = nome;
                                            break;
                                        }
                                    case ConsoleKey.F2:
                                        {
                                            Console.WriteLine();
                                            Console.Write("Informe o novo preço do produto: ");
                                            preçoteste = Convert.ToDouble(Console.ReadLine());
                                            if (preçoteste <= 0)
                                            {
                                                do
                                                {
                                                    Console.WriteLine("O preço do produto não pode ser inferior nem igual a zero!");
                                                    Console.WriteLine();
                                                    Console.Write("Informe o preço do produto: ");
                                                    preçoteste = Convert.ToDouble(Console.ReadLine());
                                                    if (preçoteste > 0)
                                                    {
                                                        preço = preçoteste.ToString();
                                                        spMatrizProdutos[i, 2] = preço;
                                                    }
                                                } while (preçoteste <= 0);
                                            }
                                            else
                                            {
                                                preço = preçoteste.ToString();
                                                spMatrizProdutos[i, 2] = preço;
                                            }
                                            break;
                                        }
                                    case ConsoleKey.F3:
                                        {
                                            Console.Write("Informe a nova quantidade em estoque do produto: ");
                                            quantidadeteste = Convert.ToInt32(Console.ReadLine());
                                            if (quantidadeteste < 0)
                                            {
                                                do
                                                {
                                                    Console.WriteLine("A quantidade em estoque do produto não pode ser inferior a zero!");
                                                    Console.WriteLine();
                                                    Console.Write("Informe a quantidade em estoque do produto: ");
                                                    quantidadeteste = Convert.ToInt32(Console.ReadLine());
                                                    if (quantidadeteste >= 0)
                                                    {
                                                        quantidade = quantidadeteste.ToString();
                                                        spMatrizProdutos[i, 3] = quantidade;
                                                    }
                                                } while (quantidadeteste < 0);
                                            }
                                            else
                                            {
                                                quantidade = quantidadeteste.ToString();
                                                spMatrizProdutos[i, 3] = quantidade;
                                            }
                                            break;
                                        }
                                    case ConsoleKey.F4:
                                        {
                                            Console.Write("Informe a nova descrição do produto: ");
                                            descricao = Console.ReadLine();
                                            spMatrizProdutos[i, 4] = descricao;
                                            break;
                                        }
                                }
                            }
                        }
                        if (conteditar == 0)
                        {
                            Console.WriteLine("Produto não encontrado.");
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            Console.ReadKey();
                        }
                        else if (conteditar > 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Cadastro realizado com sucesso.\nPressione qualquer tecla para retornar ao menu de gestão de produtos.");
                            Console.ReadKey();
                            break;
                        }
                        break;
                    }
                case ConsoleKey.F3:
                    {
                        string excluir, confirmaexcluir;
                        int excluircodigo = -1, conteditar = 0;
                        Console.Clear();
                        Console.WriteLine("==========================================================================");
                        Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - EXCLUIR             ");
                        Console.WriteLine("==========================================================================");
                        Console.Write("Informe o código do produto que deseja excluir: ");
                        excluir = Console.ReadLine();
                        for (int i = 0; i < spMatrizProdutos.GetLength(0); i++)
                        {
                            if (spMatrizProdutos[i, 0] == excluir)
                            {
                                conteditar++;
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Código de cadastro: {0}", spMatrizProdutos[i, 0]);
                                Console.WriteLine("Nome: {0}", spMatrizProdutos[i, 1]);
                                Console.WriteLine("Preço: R${0}", spMatrizProdutos[i, 2]);
                                Console.WriteLine("Quantidade em estoque: {0}", spMatrizProdutos[i, 3]);
                                Console.WriteLine("Descrição: {0}", spMatrizProdutos[i, 4]);
                                Console.WriteLine();
                                Console.WriteLine("Deseja mesmo excluir o cadastro demonstrado? (S/N) ");
                                confirmaexcluir = Console.ReadLine().ToLower();
                                if (confirmaexcluir == "s")
                                {
                                    excluircodigo = Convert.ToInt32(excluir);

                                    spMatrizProdutos[excluircodigo, 0] = null;
                                    spMatrizProdutos[excluircodigo, 1] = null;
                                    spMatrizProdutos[excluircodigo, 2] = null;
                                    spMatrizProdutos[excluircodigo, 3] = null;
                                    spMatrizProdutos[excluircodigo, 4] = null;
                                    Console.WriteLine();
                                    Console.WriteLine("Cadastro excluído.");
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                                }
                                else if (confirmaexcluir == "n")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Cadastro mantido.");
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                                }
                                else
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Opção inválida. Cadastro mantido.");
                                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                                }
                                Console.ReadKey();
                                break;
                            }
                        }
                        if (conteditar == 0)
                        {
                            Console.WriteLine("Produto não encontrado.");
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                            Console.ReadKey();
                        }
                        break;
                    }
                case ConsoleKey.F4:
                    {
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - CONSULTA            ");
                            Console.WriteLine("==========================================================================");
                            Console.WriteLine("Escolha a opção desejada: ");
                            Console.WriteLine();
                            Console.WriteLine("F1) Consulta por nome");
                            Console.WriteLine();
                            Console.WriteLine("F2) Consulta por código.");
                            Console.WriteLine();
                            Console.WriteLine("F3) Listar todos os produtos.");
                            Console.WriteLine();
                            Console.WriteLine("F4) Retornar à área de gestão de produtos.");

                            lertecla = Console.ReadKey();

                            switch (lertecla.Key)
                            {
                                case ConsoleKey.F1:
                                    {
                                        string nome;
                                        int contnome = 0;

                                        Console.Clear();
                                        Console.WriteLine("==========================================================================");
                                        Console.WriteLine("       ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - CONSULTA POR NOME       ");
                                        Console.WriteLine("==========================================================================");
                                        Console.Write("Informe o nome do produto: ");
                                        nome = Console.ReadLine();

                                        for (int i = 0; i < spMatrizProdutos.GetLength(0); i++)
                                        {
                                            if (spMatrizProdutos[i, 1] == nome)
                                            {
                                                contnome++;
                                                Console.WriteLine();
                                                Console.WriteLine("Produto encontrado!");
                                                Console.WriteLine();
                                                Console.WriteLine("Código de cadastro: {0}", spMatrizProdutos[i, 0]);
                                                Console.WriteLine("Nome: {0}", spMatrizProdutos[i, 1]);
                                                Console.WriteLine("Preço: R${0}", spMatrizProdutos[i, 2]);
                                                Console.WriteLine("Quantidade em estoque: {0}", spMatrizProdutos[i, 3]);
                                                Console.WriteLine("Descrição: {0}", spMatrizProdutos[i, 4]);
                                                Console.WriteLine();
                                                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                                break;
                                            }
                                        }
                                        if (contnome == 0)
                                        {
                                            Console.WriteLine("Produto não encontrado.");
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
                                        Console.WriteLine("      ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - CONSULTA POR CÓDIGO      ");
                                        Console.WriteLine("==========================================================================");
                                        Console.Write("Informe o codigo do produto: ");
                                        codigoconsulta = Console.ReadLine();

                                        for (int i = 0; i < spMatrizProdutos.GetLength(0); i++)
                                        {
                                            if (spMatrizProdutos[i, 0] == codigoconsulta)
                                            {
                                                contcodigo++;
                                                Console.WriteLine();
                                                Console.WriteLine("Produto encontrado!");
                                                Console.WriteLine();
                                                Console.WriteLine("Código de cadastro: {0}", spMatrizProdutos[i, 0]);
                                                Console.WriteLine("Nome: {0}", spMatrizProdutos[i, 1]);
                                                Console.WriteLine("Preço: R${0}", spMatrizProdutos[i, 2]);
                                                Console.WriteLine("Quantidade em estoque: {0}", spMatrizProdutos[i, 3]);
                                                Console.WriteLine("Descrição: {0}", spMatrizProdutos[i, 4]);
                                                Console.WriteLine();
                                                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                                break;
                                            }
                                        }
                                        if (contcodigo == 0)
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Produto não encontrado.");
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
                                        Console.WriteLine("        ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - LISTAR PRODUTOS        ");
                                        Console.WriteLine("==========================================================================");
                                        Console.WriteLine();
                                        Console.WriteLine("Os seguintes produtos estão cadastrados no sistema:");
                                        for (int i = 0; i < spMatrizProdutos.GetLength(0); i++)
                                        {
                                            if (spMatrizProdutos[i, 0] != null)
                                            {
                                                Console.WriteLine();
                                                Console.WriteLine("Código de cadastro: {0}", spMatrizProdutos[i, 0]);
                                                Console.WriteLine("Nome: {0}", spMatrizProdutos[i, 1]);
                                                Console.WriteLine("Preço: R${0}", spMatrizProdutos[i, 2]);
                                                Console.WriteLine("Quantidade em estoque: {0}", spMatrizProdutos[i, 3]);
                                                Console.WriteLine("Descrição: {0}", spMatrizProdutos[i, 4]);
                                            }
                                        }
                                        Console.WriteLine();
                                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                                        Console.ReadKey();
                                        break;
                                    }
                                case ConsoleKey.F4:
                                    {
                                        GestaoProdutos(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
                                        break;
                                    }
                            }

                        } while (lertecla.Key != ConsoleKey.F4);
                        break;

                    }
                case ConsoleKey.F5:
                    {
                        MenuFuncionarios(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizProdutos, ref plinhaMatrizProdutos);
                        break;
                    }
            }
        }
    }


    class Login
    {

        public void TelaDeAbertura()
        {
            Console.WriteLine("  ______  __  .__   __.  _______ .___________. _______   ______  __    __  ");
            Console.WriteLine(" /      ||  | |  \" |  | |   ____||           ||   ____| /      ||  |  |  | ");
            Console.WriteLine("|  ,----'|  | |   \"|  | |  |__   `---|  |----`|  |__   |  ,----'|  |__|  | ");
            Console.WriteLine("|  |     |  | |  . `  | |   __|      |  |     |   __|  |  |     |   __   | ");
            Console.WriteLine("|  `----.|  | |  |\"   | |  |____     |  |     |  |____ |  `----.|  |  |  | ");
            Console.WriteLine(" \"______||__| |__| \"__| |_______|    |__|     |_______| \"______||__|  |__| ");
            Console.WriteLine();
            Console.WriteLine();

        }

        public void TelaDeCarregamento()
        {
            Console.WriteLine("Loading");
            for (int i = 0; i < 1; i++)
            {
                Console.Write("|");
                System.Threading.Thread.Sleep(30);

            }
            Console.Clear();
        }

        public void MenuLogin(string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, string[] sArrayDeUsuariosBloquiados, int pTentativasDeLogin, ref int posicaoBloquiados, string[,] spMatrizProdutos, ref int plinhaMatrizProdutos)
        {

            string usuario, senha;
            int valorAutentificao;
            Menu MetodosDoMenu = new Menu();

            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                      BEM VINDO AO SISTEMA CINETECH!                      ");
            Console.WriteLine("==========================================================================");
            Console.Write("USUARIO: ");
            usuario = Console.ReadLine();
            Console.Write("SENHA: ");
            senha = Console.ReadLine();
            valorAutentificao = Autentificacao(usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, sArrayDeUsuariosBloquiados);

            if (valorAutentificao == 0)
            {

                Console.WriteLine("{0} Usuario esta bloqueado contate o administrador", usuario);
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, sArrayDeUsuariosBloquiados, ref posicaoBloquiados, spMatrizProdutos, ref plinhaMatrizProdutos);
            }
            if (valorAutentificao == 1 || (valorAutentificao == 2))
            {
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, sArrayDeUsuariosBloquiados, ref posicaoBloquiados, spMatrizProdutos, ref plinhaMatrizProdutos);
            }

            else if (valorAutentificao == 3)
            {
                --pTentativasDeLogin;

                Console.WriteLine("Senha incorreta. Tente novamente");
                Console.WriteLine("Tentativas {0} de 3", pTentativasDeLogin);

                MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicaoBloquiados, spMatrizProdutos, ref plinhaMatrizProdutos);
                Console.ReadKey();

            }
            else if (valorAutentificao == 4)
            {

                sArrayDeUsuariosBloquiados[posicaoBloquiados] = usuario;
                Console.WriteLine("Usuario Bloqueado");
                Console.ReadKey();
                posicaoBloquiados++;
                MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicaoBloquiados, spMatrizProdutos, ref plinhaMatrizProdutos);
            }
            else
            {
                Console.WriteLine("Usuario Invalido");

            }

            Console.ReadKey();
        }
        public int Autentificacao(string pUsuario, string pSenha, string[] pArrayDeLoginDeUsuarios, string[] psArrayDeUsuariosSenha, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados)
        {

            string admin = "Administrador";
            string adminSenha = "123";
            int posicao, ternarioTentativasDeLogin;



            if (pUsuario == admin && pSenha == adminSenha)
            {
                return 1;

            }
            else if (spArrayDeUsuariosBloquiados.Contains(pUsuario))
            {
                return 0;
            }
            else if (pArrayDeLoginDeUsuarios.Contains(pUsuario))
            {
                posicao = Array.IndexOf(pArrayDeLoginDeUsuarios, pUsuario);
                if (psArrayDeUsuariosSenha[posicao] == pSenha)
                {
                    return 2;

                }
                else
                {
                    return ternarioTentativasDeLogin = (pTentativasDeLogin > 0) ? 3 : 4;

                }
            }
            else
            {
                return 5;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] sArrayDeLoginDeUsuarios = { "Danilo", "Leonardo", "Joao" };
            string[] sArrayDeSenhaDeUsuarios = { "1234", "1111", "1234" };
            string[] sArrayDeUsuariosBloqueados = new string[100];
            string[,] sMatrizProdutos = new string[100, 5];
            int tentativasDeLogin = 3, posicaoBloqueados = 0, linhaMatrizProdutos = -1;

            Login MetodosDeInicializacao = new Login();
            MetodosDeInicializacao.TelaDeAbertura();
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(sArrayDeLoginDeUsuarios, sArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloqueados, tentativasDeLogin, ref posicaoBloqueados, sMatrizProdutos, ref linhaMatrizProdutos);


        }
    }

}
