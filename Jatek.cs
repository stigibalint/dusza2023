using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dusza2023
{
    internal class Jatek
    {
        string szervezo;
        string jatekMegnevezese;
        List<string> alanyok;
        List<int> pontSzam;
        List<string> esemenyek;
        bool lezarva;

        public Jatek(string szervezo, string jatekMegnevezese, List<string> alanyok, List<string> esemenyek)
        {
            this.szervezo = szervezo;
            this.jatekMegnevezese = jatekMegnevezese;
            this.alanyok = alanyok;
            this.esemenyek = esemenyek;
            this.lezarva = false;
        }
        

        public string Szervezo { get => szervezo; }
        public string JatekMegnevezese { get => jatekMegnevezese; }
        public List<string> Alanyok { get => alanyok; }
        public List<string> Esemenyek { get => esemenyek; }
        public List<int> PontSzam { get => pontSzam; set => pontSzam = value; }

        public bool Lezarva { get => lezarva; set => lezarva = value; }

    }
}
