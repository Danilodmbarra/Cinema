using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class BaseDeDados
    {
        public void DadosDoPrograma()
        {
            Login MetodosDeInicializacao = new Login();

            string[] sArrayDeUsuariosBloqueados = new string[100];

            string[,] sMatrizUsuariosSenhas = { { "Danilo", "1234", "1", "gato" }, { "Leonardo", "1234", "2", "pc" }, { "Halisson", "1234", "2", "pc" }, { "Guilherme", "1234", "2", "pc" }, { "Eduardo", "1234", "2", "pc" } };
            string[,] sMatrizDeFuncionarios = { { "Danilo", "1234", "2", "gato" }, { "Leonardo", "1234", "2", "pc" }, { "Halisson", "1234", "2", "pc" }, { "Guilherme", "1234", "2", "pc" }, { "Eduardo", "1234", "2", "pc" } };

            string[,] sMatrizDeProdutos = new string[100, 5];
            string[,] sMatrizDeComprasFeita = new string[200, 5];
            string[,] sMatrizDeClientes = new string[100, 6];

            int tentativasDeLogin = 3, posicaoBloqueados = -1, linhaMatrizProdutos = -1, linhaMatrizFuncionarios = 3, linhaMatrizClientes = -1;

            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(sMatrizUsuariosSenhas, sArrayDeUsuariosBloqueados, ref tentativasDeLogin, ref posicaoBloqueados, sMatrizDeProdutos, ref linhaMatrizProdutos, sMatrizDeClientes, ref linhaMatrizFuncionarios, sMatrizDeFuncionarios, sMatrizDeComprasFeita, ref linhaMatrizClientes);
        }
    }

    }

