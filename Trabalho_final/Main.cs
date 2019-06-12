using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech

{
            
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePersonalizado Templates = new ConsolePersonalizado();

            string[] sArrayDeUsuariosBloqueados = new string[100];
            string[,] sMatrizUsuariosSenhas = { { "Danilo", "1234", "2", "gato" }, { "Leonardo", "1234", "2", "pc" }, { "Halisson", "1234", "2", "pc" }, { "Guilherme", "1234", "2", "pc" }, { "Eduardo", "1234", "2", "pc" }};
            string[,] sMatrizDeProdutos = new string[100, 5];
            string[,] sMatrizDeFuncionarios = { { "Danilo", "1234", "2", "gato" }, { "Leonardo", "1234", "2", "pc" }, { "Halisson", "1234", "2", "pc" }, { "Guilherme", "1234", "2", "pc" }, { "Eduardo", "1234", "2", "pc" }};
            string[,] sMatrizDeComprasFeita = new string[200, 5];
            //string[,] sMatrizDeClientes = { { "086.248.766-80", "Joao", "546483330", "Belo Horizonte" }, { "088.258.766-80", "Marcia", "5999483330", "Belo Horizonte" }, { "086.248.644-80", "Pedro", "599980", "Belo Horizonte" } };
            string[,] sMatrizDeClientes = new string [100, 6];
            int tentativasDeLogin = 3, posicaoBloqueados = 0, linhaMatrizProdutos = -1, linhaMatrizFuncionarios =3 , linhaMatrizClientes = -1;

            Login MetodosDeInicializacao = new Login();
            Templates.TelaDeAbertura();
            Templates.BemVindo();
            
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(sMatrizUsuariosSenhas,sArrayDeUsuariosBloqueados, ref tentativasDeLogin, ref posicaoBloqueados, sMatrizDeProdutos, ref linhaMatrizProdutos, sMatrizDeClientes, ref linhaMatrizFuncionarios, sMatrizDeFuncionarios, sMatrizDeComprasFeita,ref linhaMatrizClientes);


        }
    }
}

