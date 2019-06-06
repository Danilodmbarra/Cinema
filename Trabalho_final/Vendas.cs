using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Vendas
    {
        public void VenderProdutos(string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes,string[,]spMatrizDeVendas)
        {

            string cpf;
            Console.Clear();
            Console.WriteLine("Digite o cpf. XXXXXXXXXxXX");
            cpf = Console.ReadLine();

            ConfirmarSeOClienteECadastrado(spMatrizDeClientes, cpf, spMatrizDeProdutos, spMatrizDeClientes,spMatrizDeVendas);
            ListarProdutos(spMatrizDeProdutos);
            OperacaoDeVenda(spMatrizDeProdutos, spMatrizDeClientes,spMatrizDeVendas);

            Console.ReadKey();

        }
        public void OperacaoDeVenda(string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes,string[,] spMatrizDeVendas)
        {
            ConsoleKeyInfo OpcaoParaCadastrar;
            DateTime HorarioDaCompra = DateTime.Now;
            //matrizDeVendas = produto,quantidade,preco,horario;

            string codigo;
            string[,] resumoDaCompra = new string[100, 3];
            string[] sArrayDeProdutos = new string[spMatrizDeProdutos.GetLength(0)];
            int estoqueDoProduto, precoTotal = 0;
            int troco, dinheiroDocliente, posicao,quantidade=0;


            ConsoleKeyInfo TeclaDeSair;
            Console.Clear();
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

                    Console.WriteLine("Digite a quantidade");
                    quantidade = Convert.ToInt32(Console.ReadLine());



                    precoTotal += Convert.ToInt32(spMatrizDeProdutos[posicao, 2]);
                    estoqueDoProduto = Convert.ToInt32(spMatrizDeProdutos[posicao, 3]);
                    estoqueDoProduto -= quantidade;


                    if(estoqueDoProduto <0)
                    {
                        Console.WriteLine("Quantidade insuficiente no estoque");
                    }
                    else
                    {
                        spMatrizDeProdutos[posicao, 3] = Convert.ToString(estoqueDoProduto);
                        for (int indiceLinhas = 0; indiceLinhas < spMatrizDeVendas.GetLength(0); indiceLinhas++)
                        {
                            for (int indiceColunas = 0; indiceColunas < spMatrizDeVendas.GetLength(1); indiceColunas++)
                            {
                                switch (indiceColunas)
                                {
                                    case 0:
                                        spMatrizDeVendas[indiceLinhas, indiceColunas] = sArrayDeProdutos[posicao];
                                        break;
                                    case 1:
                                        spMatrizDeVendas[indiceLinhas, indiceColunas] = spMatrizDeProdutos[posicao, 2];

                                        break;
                                    case 2:
                                }
                            }
                        }
                        

                    }

                    
                }
                else
                {
                    Console.WriteLine("Produto Nao encontrado");
                    Console.WriteLine("Deseja Cadastra-lo?\n [s]Sim \n [n]Nao");
                    OpcaoParaCadastrar = Console.ReadKey();

                    if (OpcaoParaCadastrar.Equals(ConsoleKey.S))
                    {
                        //Chamar Metodo Para Cadastrar Produto
                    }
                    else if (OpcaoParaCadastrar.Equals(ConsoleKey.N))
                    {
                        OperacaoDeVenda(spMatrizDeProdutos, spMatrizDeClientes,spMatrizDeVendas);
                    }
                }

                Console.WriteLine("Para adicionar mais um produto aperte enter");
                Console.WriteLine("Para finalizar a compra aperte f5");
                TeclaDeSair = Console.ReadKey();
                if(TeclaDeSair.Key == ConsoleKey.F5)
                {
                    Console.WriteLine("Deseja Finalizar");
                    Console.WriteLine("[S]SIM\n [N]Nao");
                    TeclaDeSair = Console.ReadKey();
                    
                }         
                               
            } while (TeclaDeSair.Key != ConsoleKey.S);

            Console.WriteLine("Operacao Finalizada");
            ResumoDaCompra(resumoDaCompra);
            Console.WriteLine("Digite o ");

        }
        public void ResumoDaCompra(string[,] spResumoDacompra)
        {

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
        public void ConfirmarSeOClienteECadastrado(string[,] pMatrizClientes, string pCpf, string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes,string[,]spMatrizDeVendas)
        {
            ConsoleKeyInfo OpcaoParaCadastrar;
            int posicao;
            string[] sArrayCpf = new string[spMatrizDeClientes.GetLength(0)];

            for (int i = 0; i < pMatrizClientes.GetLength(0); i++)
            {
                sArrayCpf[i] = spMatrizDeClientes[i, 0];


            }
            if (sArrayCpf.Contains(pCpf))
            {
                posicao = Array.IndexOf(sArrayCpf, pCpf);
                Console.WriteLine("Cliente Cadastrado");
                Console.WriteLine("Nome: {0}", pMatrizClientes[posicao, 1]);
                Console.WriteLine("Telefone: {0}", pMatrizClientes[posicao, 2]);
                Console.WriteLine("Cidade: {0}", pMatrizClientes[posicao, 3]);
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
                    VenderProdutos(spMatrizDeProdutos, spMatrizDeClientes,spMatrizDeVendas);
                }
                //AINDA FALTA COLOCAR TELA DOS PRODUTOS,CALCULAR O PRECO DA COMPRA.
                Console.ReadKey();
            }
        }
    }
}
