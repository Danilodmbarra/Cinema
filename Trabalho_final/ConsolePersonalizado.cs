using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class ConsolePersonalizado
    {
        public void TelaDeAbertura()
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

        public ConsoleKeyInfo MenuAreaDoAdministradorTeclaInvalida()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                           ÁREA DO ADMINISTRADOR                          ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Opção Inválida. Pressione qualquer tecla para retornar ao menu.");
            return Console.ReadKey();
        }
        public ConsoleKeyInfo MenuAreaDeGestaoDeFuncionarios()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("              ÁREA DO ADMINISTRADOR - GESTÃO DE FUNCIONÁRIOS              ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Escolha a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("F1) Cadastrar novo funcionário.");
            Console.WriteLine();
            Console.WriteLine("F2) Editar cadastro de funcionário.");
            Console.WriteLine();
            Console.WriteLine("F3) Excluir cadastro de funcionário.");
            Console.WriteLine();
            Console.WriteLine("F4) Consultar funcionários cadastrados.");
            Console.WriteLine();
            Console.WriteLine("F5) Retornar à tela de login.");

            return Console.ReadKey();
        }
        public ConsoleKeyInfo MenuAreaDoAdministrador()
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

            return Console.ReadKey();
          
        }
        public ConsoleKeyInfo MenuAreaDoFuncionario(string pUsuario)
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                           ÁREA DO FUNCIONÁRIO                            ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Bem vindo, {0}! Pressione a tecla referente à opção desejada: ", pUsuario);
            Console.WriteLine();
            Console.WriteLine("F1) Gestão de Clientes");
            Console.WriteLine();
            Console.WriteLine("F2) Gestão Financeira");
            Console.WriteLine();
            Console.WriteLine("F3) Gestão de Produtos");
            Console.WriteLine();
            Console.WriteLine("F4) Operacao de vendas");
            Console.WriteLine();
            Console.WriteLine("F5) Retornar à tela de login");

            return Console.ReadKey();
        }
        public ConsoleKeyInfo MenuAreaDeGestaoDeClientes()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                 ÁREA DO FUNCIONÁRIO - GESTÃO DE CLIENTES                 ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Método em desenvolvimento! Pressione qualquer tecla para retornar ao menu.");

            return Console.ReadKey();
        }
        public ConsoleKeyInfo MenuAreaDeGestaoFinanceira()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                 ÁREA DO FUNCIONÁRIO - GESTÃO FINANCEIRA                  ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Método em desenvolvimento! Pressione qualquer tecla para retornar ao menu.");

            return Console.ReadKey();


        }
        public ConsoleKeyInfo MenuAreaDoFuncionarioTeclaInvalida()
        {
            Console.Clear();
            Console.WriteLine("==========================================================================");
            Console.WriteLine("                           ÁREA DO FUNCIONÁRIO                            ");
            Console.WriteLine("==========================================================================");
            Console.WriteLine("Opção Inválida. Pressione qualquer tecla para retornar ao menu.");
            return Console.ReadKey();
        }
    }
}
