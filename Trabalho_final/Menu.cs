using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{

    class Menu
    {
        public void AberturaDeMenus(int pAutentificacao, string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, ref int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios,string[,] spMatrizDeComprasFeita,ref int pLinhaMatrizClientes)
        {
            if (pAutentificacao == 1)
            {
                MenuAdministracao(pUsuario, pSenha, spMatrizUsuariosSenhas,ref pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
            }
            else if (pAutentificacao == 2)
            {
                MenuFuncionarios(pUsuario, pSenha, spMatrizUsuariosSenhas, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
            }
        }
        public void MenuAdministracao(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, ref int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int pLinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios,string [,] spMatrizDeComprasFeita,ref int pLinhasMatrizClientes)
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
                            GestaoFuncionarios metodoParaGestaoDeFuncionarios = new GestaoFuncionarios();
                            do
                            {
                                metodoParaGestaoDeFuncionarios.GestaoDeFuncionarios(pUsuario, pSenha, spMatrizUsuariosSenhas, ref pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref pLinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhasMatrizClientes);

                            } while (lertecla.Key != ConsoleKey.F5);
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            Templates.TelaDeAbertura();
                            MetodosDeInicializacao.TelaDeCarregamento();
                            MetodosDeInicializacao.MenuLogin(spMatrizUsuariosSenhas, spArrayDeUsuariosBloquiados,ref pTentativasDeLogin, ref posicao, spMatrizDeProdutos, ref pLinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhasMatrizClientes);
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
            MetodosDeInicializacao.MenuLogin(spMatrizUsuariosSenhas, spArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicao, spMatrizDeProdutos, ref pLinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhasMatrizClientes);
        }
        public void MenuFuncionarios(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao, string[,] spMatrizDeProdutos, ref int pLinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int pLinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios,string [,] spMatrizDeComprasFeita,ref int pLinhaMatrizClientes)
        {
            Login MetodosDeInicializacao = new Login();
            ConsoleKeyInfo lertecla;
            ConsolePersonalizado Templates = new ConsolePersonalizado();
            GestaoCliente MetodoParaGestaoDeClientes = new GestaoCliente();
            GestaoFuncionarios MetodoParaGestaoDeFuncionarios = new GestaoFuncionarios();

            bool condicao = true;
            do
            {
                lertecla = Templates.MenuAreaDoFuncionario(pUsuario);

                switch (lertecla.Key)
                {
                    case ConsoleKey.F1:
                        {
                            MetodoParaGestaoDeClientes.GestaoDeCliente(pUsuario, pSenha, spMatrizUsuariosSenhas, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref pLinhaMatrizProdutos, ref pLinhaMatrizClientes, spMatrizDeClientes, ref pLinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita);
                            
                            break;
                        }
                    case ConsoleKey.F2:
                        {
                            MetodoParaGestaoDeFuncionarios.GestaoDeFuncionarios(pUsuario, pSenha, spMatrizUsuariosSenhas, ref pTentativasDeLogin,spArrayDeUsuariosBloquiados, ref  posicao,spMatrizDeProdutos, ref pLinhaMatrizProdutos,spMatrizDeClientes, ref  pLinhaMatrizFuncionarios,spMatrizDeFuncionarios,spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                            break;
                        }
                    case ConsoleKey.F3:
                        {
                            GestaoProdutos metodoParaGestaoDeProdutos = new GestaoProdutos();
                            do
                            {
                                metodoParaGestaoDeProdutos.GestaoDeProdutos(pUsuario, pSenha, spMatrizUsuariosSenhas, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicao, spMatrizDeProdutos, ref pLinhaMatrizProdutos, spMatrizDeClientes, ref pLinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
                            } while (lertecla.Key != ConsoleKey.F5);
                            break;
                        }
                    case ConsoleKey.F4:
                        {
                            Vendas metodosParaOperacaoDeVendas = new Vendas();
                            metodosParaOperacaoDeVendas.VenderProdutos(spMatrizDeProdutos, spMatrizDeClientes, ref pLinhaMatrizProdutos,spMatrizDeComprasFeita, ref pLinhaMatrizClientes, spMatrizDeClientes, ref pLinhaMatrizProdutos, pUsuario,pSenha,spMatrizUsuariosSenhas, ref  pTentativasDeLogin,spArrayDeUsuariosBloquiados,spMatrizDeFuncionarios, ref  posicao, ref  pLinhaMatrizProdutos, spArrayDeUsuariosBloquiados, ref pLinhaMatrizFuncionarios);
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
            MetodosDeInicializacao.MenuLogin(spMatrizUsuariosSenhas, spArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicao, spMatrizDeProdutos, ref pLinhaMatrizProdutos, spMatrizDeClientes, ref pLinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
        }
    }
}
