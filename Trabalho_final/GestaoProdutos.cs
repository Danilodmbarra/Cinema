using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class GestaoProdutos
    {
        public void GestaoDeProdutos(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios, string[,] spMatrizDeComprasFeita, ref int pLinhaMatrizClientes)
        {
            ConsoleKeyInfo lertecla;

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
                        CadastrarProduto(ref plinhaMatrizProdutos, spMatrizDeProdutos, spMatrizDeComprasFeita);
                        break;
                    }
                case ConsoleKey.F2:
                    {
                        EditarProduto(plinhaMatrizProdutos, spMatrizDeProdutos,spMatrizDeComprasFeita);
                        break;
                    }
                case ConsoleKey.F3:
                    {
                        ExcluirProduto(plinhaMatrizProdutos, spMatrizDeProdutos, spMatrizDeComprasFeita);
                        break;
                    }
                case ConsoleKey.F4:
                    {
                        ConsultarProduto(pUsuario, pSenha, spMatrizUsuariosSenhas, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                        break;

                    }
                case ConsoleKey.F5:
                    {
                        Menu metodoparaMenuFuncionarios = new Menu();
                        metodoparaMenuFuncionarios.MenuFuncionarios(pUsuario, pSenha, spMatrizUsuariosSenhas, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                        break;
                    }
            }
        }
        public void CadastrarProduto(ref int plinhaMatrizProdutos, string[,] spMatrizDeProdutos, string[,] spMatrizDeComprasFeita)
        {
            plinhaMatrizProdutos += 1;
            string nome, descricao, quantidade = "", preço = "", confirma;
            double preçoteste;
            int codigo, quantidadeteste;

            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - CADASTRO            ");
            Console.WriteLine("==========================================================================");

            codigo = plinhaMatrizProdutos;


            Console.Write("Informe o nome do produto: ");
            nome = Console.ReadLine();


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
                    }
                } while (preçoteste <= 0);
            }
            else
            {
                preço = preçoteste.ToString();
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
                    }
                } while (quantidadeteste < 0);
            }
            else
            {
                quantidade = quantidadeteste.ToString();
            }

            Console.WriteLine();
            Console.Write("Informe a descrição do produto: ");
            descricao = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Deseja confirmar o cadastro do produto com as informações acima? (S/N): ");
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
                spMatrizDeProdutos[plinhaMatrizProdutos, 0] = codigo.ToString();
                spMatrizDeProdutos[plinhaMatrizProdutos, 1] = nome;
                spMatrizDeProdutos[plinhaMatrizProdutos, 2] = preço;
                spMatrizDeProdutos[plinhaMatrizProdutos, 3] = quantidade;
                spMatrizDeProdutos[plinhaMatrizProdutos, 4] = descricao;
                Console.WriteLine();
                Console.WriteLine("Produto cadastrado com sucesso!");
                Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[plinhaMatrizProdutos, 0]);
                Console.WriteLine("Nome: {0}", spMatrizDeProdutos[plinhaMatrizProdutos, 1]);
                Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[plinhaMatrizProdutos, 2]);
                Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[plinhaMatrizProdutos, 3]);
                Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[plinhaMatrizProdutos, 4]);
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
            }
            else if (confirma == "n")
            {
                plinhaMatrizProdutos -= 1;
                Console.WriteLine();
                Console.WriteLine("Cadastro de produto cancelado.");
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
            }
            Console.ReadKey();
        }
    
    
        public void EditarProduto(int plinhaMatrizProdutos, string[,] spMatrizDeProdutos, string [,]spMatrizDeComprasFeita)
        {
            ConsoleKeyInfo lertecla;
            string nome, descricao, quantidade = "", preço = "", editar, cadastrar, alterar;
            int quantidadeteste, conteditar = 0;
            double preçoteste;
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - EDITAR              ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Produtos cadastrados no sistema: ");
            Console.WriteLine();
            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
            {
                if (spMatrizDeProdutos[i, 0] != null)
                {
                    Console.WriteLine("{0} - {1}", spMatrizDeProdutos[i, 0], spMatrizDeProdutos[i, 1]);
                }
            }
            Console.WriteLine();
            Console.Write("Informe o código do produto que deseja editar: ");
            editar = Console.ReadLine();
            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
            {
                if (spMatrizDeProdutos[i, 0] == editar)
                {
                    conteditar++;
                    Console.WriteLine();
                    Console.WriteLine("Produto encontrado! Cadastro atual: ");
                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[i, 0]);
                    Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                    Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[i, 2]);
                    Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[i, 3]);
                    Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[i, 4]);
                    Console.WriteLine();
                    Console.WriteLine("Pressione a tecla referente ao campo que deseja editar deste produto:");
                    Console.WriteLine();
                    Console.WriteLine("F1) Nome");
                    Console.WriteLine();
                    Console.WriteLine("F2) Preço");
                    Console.WriteLine();
                    Console.WriteLine("F3) Quantidade em estoque");
                    Console.WriteLine();
                    Console.WriteLine("F4) Descrição");
                    lertecla = Console.ReadKey();
                    switch (lertecla.Key)
                    {
                        case ConsoleKey.F1:
                            {
                                Console.WriteLine();
                                Console.Write("Informe o novo nome do produto: ");
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
                                    spMatrizDeProdutos[i, 1] = nome;
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
                                Console.Write("Informe o novo preço do produto: ");
                                preçoteste = Convert.ToDouble(Console.ReadLine());
                                if (preçoteste <= 0)
                                {
                                    do
                                    {
                                        Console.WriteLine("O preço do produto não pode ser inferior nem igual a zero!");
                                        Console.WriteLine();
                                        Console.Write("Informe o novo preço do produto: ");
                                        preçoteste = Convert.ToDouble(Console.ReadLine());
                                        if (preçoteste > 0)
                                        {
                                            preço = preçoteste.ToString();
                                        }
                                    } while (preçoteste <= 0);
                                }
                                else
                                {
                                    preço = preçoteste.ToString();
                                }
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
                                    spMatrizDeProdutos[i, 2] = preço;
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
                                        }
                                    } while (quantidadeteste < 0);
                                }
                                else
                                {
                                    quantidade = quantidadeteste.ToString();
                                }
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
                                    spMatrizDeProdutos[i, 3] = quantidade;
                                    Console.WriteLine("Alteração do cadastro realizada com sucesso.");
                                }
                                else if (alterar == "n")
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Alteração do cadastro cancelada.");
                                }
                                break;
                            }
                        case ConsoleKey.F4:
                            {
                                Console.WriteLine();
                                Console.Write("Informe a nova descrição do produto: ");
                                descricao = Console.ReadLine();
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
                                    spMatrizDeProdutos[i, 4] = descricao;
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
                Console.Write("Produto não encontrado. Gostaria de cadastrá-lo? (S/N): ");
                cadastrar = Console.ReadLine().ToLower();
                while (cadastrar != "s" && cadastrar != "n")
                {
                    Console.WriteLine();
                    Console.Write("Opção inválida, favor pressionar a tecla 'S' para ser direcionado à tela de cadastro ou 'N' para retornar ao menu de gestão de produtos: ");
                    cadastrar = Console.ReadLine().ToLower();
                }
                if (cadastrar == "s")
                {
                    CadastrarProduto(ref plinhaMatrizProdutos, spMatrizDeProdutos, spMatrizDeComprasFeita);
                }
                else if (cadastrar == "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                    Console.ReadKey();
                }
            }
            else if (conteditar > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                Console.ReadKey();
            }
        }
        public void ExcluirProduto(int plinhaMatrizProdutos, string[,] spMatrizDeProdutos, string[,] sMatrizDeComprasFeita)
        {
            {
                string excluir, confirmaexcluir;
                int excluircodigo = -1, contexcluir = 0;
                Console.Clear();
                Console.WriteLine("==========================================================================");
                Console.WriteLine("           ÁREA DO FUNCIONÁRIO - GESTÃO DE PRODUTOS - EXCLUIR             ");
                Console.WriteLine("==========================================================================");
                Console.WriteLine("Produtos cadastrados no sistema: ");
                Console.WriteLine();
                for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                {
                    if (spMatrizDeProdutos[i, 0] != null)
                    {
                        Console.WriteLine("{0} - {1}", spMatrizDeProdutos[i, 0], spMatrizDeProdutos[i, 1]);
                    }
                }
                Console.WriteLine();
                Console.Write("Informe o código do produto que deseja excluir: ");
                excluir = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                {
                    if (spMatrizDeProdutos[i, 0] == excluir)
                    {
                        contexcluir++;
                        Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[i, 0]);
                        Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                        Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[i, 2]);
                        Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[i, 3]);
                        Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[i, 4]);
                        Console.WriteLine();
                        Console.Write("Deseja mesmo excluir o cadastro demonstrado? (S/N): ");
                        confirmaexcluir = Console.ReadLine().ToLower();
                        if (confirmaexcluir == "s")
                        {
                            excluircodigo = Convert.ToInt32(excluir);

                            spMatrizDeProdutos[excluircodigo, 0] = null;
                            spMatrizDeProdutos[excluircodigo, 1] = null;
                            spMatrizDeProdutos[excluircodigo, 2] = null;
                            spMatrizDeProdutos[excluircodigo, 3] = null;
                            spMatrizDeProdutos[excluircodigo, 4] = null;
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
                if (contexcluir == 0)
                {
                    Console.WriteLine("Produto não encontrado.");
                    Console.WriteLine();
                    Console.WriteLine("Pressione qualquer tecla para retornar ao menu de gestão de produtos.");
                    Console.ReadKey();
                }
            }
        }
            public void ConsultarProduto(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios,string[,]spMatrizDeComprasFeita,ref int pLinhaMatrizClientes)
        {
            ConsoleKeyInfo lertecla;
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
                Console.WriteLine("F2) Consulta por código");
                Console.WriteLine();
                Console.WriteLine("F3) Listar todos os produtos");
                Console.WriteLine();
                Console.WriteLine("F4) Retornar à área de gestão de produtos");

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
                            Console.WriteLine("Produtos cadastrados no sistema: ");
                            Console.WriteLine();
                            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                            {
                                if (spMatrizDeProdutos[i, 0] != null)
                                {
                                    Console.WriteLine("{0} - {1}", spMatrizDeProdutos[i, 0], spMatrizDeProdutos[i, 1]);
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Informe o nome do produto que deseja consultar: ");
                            nome = Console.ReadLine();
                            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                            {
                                if (spMatrizDeProdutos[i, 1] == nome)
                                {
                                    contnome++;
                                    Console.WriteLine();
                                    Console.WriteLine("Produto encontrado!");
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                                    Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[i, 2]);
                                    Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[i, 3]);
                                    Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[i, 4]);
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
                            Console.WriteLine("Produtos cadastrados no sistema: ");
                            Console.WriteLine();
                            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                            {
                                if (spMatrizDeProdutos[i, 0] != null)
                                {
                                    Console.WriteLine("{0} - {1}", spMatrizDeProdutos[i, 0], spMatrizDeProdutos[i, 1]);
                                }
                            }
                            Console.WriteLine();
                            Console.Write("Informe o codigo do produto que deseja consultar: ");
                            codigoconsulta = Console.ReadLine();

                            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                            {
                                if (spMatrizDeProdutos[i, 0] == codigoconsulta)
                                {
                                    contcodigo++;
                                    Console.WriteLine();
                                    Console.WriteLine("Produto encontrado!");
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                                    Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[i, 2]);
                                    Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[i, 3]);
                                    Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[i, 4]);
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
                            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                            {
                                if (spMatrizDeProdutos[i, 0] != null)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[i, 0]);
                                    Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                                    Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[i, 2]);
                                    Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[i, 3]);
                                    Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[i, 4]);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Pressione qualquer tecla para retornar ao menu de consulta.");
                            Console.ReadKey();
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            GestaoDeProdutos(pUsuario, pSenha,spMatrizUsuariosSenhas, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                            break;
                        }
                }

            } while (lertecla.Key != ConsoleKey.F4);
        }
    }
}
