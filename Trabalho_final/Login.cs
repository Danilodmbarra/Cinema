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
            
            for (int i = 0; i < 1; i++)
            {
                Console.Write("|");
                System.Threading.Thread.Sleep(30);

            }
           
        }
        
        public void MenuLogin(string [,]spMatrizUsuariosSenhas, string[] sArrayDeUsuariosBloquiados, ref int pTentativasDeLogin, ref int posicaoBloquiados, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios,string[,] spMatrizDeComprasFeita, ref int pLinhaMatrizClientes)
        {
            
            string usuario, senha;
            int valorAutentificao;
            Menu MetodosDoMenu = new Menu();
           

           

            Console.Write("USUARIO: ");
            usuario = Console.ReadLine();
            Console.Write("SENHA: ");
            senha = Console.ReadLine();
            
          

        
            Console.Clear();
            valorAutentificao = Autentificacao(usuario, senha, spMatrizUsuariosSenhas, pTentativasDeLogin, sArrayDeUsuariosBloquiados);




            if (valorAutentificao == 0)
            {

                Console.WriteLine("{0} Usuario esta bloqueado contate o administrador", usuario);
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha,spMatrizUsuariosSenhas,ref pTentativasDeLogin, sArrayDeUsuariosBloquiados, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
            }
            if (valorAutentificao == 1 || (valorAutentificao == 2))
            {
                MetodosDoMenu.AberturaDeMenus(valorAutentificao, usuario, senha, spMatrizUsuariosSenhas, ref pTentativasDeLogin, sArrayDeUsuariosBloquiados, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
            }

            else if (valorAutentificao == 3)
            {
                ConsoleKeyInfo lerTecla;

                --pTentativasDeLogin;
                Console.Clear();
                Console.WriteLine("Senha incorreta. Tente novamente");
                Console.WriteLine("Tentativas {0} de 3", pTentativasDeLogin);
                Console.WriteLine("Para Recuperar a Senha Aperte F1");
                Console.WriteLine("Para Tentar Novamente Aperte ENTER");

                lerTecla = Console.ReadKey();

                if (lerTecla.Key.Equals(ConsoleKey.F1))
                {
                    RecuperarSenha(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref  plinhaMatrizProdutos,spMatrizDeClientes, ref plinhaMatrizFuncionarios,spMatrizDeFuncionarios,spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                }
                else
                {
                    MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
                    Console.ReadKey();
                }
                               

            }
            else if (valorAutentificao == 4)
            {

                sArrayDeUsuariosBloquiados[posicaoBloquiados] = usuario;
                Console.WriteLine("Usuario Bloqueado");
                Console.ReadKey();
                posicaoBloquiados++;
                MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados,ref  pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita,ref pLinhaMatrizClientes);
            }
            else
            {
                Console.WriteLine("Usuario Invalido");
                MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
            }

            Console.ReadKey();
        }
        
        public int Autentificacao(string pUsuario, string pSenha, string[,] spMatrizUsuariosSenhas, int pTentativasDeLogin, string[] spArrayDeUsuariosBloquiados)
        {

            string admin = "Administrador";
            string adminSenha = "123";
            int posicao, ternarioTentativasDeLogin;

            string[] spArrayDeLoginDeUsuarios = new string[spMatrizUsuariosSenhas.GetLength(0)];
            string[] spArrayDeUsuariosSenha = new string [spMatrizUsuariosSenhas.GetLength(0)];

            for (int indicelLinhas = 0; indicelLinhas < spMatrizUsuariosSenhas.GetLength(0); indicelLinhas++)
            {
                spArrayDeLoginDeUsuarios[indicelLinhas] = spMatrizUsuariosSenhas[indicelLinhas, 0];
                spArrayDeUsuariosSenha[indicelLinhas] = spMatrizUsuariosSenhas[indicelLinhas, 1];
            
            }
            
            if (pUsuario == admin && pSenha == adminSenha)
            {
                return 1;

            }
            else if (spArrayDeUsuariosBloquiados.Contains(pUsuario))
            {
                return 0;
            }
            else if (spArrayDeLoginDeUsuarios.Contains(pUsuario))
            {
                posicao = Array.IndexOf(spArrayDeLoginDeUsuarios, pUsuario);
                if (spArrayDeUsuariosSenha[posicao] == pSenha && (spMatrizUsuariosSenhas[posicao, 2] == "2"))
                {
                    return 1;
                }
                   else if (spArrayDeUsuariosSenha[posicao] == pSenha && (spMatrizUsuariosSenhas[posicao, 2] == "1"))
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
        public string [,] RecuperarSenha(string[,] spMatrizUsuariosSenhas, string[] sArrayDeUsuariosBloquiados, ref int pTentativasDeLogin, ref int posicaoBloquiados, string[,] spMatrizDeProdutos, ref int plinhaMatrizProdutos, string[,] spMatrizDeClientes, ref int plinhaMatrizFuncionarios, string[,] spMatrizDeFuncionarios, string[,] spMatrizDeComprasFeita, ref int pLinhaMatrizClientes)
        {
            string[] arrayUsuarios = new string[spMatrizUsuariosSenhas.GetLength(0)];
            string usuario,palavraChave,senha;
            int posicao;

            for (int indiceLinhas = 0; indiceLinhas <spMatrizUsuariosSenhas.GetLength(0) ; indiceLinhas++)
            {
                arrayUsuarios[indiceLinhas] = spMatrizUsuariosSenhas[indiceLinhas, 0];
            }

            Console.WriteLine("Digite o Usuario");
            usuario = Console.ReadLine();

            if (arrayUsuarios.Contains(usuario))
            {
                if (sArrayDeUsuariosBloquiados.Contains(usuario))
                {
                    Console.WriteLine("Usuario esta bloquiado ");
                    Console.WriteLine("Contate o administrador");
                    MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);

                }
                else
                {
                    posicao = Array.IndexOf(arrayUsuarios, usuario);
                    Console.WriteLine("Digite a palavra Chave");
                    palavraChave = Console.ReadLine();

                    if (palavraChave.Equals(spMatrizUsuariosSenhas[posicao, 3]))
                    {
                        Console.WriteLine("Digite nova Senha");
                        senha = Console.ReadLine();
                        spMatrizUsuariosSenhas[posicao, 1] = senha;
                        MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);

                    }
                    else
                    {
                        Console.WriteLine("Palavra Chave invalida ");
                        Console.WriteLine("Contate o administrador");
                        MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);

                    }
                

                }
            }
            else
            {
                Console.WriteLine("Usuario Nao existe");
                Console.WriteLine("Contate o administrador");
                MenuLogin(spMatrizUsuariosSenhas, sArrayDeUsuariosBloquiados, ref pTentativasDeLogin, ref posicaoBloquiados, spMatrizDeProdutos, ref plinhaMatrizProdutos, spMatrizDeClientes, ref plinhaMatrizFuncionarios, spMatrizDeFuncionarios, spMatrizDeComprasFeita, ref pLinhaMatrizClientes);
            }
           
            return spMatrizUsuariosSenhas;
        }
    }

}
