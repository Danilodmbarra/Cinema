using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{

    class Menu
    {
        public void AberturaDeMenus(int pAutentificacao, string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes)
        {
            if (pAutentificacao == 1)
            {
                MenuAdministracao(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes);
            }
            else if (pAutentificacao == 2)
            {
                MenuFuncionarios(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes);
            }
        }
        public void MenuAdministracao(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes)
        {
            Login MetodosDeInicializacao = new Login();
            ConsolePersonalizado Templates = new ConsolePersonalizado();
            bool condicao = true;
            ConsoleKeyInfo lertecla;
            do
            {
                lertecla = Templates.MenuAreaDoAdministrador();

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            Templates.MenuAreaDeGestaoDeFuncionarios();
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            Templates.TelaDeAbertura();
                            MetodosDeInicializacao.TelaDeCarregamento();
                            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes);
                            condicao = false;

                            break;
                        }
                    default:
                        {
                            Templates.MenuAreaDoAdministradorTeclaInvalida();
                            break;
                        }
                }
            } while (condicao);

            Templates.TelaDeAbertura();
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes);
        }
        public void MenuFuncionarios(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes)
        {
            Login MetodosDeInicializacao = new Login();
            ConsoleKeyInfo lertecla;
            ConsolePersonalizado Templates = new ConsolePersonalizado();
            bool condicao = true;
            do
            {
                lertecla = Templates.MenuAreaDoFuncionario(pUsuario);

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            Templates.MenuAreaDeGestaoDeClientes();
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            Templates.MenuAreaDeGestaoFinanceira();
                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            GestaoProdutos metodoParaGestaoDeProdutos = new GestaoProdutos();                            
                            do
                            {
                                metodoParaGestaoDeProdutos.GestaoDeProdutos(pUsuario, pSenha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes);
                            } while (lertecla.Key != ConsoleKey.F5);
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            Vendas metodosParaOperacaoDeVendas = new Vendas();
                            metodosParaOperacaoDeVendas.VenderProdutos(spMatrizDeProdutos, spMatrizDeClientes);
                            break;
                        }
                    case ConsoleKey.F5:
                        {
                            condicao = false;
                            break;
                        }
                    default:
                        {
                            Templates.MenuAreaDoFuncionarioTeclaInvalida();
                            break;
                        }
                }
            } while (condicao);

            Templates.TelaDeAbertura();
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes);
        }
    }
}
