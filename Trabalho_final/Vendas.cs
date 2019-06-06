using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Vendas
    {
        public void VenderProdutos(string[,] spMatrizDeProdutos, string[,] spMatrizDeClientes)
        {

            string cpf;
            Console.Clear();
            Console.WriteLine("Digite o cpf. XXX.XXXX.XXX-XX");
            cpf = Console.ReadLine();

            ConfirmarSeOClienteECadastrado(spMatrizDeClientes, cpf);
            ListarProdutos(spMatrizDeProdutos);
            OperacaoDeVenda(spMatrizDeProdutos, spMatrizDeClientes);

            Console.ReadKey();

        }
        public void OperacaoDeVenda(string[,] spMatrizDeProdutos, string[,] spMatrizClientes)
        {
            string codigo;
            int estoqueDoProduto, precoTotal = 0, troco, dinheiroDocliente;
            string[,] resumoDaCompra = new string[100, 3];

            ConsoleKeyInfo TeclaDeSair;
            Console.Clear();
            do
            {

                Console.WriteLine("Digite o codigo do produto");

                codigo = Console.ReadLine();

                for (int i = 0; i < spMatrizDeProdutos.GetLength(0); i++)
                {
                    if (spMatrizDeProdutos[i, 0] == codigo)
                    {

                        Console.WriteLine("Nome: {0}", spMatrizDeProdutos[i, 1]);
                        precoTotal += Convert.ToInt32(spMatrizDeProdutos[i, 2]);
                        estoqueDoProduto = Convert.ToInt32(spMatrizDeProdutos[i, 3]);
                        estoqueDoProduto -= 1;
                        spMatrizDeProdutos[i, 3] = Convert.ToString(estoqueDoProduto);
                    }
                }
                Console.WriteLine("Para adicionar mais um produto aperte enter");
                Console.WriteLine("Para finalizar a compra aperte f5");
                TeclaDeSair = Console.ReadKey();









            } while (TeclaDeSair.Key != ConsoleKey.F5);
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
        public void ConfirmarSeOClienteECadastrado(string[,] pMatrizClientes, string pCpf)
        {


            for (int i = 0; i < pMatrizClientes.GetLength(0); i++)
            {
                if (pMatrizClientes[i, 0] == pCpf)
                {
                    Console.WriteLine("Cliente Cadastrado");
                    Console.WriteLine("Nome: {0}", pMatrizClientes[i, 1]);
                    Console.WriteLine("Telefone: {0}", pMatrizClientes[i, 2]);
                    Console.WriteLine("Cidade: {0}", pMatrizClientes[i, 3]);
                }
                else
                {
                    //CHAMAR CADASTRO DE CLIENTE
                }
            }
            //AINDA FALTA COLOCAR TELA DOS PRODUTOS,CALCULAR O PRECO DA COMPRA.
            Console.ReadKey();
        }
    }
}
