using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dusza2023
{
    internal class Fogadas
    {
        string fogadoNeve;
        string jatekMegnevezese;
        int tetOsszeg;
        string alany;
        string esemeny;
        string ertek;

        public Fogadas(string fogadoNeve, string jatekMegnevezese, int tetOsszeg, string alany, string esemeny, string ertek)
        {
            this.fogadoNeve = fogadoNeve;
            this.jatekMegnevezese = jatekMegnevezese;
            this.tetOsszeg = tetOsszeg;
            this.alany = alany;
            this.esemeny = esemeny;
            this.ertek = ertek;
        }

        public string FogadoNeve { get => fogadoNeve; set => fogadoNeve = value; }
        public string JatekMegnevezese { get => jatekMegnevezese; set => jatekMegnevezese = value; }
        public int TetOsszeg { get => tetOsszeg; set => tetOsszeg = value; }
        public string Alany { get => alany; set => alany = value; }
        public string Esemeny { get => esemeny; set => esemeny = value; }
        public string Ertek { get => ertek; set => ertek = value; }


        public string toString()
        {
            return ($"{this.fogadoNeve};{this.jatekMegnevezese};{this.tetOsszeg};{this.alany};{this.esemeny}{this.ertek}");
        }
    }
}
