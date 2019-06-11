using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Vendas
    {
        public void VenderProdutos(string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes, ref int pLinhaMatrizProdutos,string [,]spMatrizDeComprasFeita)
        {
            
            string cpf;
            Console.Clear();
            Console.WriteLine("Digite o cpf. XXXXXXXXXXXX");
            cpf = Console.ReadLine();
            int linhaMatrizDeResumo = -1;
            ConfirmarSeOClienteECadastrado(spMatrizDeClientes,cpf, spMatrizDeProdutos, spMatrizDeClientes, ref pLinhaMatrizProdutos, spMatrizDeComprasFeita);
            OperacaoDeVenda(spMatrizDeProdutos, spMatrizDeClientes, ref pLinhaMatrizProdutos, linhaMatrizDeResumo, spMatrizDeComprasFeita);

            Console.ReadKey();

        }
        public void OperacaoDeVenda(string[,] spMatrizDeProdutos, string[,] spMatrizClientes, ref int pLinhaMatrizProdutos, int pLinhaMatrizDeResumo,string [,] spMatrizDeComprasFeita)
        {
            GestaoProdutos MetodosParaCadastrar = new GestaoProdutos();
            ConsoleKeyInfo OpcaoParaCadastrar;


            string codigo;
            string[,] resumoParcialDaCompra = new string[100, 4];
            string[] sArrayDeProdutos = new string[spMatrizDeProdutos.GetLength(0)];
            int estoqueDoProduto;
            double precoTotal=0, precoParcial=0;
            int quantidadeDoProduto,posicao;
            ConsoleKeyInfo TeclaDeSair, TeclaDeConfirmacao;
            
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
                    precoTotal = Convert.ToDouble(spMatrizDeProdutos[posicao,2]);
                    Console.WriteLine("Nome: {0}", spMatrizDeProdutos[posicao, 1]);
                    Console.WriteLine("Digite a quantidade do produto");
                    quantidadeDoProduto = Convert.ToInt32(Console.ReadLine());
                    estoqueDoProduto = Convert.ToInt32(spMatrizDeProdutos[posicao, 3]);
                    
                    if(quantidadeDoProduto<= estoqueDoProduto)
                    {
                        estoqueDoProduto -= quantidadeDoProduto;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Erro!\nQuantidade De Produto Indisponivel");
                        
                        OperacaoDeVenda(spMatrizDeProdutos, spMatrizClientes, ref pLinhaMatrizProdutos, pLinhaMatrizDeResumo, spMatrizDeComprasFeita);
                        
                    }

                    spMatrizDeProdutos[posicao, 3] = Convert.ToString(estoqueDoProduto);
                    precoParcial = quantidadeDoProduto * precoTotal;

                    Console.WriteLine("Confirmar  [ENTER]");
                    Console.WriteLine("Cancelar [ESC]");
                    TeclaDeConfirmacao = Console.ReadKey();

                    if (TeclaDeConfirmacao.Key.Equals(ConsoleKey.Enter))
                    {
                        pLinhaMatrizDeResumo++; 
                        ResumoDaCompra(resumoParcialDaCompra, spMatrizDeProdutos, posicao,ref pLinhaMatrizDeResumo, precoParcial, quantidadeDoProduto);
                    }
                    else
                    {
                        OperacaoDeVenda(spMatrizDeProdutos, spMatrizClientes, ref pLinhaMatrizProdutos, pLinhaMatrizDeResumo, spMatrizDeComprasFeita);
                    }


                }
                else
                {
                    Console.WriteLine("Produto Nao encontrado");
                    Console.WriteLine("Deseja Cadastra-lo?\n [s]Sim \n [n]Nao");
                    OpcaoParaCadastrar = Console.ReadKey();

                    if (OpcaoParaCadastrar.Key.Equals(ConsoleKey.S))
                    {
                        MetodosParaCadastrar.CadastrarProduto(ref pLinhaMatrizDeResumo, spMatrizDeProdutos,spMatrizDeComprasFeita);
                    }
                    else if (OpcaoParaCadastrar.Key.Equals(ConsoleKey.N))
                    {
                        OperacaoDeVenda(spMatrizDeProdutos, spMatrizClientes, ref pLinhaMatrizDeResumo, pLinhaMatrizDeResumo,spMatrizDeComprasFeita);
                    }

                }
                Console.WriteLine("Para adicionar mais um produto aperte enter");
                Console.WriteLine("Para finalizar a compra aperte f5");
                TeclaDeSair = Console.ReadKey();

            } while (TeclaDeSair.Key != ConsoleKey.F5);
            Console.WriteLine("Operacao Finalizada");
            ExibirResumoDaCompra(spMatrizDeProdutos, spMatrizClientes, ref pLinhaMatrizProdutos, ref pLinhaMatrizDeResumo, spMatrizDeComprasFeita,resumoParcialDaCompra, precoTotal,precoParcial);
            

        } 
        public string[,] ResumoDaCompra(string[,] resumoParcialDacompra, string[,] spMatrizDeProdutos, int posicao, ref int pLinhaMatrizDeResumo, double pPrecoParcial, int pQuantidadeDoProduto)
        {
            string horarioDacompra;
            horarioDacompra = Convert.ToString(DateTime.Now);
           
            
            for (int indiceLinhas = pLinhaMatrizDeResumo; indiceLinhas < resumoParcialDacompra.GetLength(1); indiceLinhas++)
            {
                for (int indiceColunas = 0; indiceColunas < resumoParcialDacompra.GetLength(1); indiceColunas++)
                {
                    switch (indiceColunas)
                    {
                        case 0:
                            {
                                resumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = spMatrizDeProdutos[posicao, 1];
                                break;
                            }
                        case 1:
                            {
                                resumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = Convert.ToString(pQuantidadeDoProduto);
                                break;
                            }
                        case 2:
                            {
                                resumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = Convert.ToString(pQuantidadeDoProduto);

                                break;
                            }
                        case 3:
                            {
                                resumoParcialDacompra[pLinhaMatrizDeResumo, indiceColunas] = horarioDacompra;
                                break;

                            }
                    }
                }
            }
            
            return resumoParcialDacompra;

        }
        public void ExibirResumoDaCompra(string [,]spMatrizDeProdutos, string[,]spMatrizDeClientes, ref int pLinhaMatrizProdutos,ref int pLinhaMatrizDeResumo, string[,] spMatrizDeComprasFeita, string[,] spResumoParcialDacompra,double pPrecoTotal,double pPrecoParcial)
        {
            Menu MetodosDeInicializacao = new Menu();

            for (int indiceLinhas = 0; indiceLinhas < spResumoParcialDacompra.GetLength(0); indiceLinhas++)
            {
                for (int indiceColunas = 0; indiceColunas < spResumoParcialDacompra.GetLength(1); indiceColunas++)
                {
                     if (spResumoParcialDacompra[indiceLinhas, indiceColunas] != null) { 
                        {
                            switch (indiceColunas)
                            {
                                case 0:
                                    {
                                        Console.WriteLine("Nome : {0}", spResumoParcialDacompra[indiceLinhas, indiceColunas]);
                                        break;
                                    }
                                case 1:
                                    {
                                        Console.WriteLine("Quantidade : {0}", spResumoParcialDacompra[indiceLinhas, indiceColunas]);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Preco Parcial : R${0}", Convert.ToString(pPrecoParcial));

                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("Horario : {0}", spResumoParcialDacompra[indiceLinhas, indiceColunas]);
                                        break;

                                    }
                            }
                        }
                    }
                }
                
               
            }
            Console.WriteLine("Preco Total Da Compra {0}", pPrecoTotal);
            

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
        public void ConfirmarSeOClienteECadastrado(string[,] pMatrizDeClientes, string pCpf, string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes,ref int pLinhasMatrizProdutos,string[,] spMatrizDeComprasFeita)
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
                    VenderProdutos(spMatrizDeProdutos, spMatrizDeClientes,ref pLinhasMatrizProdutos, spMatrizDeComprasFeita);
                }
                //AINDA FALTA COLOCAR TELA DOS PRODUTOS,CALCULAR O PRECO DA COMPRA.
                Console.ReadKey();
            }
        }
    }
}
