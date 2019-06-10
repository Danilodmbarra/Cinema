using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Login
    {
            

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

        public void MenuLogin(string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, string[] sArrayDeUsuariosBloquiados, int pTentativasDeLogin, ref int posicaoBloquiados, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, ref int plinhaMatrizClientes, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios)
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
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, sArrayDeUsuariosBloquiados, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, ref plinhaMatrizClientes, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
            }
            if (valorAutentificao == 1 || (valorAutentificao == 2))
            {
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, sArrayDeUsuariosBloquiados, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, ref plinhaMatrizClientes, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
            }

            else if (valorAutentificao == 3)
            {
                --pTentativasDeLogin;

                Console.WriteLine("Senha incorreta. Tente novamente");
                Console.WriteLine("Tentativas {0} de 3", pTentativasDeLogin);

                MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, ref plinhaMatrizClientes, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
                Console.ReadKey();

            }
            else if (valorAutentificao == 4)
            {

                sArrayDeUsuariosBloquiados[posicaoBloquiados] = usuario;
                Console.WriteLine("Usuario Bloqueado");
                Console.ReadKey();
                posicaoBloquiados++;
                MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, ref plinhaMatrizClientes, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios);
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

}
