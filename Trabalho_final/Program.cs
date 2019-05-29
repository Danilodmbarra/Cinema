using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class Menu
    {
        public void AberturaDeMenus(int pAutentificacao, string pUsuario,string pSenha,string []spArrayDeLoginDeUsuarios,string[] spArrayDeSenhaDeUsuarios,int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados,ref int posicao)
        {
            if (pAutentificacao == 1)
            {
                MenuAdministracao(pUsuario,pSenha,spArrayDeLoginDeUsuarios,spArrayDeSenhaDeUsuarios,pTentativasDeLogin,spArrayDeUsuariosBloquiados, ref posicao);
            }
        }
        public void MenuAdministracao(string pUsuario, string pSenha, string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados, ref int posicao)
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
                            MetodosDeInicializacao.TelaAbertura();
                            MetodosDeInicializacao.TelaCarregamento();
                            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao);
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
            MetodosDeInicializacao.TelaAbertura();
            MetodosDeInicializacao.TelaCarregamento();
            MetodosDeInicializacao.MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicao);

        }


    }
    class Login
    {

        public void TelaAbertura()
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

        public void TelaCarregamento()
        {
            Console.WriteLine("Loading");
            for (int i = 0; i < 74; i++)
            {
                Console.Write("|");
                System.Threading.Thread.Sleep(30);
                
            }
            Console.Clear();
        }

        public void MenuLogin(string[] spArrayDeLoginDeUsuarios, string[] spArrayDeSenhaDeUsuarios, string[] spArrayDeUsuariosBloquiados, int pTentativasDeLogin, ref int posicaoBloquiados)
        {
            string usuario, senha;
            int valorAutentificao;
            Menu MetodosDoMenu = new Menu();




            Console.WriteLine("==========================================================================");
            Console.WriteLine("                      BEM VINDO AO SISTEMA CINETECH!                      ");
            Console.WriteLine("==========================================================================");
            Console.Write("USUARIO: ");
            usuario = Console.ReadLine();
            Console.Write("SENHA: ");
            senha = Console.ReadLine();
            valorAutentificao = Autentificacao(usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados);

            if (valorAutentificao == 0)
            {
                Console.WriteLine("{0} Usuario esta bloquiado contate o administrador", usuario);
            }
            if (valorAutentificao == 1 || (valorAutentificao == 2))
            {
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha, spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, pTentativasDeLogin, spArrayDeUsuariosBloquiados, ref posicaoBloquiados);
            }

            else if (valorAutentificao == 3)
            {
                --pTentativasDeLogin;
                Console.Clear();
                Console.WriteLine("Senha incorreta Tente novamente");
                Console.WriteLine("Tentativas {0} de 3", pTentativasDeLogin);

                MenuLogin(spArrayDeLoginDeUsuarios, spArrayDeSenhaDeUsuarios, spArrayDeUsuariosBloquiados, pTentativasDeLogin, ref posicaoBloquiados);
                Console.ReadKey();

            }
            else if (valorAutentificao == 4)
            {
                spArrayDeUsuariosBloquiados[posicaoBloquiados] = usuario;
                Console.WriteLine("Usuario Bloquiado");
                Console.ReadKey();
                posicaoBloquiados++;
            }
            else
            {
                Console.WriteLine("Usuario Invalido");

            }

            Console.ReadKey();
        }
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
            
    }           
        
        class Program
        {
            static void Main(string[] args)
            {

                string[] sArrayDeLoginDeUsuarios = { "Danilo", "Leonardo", "Joao" };
                string[] sArrayDeSenhaDeUsuarios = { "1234", "1111", "1234" };
                string[] sArrayDeUsuariosBloquiados = new string[100];
                int tentativasDeLogin = 3, posicaoBloquiados = 0;

                Login MetodosDeInicializacao = new Login();
                MetodosDeInicializacao.TelaAbertura();
                MetodosDeInicializacao.TelaCarregamento();
                MetodosDeInicializacao.MenuLogin(sArrayDeLoginDeUsuarios, sArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloquiados, tentativasDeLogin, ref posicaoBloquiados);




            }
        }
    }


