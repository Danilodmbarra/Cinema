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
           
            string[,] sMatrizDeProdutos =
            { {"0", "Bala Chita", "0.10", "150","Balas mastigáveis nos sabores sortidos abacaxi, framboesa, uva e menta."},
            { "1", "Água Mineral", "2.50", "200","Garrafa contendo 500 ml de água mineral."},
            { "2", "Pipoca Pequena","8.00","50","Embalagem pequena de pipoca salgada, doce ou mista."} };

            string[,] sMatrizDeFuncionarios =
            { { "0", "Nicolas","04899851384","Faxineiro" }, { "1", "Jurema","07895647892", "Vendedora"}, { "2",  "Fabiana","01256987632","Gerente"} };

            string[,] sMatrizDeClientes =
            { {"0","João","08434858624","(31)986541247","Belo Horizonte/MG","joaozinhobh@hotmail.com"},{"1","Priscila","07898412478","(37)987415784","Pará de Minas/MG","priscilapdm@gmail.com"},{"2","Lucas","07453125872","(31)984655147","Sete Lagoas/MG","lukitadagalera@outlook.com" } };

            string[,] sMatrizDeComprasFeita = new string[200, 5];
            

            int tentativasDeLogin = 3, posicaoBloqueados = -1, linhaMatrizProdutos = 2, linhaMatrizFuncionarios = 2, linhaMatrizClientes = 2;

            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(sMatrizUsuariosSenhas, sArrayDeUsuariosBloqueados, ref tentativasDeLogin, ref posicaoBloqueados, sMatrizDeProdutos, ref linhaMatrizProdutos, sMatrizDeClientes, ref linhaMatrizFuncionarios, sMatrizDeFuncionarios, sMatrizDeComprasFeita, ref linhaMatrizClientes);
        }
    }

    }

