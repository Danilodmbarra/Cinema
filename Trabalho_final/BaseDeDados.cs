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

            string[,] sMatrizDeProdutos = new string[100, 5];
            sMatrizDeProdutos[0, 0] = "0";
            sMatrizDeProdutos[0, 1] = "Bala Chita";
            sMatrizDeProdutos[0, 2] = "0.10";
            sMatrizDeProdutos[0, 3] = "150";
            sMatrizDeProdutos[0, 4] = "Balas mastigáveis nos sabores sortidos abacaxi, framboesa, uva e menta.";
            sMatrizDeProdutos[1, 0] = "1";
            sMatrizDeProdutos[1, 1] = "Água Mineral";
            sMatrizDeProdutos[1, 2] = "2.50";
            sMatrizDeProdutos[1, 3] = "200";
            sMatrizDeProdutos[1, 4] = "Garrafa contendo 500 ml de água mineral.";
            sMatrizDeProdutos[2, 0] = "2";
            sMatrizDeProdutos[2, 1] = "Pipoca Pequena";
            sMatrizDeProdutos[2, 2] = "8.00";
            sMatrizDeProdutos[2, 3] = "50";
            sMatrizDeProdutos[2, 4] = "Embalagem pequena de pipoca salgada, doce ou mista.";

            string[,] sMatrizDeFuncionarios = new string[100, 4];
            sMatrizDeFuncionarios[0, 0] = "0";
            sMatrizDeFuncionarios[0, 1] = "Nicolas";
            sMatrizDeFuncionarios[0, 2] = "04899851384";
            sMatrizDeFuncionarios[0, 3] = "Faxineiro";
            sMatrizDeFuncionarios[1, 0] = "1";
            sMatrizDeFuncionarios[1, 1] = "Jurema";
            sMatrizDeFuncionarios[1, 2] = "07895647892";
            sMatrizDeFuncionarios[1, 3] = "Vendedora";
            sMatrizDeFuncionarios[2, 0] = "2";
            sMatrizDeFuncionarios[2, 1] = "Fabiana";
            sMatrizDeFuncionarios[2, 2] = "01256987632";
            sMatrizDeFuncionarios[2, 3] = "Gerente";


            string[,] sMatrizDeClientes = new string[100, 6];
            sMatrizDeClientes[0, 0] = "0";
            sMatrizDeClientes[0, 1] = "João";
            sMatrizDeClientes[0, 2] = "08434858624";
            sMatrizDeClientes[0, 3] = "(31)986541247";
            sMatrizDeClientes[0, 4] = "Belo Horizonte/MG";
            sMatrizDeClientes[0, 5] = "joaozinhobh@hotmail.com";
            sMatrizDeClientes[1, 0] = "1";
            sMatrizDeClientes[1, 1] = "Priscila";
            sMatrizDeClientes[1, 2] = "07898412478";
            sMatrizDeClientes[1, 3] = "(37)987415784";
            sMatrizDeClientes[1, 4] = "Pará de Minas/MG";
            sMatrizDeClientes[1, 5] = "priscilapdm@gmail.com";
            sMatrizDeClientes[2, 0] = "2";
            sMatrizDeClientes[2, 1] = "Lucas";
            sMatrizDeClientes[2, 2] = "07453125872";
            sMatrizDeClientes[2, 3] = "(31)984655147";
            sMatrizDeClientes[2, 4] = "Sete Lagoas/MG";
            sMatrizDeClientes[2, 5] = "lukitadagalera@outlook.com";

            string[,] sMatrizDeComprasFeita = new string[200, 5];
            

            int tentativasDeLogin = 3, posicaoBloqueados = -1, linhaMatrizProdutos = 2, linhaMatrizFuncionarios = 2, linhaMatrizClientes = 2;

            MetodosDeInicializacao.TelaDeCarregamento();
            MetodosDeInicializacao.MenuLogin(sMatrizUsuariosSenhas, sArrayDeUsuariosBloqueados, ref tentativasDeLogin, ref posicaoBloqueados, sMatrizDeProdutos, ref linhaMatrizProdutos, sMatrizDeClientes, ref linhaMatrizFuncionarios, sMatrizDeFuncionarios, sMatrizDeComprasFeita, ref linhaMatrizClientes);
        }
    }

    }

