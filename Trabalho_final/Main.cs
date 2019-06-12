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
            BaseDeDados CarregarPrograma = new BaseDeDados();

            Templates.TelaDeAbertura();
            Templates.BemVindo();
            CarregarPrograma.DadosDoPrograma();
            
            


        }
    }
}

