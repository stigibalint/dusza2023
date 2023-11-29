//KK KLUB
using Dusza2023;
using System.IO;
using System.Linq;

List<Jatek> JatekokLista = new List<Jatek>();
Dictionary<string, int> JatekosokPontszama = new Dictionary<string, int>();

void JatekLetrehozasa()
{
    Console.Clear();
    string szervezoNeve;
    string jatekMegnevezese;
    string alanyokBekerese = "";
    bool alanyokMeddig = true;
    bool esemenyekMeddig = true;
    Console.WriteLine("Ki a szervező? ");
    szervezoNeve = Console.ReadLine();
    Console.WriteLine("Mi a játék megnevezése? ");
    jatekMegnevezese = Console.ReadLine();
    List<string> alanyok = new List<string>();
    Console.WriteLine("Kik az alanyok? (Tovább lépéshez: VEGE) ");
    while (alanyokMeddig)
    {
        alanyokBekerese = Console.ReadLine();
        if(alanyokBekerese.ToUpper() == "VEGE")
        { alanyokMeddig = false; }
        else { alanyok.Add(alanyokBekerese); }
    }

    Console.WriteLine("Mik az események? (Tovább lépéshez: VEGE)   ");
    string input = "";
    List<string> esemenyek = new List<string>();
    while (esemenyekMeddig)
    {
        input = Console.ReadLine();
        if (input.ToUpper() == "VEGE")
        {
            esemenyekMeddig = false;
        }
        else
        {
            esemenyek.Add(input);
        }

    }
    Jatek Ujatek = new Jatek(szervezoNeve, jatekMegnevezese, alanyok, esemenyek);
    JatekokLista.Add(Ujatek);
  
    StreamWriter sr = new StreamWriter("jatekok.txt", append: true);
    sr.WriteLine(Ujatek.Szervezo + ";" + Ujatek.JatekMegnevezese + ";" + Ujatek.Alanyok.Count() + ";" + Ujatek.Esemenyek.Count());
    foreach(var item in Ujatek.Alanyok)
    {
        sr.WriteLine(item);

    }

    if (JatekosokPontszama.ContainsKey(Ujatek.Szervezo) == false)
    {
        JatekosokPontszama.Add(Ujatek.Szervezo, 100);
    }

    foreach (var item in Ujatek.Esemenyek)
    {
        sr.WriteLine(item);
    }
    sr.Close();

    Menu();
}


void FogadasLeadasa()
{

    List<Fogadas> fogadas = new List<Fogadas>();

    //nev bekerese
    Console.Clear();

    double pontszam;
    string fogado;
    while (true)
    {
        Console.WriteLine("Fogadó neve: ");
        fogado = Console.ReadLine();
        if (JatekosokPontszama.ContainsKey(fogado))
        {
            pontszam = JatekosokPontszama[fogado];
            Console.WriteLine($"{fogado} pontszáma: {pontszam}"); 
            break;
        }
        else
        {
            Console.WriteLine("Nincs ilyen nevű ember!");
        }
    }
    Console.Clear();


    //jatek valasztasa
    Console.WriteLine($"{fogado} pontszáma: {pontszam}");
    List<Jatek> leNemZartJatekok = new List<Jatek>();
    foreach(var jatek in JatekokLista) { 
        if(jatek.Lezarva == false)
            leNemZartJatekok.Add(jatek); 
    }

    int kivalasztottJatekIndex = 0;
    while (true)
    {
        for(int i = 0; i < leNemZartJatekok.Count() - 1; i++)
        {
            if (i == kivalasztottJatekIndex)
                Console.WriteLine($"{leNemZartJatekok[i].JatekMegnevezese} <--");
            else
                Console.WriteLine(leNemZartJatekok[i].JatekMegnevezese);
        }
        ConsoleKeyInfo karakter = Console.ReadKey();
        if (karakter.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            break;
        }
        else if (karakter.Key == ConsoleKey.DownArrow)
        {
            if (kivalasztottJatekIndex == leNemZartJatekok.Count() - 1)
                kivalasztottJatekIndex = 0;
            else
                kivalasztottJatekIndex++;
        }
        else if (karakter.Key == ConsoleKey.UpArrow)
        {
            if (kivalasztottJatekIndex == 0)
                kivalasztottJatekIndex = leNemZartJatekok.Count() - 1;
            else
                kivalasztottJatekIndex--;
        }
    }

    //alany kiválasztas
    string kivalasztottAlany;
    string kivalasztottEsemeny;

    int kivalaszottAlanyIndex = 0;
    while (true)
    {
        Console.Clear();
        for(int i = 0; i < leNemZartJatekok[kivalasztottJatekIndex].Alanyok.Count; i++)
        {
            if (i == kivalaszottAlanyIndex)
                Console.WriteLine($"{leNemZartJatekok[kivalasztottJatekIndex].Alanyok[i]} <--");
            else
                Console.WriteLine(leNemZartJatekok[kivalasztottJatekIndex].Alanyok[i]);
        }

        ConsoleKeyInfo karakter = Console.ReadKey();
        if (karakter.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            break;
        }
        else if (karakter.Key == ConsoleKey.DownArrow)
        {
            if (kivalaszottAlanyIndex == leNemZartJatekok[kivalasztottJatekIndex].Alanyok.Count - 1)
                kivalaszottAlanyIndex = 0;
            else
                kivalaszottAlanyIndex++;
        }
        else if (karakter.Key == ConsoleKey.UpArrow)
        {
            if (kivalaszottAlanyIndex == 0)
                kivalaszottAlanyIndex = leNemZartJatekok[kivalasztottJatekIndex].Alanyok.Count - 1;
            else
                kivalaszottAlanyIndex--;
        }
    }
    kivalasztottAlany = leNemZartJatekok[kivalasztottJatekIndex].Alanyok[kivalaszottAlanyIndex];

    int kivalaszottEsemenyIndex = 0;
    while (true)
    {
        Console.Clear();
        for (int i = 0; i < leNemZartJatekok[kivalasztottJatekIndex].Esemenyek.Count; i++)
        {
            if (i == kivalaszottAlanyIndex)
                Console.WriteLine($"{leNemZartJatekok[kivalasztottJatekIndex].Esemenyek[i]} <--");
            else
                Console.WriteLine(leNemZartJatekok[kivalasztottJatekIndex].Esemenyek[i]);
        }

        ConsoleKeyInfo karakter = Console.ReadKey();
        if (karakter.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            break;
        }
        else if (karakter.Key == ConsoleKey.DownArrow)
        {
            if (kivalaszottAlanyIndex == leNemZartJatekok[kivalasztottJatekIndex].Esemenyek.Count - 1)
                kivalaszottAlanyIndex = 0;
            else
                kivalaszottAlanyIndex++;
        }
        else if (karakter.Key == ConsoleKey.UpArrow)
        {
            if (kivalaszottAlanyIndex == 0)
                kivalaszottAlanyIndex = leNemZartJatekok[kivalasztottJatekIndex].Esemenyek.Count - 1;
            else
                kivalaszottAlanyIndex--;
        }
    }
    kivalasztottEsemeny = leNemZartJatekok[kivalasztottJatekIndex].Esemenyek[kivalaszottEsemenyIndex];


    //ertek, tet bekerese
    Console.Write("Érték: ");
    string ertek = Console.ReadLine();

    Console.Write("Tét: ");
    int tet = Convert.ToInt32(Console.ReadLine());


    //kiiratas
    StreamWriter sw = new StreamWriter("fogadasok.txt");
    sw.WriteLine($"{leNemZartJatekok[kivalasztottJatekIndex].Szervezo};{leNemZartJatekok[kivalasztottJatekIndex].JatekMegnevezese};{tet};{kivalasztottAlany};{kivalasztottEsemeny};{ertek}");
    sw.Close();

    Menu();
}


double szorzoSzamitasa(int fogadasokSzama)
{
    double a;
    if (fogadasokSzama == 0)
    {
        return 0;
    }
    return  1 + (5 / Math.Pow(2, fogadasokSzama - 1));

}

 void JatekLezarasa()
{
    Console.WriteLine("Kérem a szervező nevét: ");
    string bekertSzervezoNeve = Console.ReadLine();
    bool vaneIlyenSzervezo = false;

    Console.WriteLine("Kérem a játék nevét: ");
    string bekertjatekNeve = Console.ReadLine();
    bool vaneIlyenJatek = false;

    foreach (var jatek in JatekokLista)
    {
        if (jatek.Szervezo == bekertSzervezoNeve)
            vaneIlyenSzervezo = true;
        if (jatek.JatekMegnevezese == bekertjatekNeve)
            vaneIlyenJatek = true;
    }

    Jatek megfeleloJatek;
    foreach (var jatek in JatekokLista)
    {
        if (jatek.Szervezo == bekertSzervezoNeve && jatek.JatekMegnevezese == bekertjatekNeve) 
        {
            megfeleloJatek = jatek;
            List<string> ertekek = new List<string>();
            jatek.Lezarva = true;

            foreach(var alany in megfeleloJatek.Alanyok)
            {
                foreach(var esemeny in megfeleloJatek.Esemenyek)
                {
                    Console.Write($"{alany};{esemeny} eredménye: ");
                    string beirtEredmeny = Console.ReadLine();
                    ertekek.Add(beirtEredmeny);
                }
            }

            StreamWriter sw = new StreamWriter("eredmenyek.txt", append: true);
            sw.WriteLine($"{megfeleloJatek.JatekMegnevezese}");

            int eredmenyIndex = 0;
            foreach (var alany in megfeleloJatek.Alanyok)
            {
                foreach (var esemeny in megfeleloJatek.Esemenyek)
                {
                    sw.WriteLine($"{alany};{esemeny};{ertekek[eredmenyIndex]}");
                }
                eredmenyIndex++;
            }
            sw.Close();
        }
        else
        {
            Console.Clear();
            if (vaneIlyenSzervezo == false)
                Console.WriteLine("Nincs ilyen szervező!");
            else if (vaneIlyenJatek == false)
                Console.WriteLine("Nincs ilyen játék!");
            else
                Console.WriteLine("Ilyen játék és szervező sincs!");
            JatekLezarasa();
        }
    }
    Menu();
 }

void Lekerdezesek()
{
    int kivalasztottmenuponIndex = 0;
    bool menuLezar = true;

    while (menuLezar)
    {
        if (kivalasztottmenuponIndex == 0) { Console.WriteLine("1 - Ranglista <--"); }
        else { Console.WriteLine("1 - Ranglista"); }

        if (kivalasztottmenuponIndex == 1) { Console.WriteLine("2 - Játék statisztika <--"); }
        else { Console.WriteLine("2 - Játék statisztika"); }

        if (kivalasztottmenuponIndex == 2) { Console.WriteLine("3 - Fogadási statisztika <--"); }
        else { Console.WriteLine("3 - Fogadási statisztika"); }


        ConsoleKeyInfo karakter = Console.ReadKey();
        if (karakter.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            menuLezar = false;
        }
        else if (karakter.Key == ConsoleKey.DownArrow)
        {
            if (kivalasztottmenuponIndex == 2)
                kivalasztottmenuponIndex = 0;
            else
                kivalasztottmenuponIndex++;
        }
        else if (karakter.Key == ConsoleKey.UpArrow)
        {
            if (kivalasztottmenuponIndex == 0)
                kivalasztottmenuponIndex = 2;
            else
                kivalasztottmenuponIndex--;
        }
        Console.Clear();
    }
    
    if (kivalasztottmenuponIndex == 0)
        Ranglista();
    else if (kivalasztottmenuponIndex == 1)
        JatekStatisztika();
    else if (kivalasztottmenuponIndex == 2)
        FogadasiStatisztika();


}

static void Kilepes()
{
  Environment.Exit(0);
}


void Menu()
{
    Console.Clear();
    int kivalasztottmenuponIndex = 0;
    bool menuLezar = true;

    while (menuLezar)
    {
        if (kivalasztottmenuponIndex == 0) { Console.WriteLine("1 - Játék létrehozása <--"); }
        else { Console.WriteLine("1 - Játék létrehozása"); }

        if (kivalasztottmenuponIndex == 1) { Console.WriteLine("2 - Fogadás leadása <--"); }
        else { Console.WriteLine("2 - Fogadás leadása"); }

        if (kivalasztottmenuponIndex == 2) { Console.WriteLine("3 - Játék lezárása <--"); }
        else { Console.WriteLine("3 - Játék lezárása"); }

        if (kivalasztottmenuponIndex == 3) { Console.WriteLine("4 - Lekérdezések <--"); }
        else { Console.WriteLine("4 - Lekérdezések"); }

        if (kivalasztottmenuponIndex == 4) { Console.WriteLine("5 - Kilépés <--"); }
        else { Console.WriteLine("5 - Kilépés"); }


        ConsoleKeyInfo karakter = Console.ReadKey();
        if (karakter.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            menuLezar = false;
        }
        else if (karakter.Key == ConsoleKey.DownArrow)
        {
            if (kivalasztottmenuponIndex == 4)
                kivalasztottmenuponIndex = 0;
            else
                kivalasztottmenuponIndex++;
        }
        else if (karakter.Key == ConsoleKey.UpArrow)
        {
            if (kivalasztottmenuponIndex == 0)
                kivalasztottmenuponIndex = 4;
            else
                kivalasztottmenuponIndex--;
        }
        Console.Clear();
    }
    if (kivalasztottmenuponIndex == 0)
        JatekLetrehozasa();
    else if (kivalasztottmenuponIndex == 1)
        FogadasLeadasa();
    else if (kivalasztottmenuponIndex == 2)
        JatekLezarasa();
    else if (kivalasztottmenuponIndex == 3)
        Lekerdezesek();
    else if (kivalasztottmenuponIndex == 4)
        Kilepes();
}

void Ranglista()
{
    Console.Clear();
    JatekosokPontszama.OrderBy(x => x.Value).ToList().ForEach(x => Console.WriteLine($"{x.Key}  {x.Value}"));

}

 void JatekStatisztika()
{
   /* int nyeremeny = 0;
    int feltettTet = 0;
    try
    {

        var beolvasas = File.ReadAllLines("fogadasok.txt");
        foreach (var item in beolvasas)
        {
            string[] lista = item.Split(';');
            nyeremeny += int.Parse( lista[4]);
            feltettTet += int.Parse(lista[2]);

        }
        Console.WriteLine($"");

    }
    catch
    {

        Console.WriteLine("Fájl nem található!");
        Menu();
    }

    */
}




















static void FogadasiStatisztika()
{

}
Menu();
