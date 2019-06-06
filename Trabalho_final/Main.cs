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

            string[] sArrayDeLoginDeUsuarios = { "Danilo", "Leonardo", "Joao" };
            string[] sArrayDeSenhaDeUsuarios = { "1234", "1111", "1234" };
            string[] sArrayDeUsuariosBloqueados = new string[100];
            string[,]sMatrizDeProdutos = { { "01", "Ingresso", "30", "50", "Bom" }, { "02", "Bala", "30", "50", "Bom" }, { "03", "Pipoca", "30", "50", "Bom" }, { "04", "Refrigerante", "30", "50", "Bom" }, { "05", "Chocolate", "30", "50", "Bom" } };
            string[,]sMatrizDeClientes = { { "086.248.766-80", "Joao", "546483330", "Belo Horizonte" }, { "088.258.766-80", "Marcia", "5999483330", "Belo Horizonte" }, { "086.248.644-80", "Pedro", "599980", "Belo Horizonte" } };
            int tentativasDeLogin = 3, posicaoBloqueados = 0, linhaMatrizProdutos = -1;

            Login MetodosDeInicializacao = new Login();
            MetodosDeInicializacao.TelaDeAbertura();
            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(sArrayDeLoginDeUsuarios, sArrayDeSenhaDeUsuarios, sArrayDeUsuariosBloqueados, tentativasDeLogin, ref posicaoBloqueados, sMatrizDeProdutos, ref linhaMatrizProdutos,sMatrizDeClientes);


        }
    }
}

