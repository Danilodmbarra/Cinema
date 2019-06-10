using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Vendas
    {
        public void VenderProdutos(string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes, ref int pLinhaMatrizProdutos)
        {

            string cpf;
            Console.Clear();
            Console.WriteLine("Digite o cpf. XXXXXXXXXXXX");
            cpf = Console.ReadLine();
            int linhaMatrizDeResumo = 0;
            ConfirmarSeOClienteECadastrado(spMatrizDeClientes,cpf, spMatrizDeProdutos, spMatrizDeClientes, ref pLinhaMatrizProdutos);
            OperacaoDeVenda(spMatrizDeProdutos, spMatrizDeClientes, ref pLinhaMatrizProdutos, linhaMatrizDeResumo);

            Console.ReadKey();

        }
        public void OperacaoDeVenda(string[,] spMatrizDeProdutos, string[,] spMatrizClientes, ref int pLinhaMatrizProdutos, int pLinhaMatrizDeResumo)
        {
            GestaoProdutos MetodosParaCadastrar = new GestaoProdutos();
            ConsoleKeyInfo OpcaoParaCadastrar;
            string codigo;
            string[,] resumoParcialDaCompra = new string[100, 4];
            string[] sArrayDeProdutos = new string[spMatrizDeProdutos.GetLength(0)];
            int estoqueDoProduto, precoTotal;
            int troco, dinheiroDocliente, posicao;
            int precoParcial, quantidadeDoProduto;
            ConsoleKeyInfo TeclaDeSair, TeclaDeConfirmacao;
            Console.Clear();
            //resumoParcialDaCompra = {Nome do produto,Quantidade,PrecoSomado,horarioDaCompra}
            do
            {
                Console.WriteLine("Digite o codigo do produto");
                codigo = Console.ReadLine();


                for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                {
                    sArrayDeProdutos[i] = spMatrizDeProdutos[i, 0];

                }

                if (sArrayDeProdutos.Contains(codigo))
                {


                    posicao = Array.IndexOf(sArrayDeProdutos, codigo);
                    Console.WriteLine("Nome: {0}", spMatrizDeProdutos[posicao, 1]);
                    Console.WriteLine("Digite a quantidade do produto");
                    quantidadeDoProduto = Convert.ToInt32(Console.ReadLine());
                    precoTotal = Convert.ToInt32(spMatrizDeProdutos[posicao, 1]);
                    precoParcial = quantidadeDoProduto*precoTotal;
                    estoqueDoProduto = Convert.ToInt32(spMatrizDeProdutos[posicao, 3]);
                    estoqueDoProduto -= quantidadeDoProduto;
                    spMatrizDeProdutos[posicao, 3] = Convert.ToString(estoqueDoProduto);

                    Console.WriteLine("Confirmar  [ENTER]");
                    Console.WriteLine("Cancelar [ESC]");
                    TeclaDeConfirmacao = Console.ReadKey();

                    if (TeclaDeConfirmacao.Key.Equals(ConsoleKey.Enter))
                    {
                        resumoParcialDaCompra= ResumoDaCompra(resumoParcialDaCompra, spMatrizDeProdutos, posicao, pLinhaMatrizDeResumo, precoParcial, quantidadeDoProduto);
                    }
                    else
                    {
                        OperacaoDeVenda(spMatrizDeProdutos, spMatrizClientes, ref pLinhaMatrizProdutos, pLinhaMatrizDeResumo);
                    }


                }
                else
                {
                    Console.WriteLine("Produto Nao encontrado");
                    Console.WriteLine("Deseja Cadastra-lo?\n [s]Sim \n [n]Nao");
                    OpcaoParaCadastrar = Console.ReadKey();

                    if (OpcaoParaCadastrar.Key.Equals(ConsoleKey.S))
                    {
                        MetodosParaCadastrar.CadastrarProduto(ref pLinhaMatrizProdutos, spMatrizDeProdutos);
                    }
                    else if (OpcaoParaCadastrar.Key.Equals(ConsoleKey.N))
                    {
                        OperacaoDeVenda(spMatrizDeProdutos, spMatrizClientes, ref pLinhaMatrizProdutos, pLinhaMatrizDeResumo);
                    }

                }
                Console.WriteLine("Para adicionar mais um produto aperte enter");
                Console.WriteLine("Para finalizar a compra aperte f5");
                TeclaDeSair = Console.ReadKey();

            } while (TeclaDeSair.Key != ConsoleKey.F5);
            Console.WriteLine("Operacao Finalizada");
            ExibirResumoDaCompra(resumoParcialDaCompra);
            

        } 
        public string[,] ResumoDaCompra(string[,] spResumoParcialDacompra, string[,] spMatrizDeProdutos, int posicao, int pLinhaMatrizDeResumo, int pPrecoParcial, int pQuantidadeDoProduto)
        {
            DateTime horarioDaCompra = DateTime.Now;
            for (int indiceColunas = 0; indiceColunas < spResumoParcialDacompra.GetLength(1); indiceColunas++)
            {
                switch (indiceColunas)
                {
                    case 1:
                        {
                            spResumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = spMatrizDeProdutos[posicao, 1];
                            break;
                        }
                    case 2:
                        {
                            spResumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = Convert.ToString(pQuantidadeDoProduto);
                            break;
                        }
                    case 3:
                        {
                            spResumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = Convert.ToString(pPrecoParcial);

                            break;
                        }
                    case 4:
                        {
                            spResumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = Convert.ToString(horarioDaCompra);
                            break;

                        }
                }
            }
            return spResumoParcialDacompra;

        }
        public void ExibirResumoDaCompra(string [,]spResumoParcialDacompra)
        {
            for (int indiceLinhas = 0; indiceLinhas < spResumoParcialDacompra.GetLength(0); indiceLinhas++)
            {
                for (int indiceColunas = 0; indiceColunas < spResumoParcialDacompra.GetLength(1); indiceColunas++)
                {
                    switch (indiceColunas)
                    {
                        case 1:
                            {
                                Console.WriteLine("Nome : {0}", spResumoParcialDacompra[indiceLinhas, indiceColunas]);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Preco Total : R${0}", spResumoParcialDacompra[indiceLinhas, indiceColunas]);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Quantidade : R${0}",spResumoParcialDacompra[indiceLinhas, indiceColunas]);

                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Horario : R${0}", spResumoParcialDacompra[indiceLinhas, indiceColunas]);
                                break;

                            }
                    }
                }
                Console.WriteLine("\n");
            }
        }
        
        public void ListarProdutos(string[,] spMatrizDeProdutos)
        {
            for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
            {
                Console.WriteLine("Lista de Produtos");
                Console.WriteLine("Código de cadastro: {0}", spMatrizDeProdutos[i, 0]);
                Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                Console.WriteLine("Preço: R${0}", spMatrizDeProdutos[i, 2]);
                Console.WriteLine("Quantidade em estoque: {0}", spMatrizDeProdutos[i, 3]);
                Console.WriteLine("Descrição: {0}", spMatrizDeProdutos[i, 4]);
                Console.WriteLine();
            }
        }
        public void ConfirmarSeOClienteECadastrado(string[,] pMatrizDeClientes, string pCpf, string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes,ref int pLinhasMatrizProdutos)
        {
            ConsoleKeyInfo OpcaoParaCadastrar;
            int posicao;
            string[] sArrayCpf = new string[spMatrizDeClientes.GetLength(0)];

            for (int i = 0; i < pMatrizDeClientes.GetLength(0); i++)
            {
                sArrayCpf[i] = spMatrizDeClientes[i, 0];


            }
            if (sArrayCpf.Contains(pCpf))
            {
                posicao = Array.IndexOf(sArrayCpf, pCpf);
                Console.WriteLine("Cliente Cadastrado");
                Console.WriteLine("Nome: {0}", pMatrizDeClientes[posicao, 1]);
                Console.WriteLine("Telefone: {0}", pMatrizDeClientes[posicao, 2]);
                Console.WriteLine("Cidade: {0}", pMatrizDeClientes[posicao, 3]);
            }
            else
            {
                Console.WriteLine("Cliente nao Cadastrado");
                Console.WriteLine("Deseja Cadastra-lo?\n [s]Sim \n [n]Nao");
                OpcaoParaCadastrar = Console.ReadKey();

                if (OpcaoParaCadastrar.Equals(ConsoleKey.S))
                {
                    //CHAMAR CADASTRO
                }
                else if (OpcaoParaCadastrar.Equals(ConsoleKey.N))
                {
                    VenderProdutos(spMatrizDeProdutos, spMatrizDeClientes,ref pLinhasMatrizProdutos);
                }
                //AINDA FALTA COLOCAR TELA DOS PRODUTOS,CALCULAR O PRECO DA COMPRA.
                Console.ReadKey();
            }
        }
    }
}
