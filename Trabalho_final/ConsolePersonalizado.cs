using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineTech
{
    class ConsolePersonalizado
    {
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
            Console.WriteLine("Método em desenvolvimento! Pressione qualquer tecla para retornar ao menu.");
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
    }
}
