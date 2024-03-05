using System;

namespace Feleves
{
    class FelhasználóI
    {
        public FelhasználóI()
        {
            KonzolI();
        }
        
        private string döntött_egyed { get; set; }

        private int döntés { get; set; }

        private void KonzolI()
        {
            Console.Clear();
            Console.WriteLine("Kerem döntse el, miként szeretné a családfát!");

            Console.WriteLine("[1] Fájlból");

            Console.WriteLine("[2] Kézzel");

            Console.WriteLine("[3] Bezár");

            try
            {

                döntés = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {

                döntés = 0;

            }
            switch (döntés)
            {

                case 1:

                    FájlTöltés();

                    break;

                case 2:

                    KéziTöltés();

                    break;

                case 3:

                    break;

                default:

                    KonzolI();

                    break;
            }
        }
        private void KéziTöltés()
        {
            Console.Clear();

            Console.WriteLine("Kérem a személyt a családba: ");

            Console.WriteLine();

            családfa csaladfa = new családfa(SzemélyLétrehoz());

            LehetőségSzemélyekkel(ref csaladfa);

           
        }

        private void FájlTöltés()
        {
            Console.Clear();

            Console.WriteLine("Adja meg a fájl nevét!");

            string fájl = Console.ReadLine();

            if (true)
            {

            }

            try
            {

                családfa csaladfa = new Családfájlból(fájl);

                csaladfa.CsaládfaOlvasásfájlból(fájl);

                Console.Clear();

                Console.WriteLine("Családfa innen: {0}" + "\t[ENTER]", fájl);

                Console.ReadLine();

                LehetőségFájl(ref csaladfa);

            }

            catch (Nincsezafájl_exception a)
            {
                Console.WriteLine();

                Console.WriteLine(a.Message);

                Console.ReadLine();

                FájlTöltés();
            }
        }


        private void LehetőségSzemélyekkel(ref családfa családfa)
        {
            Console.Clear();

            Console.WriteLine("Családfa adatai: ");

            foreach (string item in családfa.személyeklistázása())
            {

                Console.Write("[" + item + "] ");

            }
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Lehetőségek");

            Console.WriteLine("[1] Gyermek rögzítése");

            Console.WriteLine("[2] Házastárs rögzítése");

            Console.WriteLine("[3] Szülő rögzítése");

            Console.WriteLine("[4] Személy eltávolítása");

            Console.WriteLine("[5] Összefoglaló");

            Console.WriteLine("[6] Kész");

            try
            {

                döntés = int.Parse(Console.ReadLine());

            }

            catch (Exception)
            {

                döntés = 0;

            }
            switch (döntés)
            {

                case 1:

                    LehetőségSzemélyekkel(ref családfa);

                    GyermekRögzítése(ref családfa);

                    break;

                case 2:

                    LehetőségSzemélyekkel(ref családfa);

                    HázastársRögzítése(ref családfa);

                    break;

                case 3:

                    LehetőségSzemélyekkel(ref családfa);

                    SzülőRögzítése(ref családfa);

                    break;

                case 4:

                    LehetőségSzemélyekkel(ref családfa);

                    SzeméylEltávolít(ref családfa);

                    break;

                case 5:

                    LehetőségKézi(ref családfa);

                    break;

                case 6:

                    KonzolI();

                    break;

                default:

                    LehetőségSzemélyekkel(ref családfa);

                    break;

            }

        }

        private void SzeméylEltávolít(ref családfa csaladfa)
        {
            Console.Clear();

            Console.WriteLine("Családfa adatai: ");

            foreach (string item in csaladfa.személyeklistázása())
            {

                Console.Write("[" + item + "] ");

            }

            Console.WriteLine();

            Console.WriteLine("Melyik listabeli személyt szeretné eltávolítani?");

            string neve = Console.ReadLine();

            if (csaladfa.személykeresés(neve) == null)
            {

                Console.WriteLine();

                Console.WriteLine("{0} nem található, az eltávolítás kivitelezhetetlen! [ENTER]", neve);

                Console.ReadLine();
               

            }
            else
            {

                csaladfa.személytörlés(neve);

            }

        }
        private void HázastársRögzítése(ref családfa csaladfa)
        {
            Console.Clear();

            Console.WriteLine("Családfa adatai: ");

            foreach (string item in csaladfa.személyeklistázása())
            {

                Console.Write("[" + item + "] ");

            }

            Console.WriteLine();

            Console.WriteLine("Melyik listabeli személyhez szeretne házastársat rendelni?");

            string neve = Console.ReadLine();

            if (csaladfa.személykeresés(neve) != null)
            {

                személy házastárs = csaladfa.személykeresés(neve);

                személy házastárs_ = SzemélyLétrehoz();

                Console.WriteLine("Házasság eleje(yyyy.mm.dd): ");

                string házasság_kezdési_dátuma = Console.ReadLine();

                Console.WriteLine("Válás(YYYY.MM.DD) /A házasság megléte esetén nyomja meg az 'n' betűt: ");

                string házasság_válási_dátuma = Console.ReadLine();

                if (házasság_válási_dátuma.ToLower() == "n")
                {

                    csaladfa.házastársrögzítése(házastárs, házastárs_, 
                        new Házas(new DateTime(int.Parse(házasság_kezdési_dátuma.Split('.')[0]), 
                        int.Parse(házasság_kezdési_dátuma.Split('.')[1]), int.Parse(házasság_kezdési_dátuma.Split('.')[2]))));

                }
                else
                {

                    csaladfa.házastársrögzítése(házastárs, házastárs_, 
                        new Házas(new DateTime(int.Parse(házasság_kezdési_dátuma.Split('.')[0]), 
                        int.Parse(házasság_kezdési_dátuma.Split('.')[1]), int.Parse(házasság_kezdési_dátuma.Split('.')[2])), 
                        new DateTime(int.Parse(házasság_válási_dátuma.Split('.')[0]), int.Parse(házasság_válási_dátuma.Split('.')[1]), 
                        int.Parse(házasság_válási_dátuma.Split('.')[2]))));

                }

            }
            else
            {

                Console.WriteLine();

                Console.WriteLine("{0} nem található, a házastárs hozzárendelése kivitelezhetetlen! [ENTER]", neve);

                Console.ReadLine();
            }
        }
        private void SzülőRögzítése(ref családfa csaladfa)
        {
            Console.Clear();

            Console.WriteLine("Családfa adatai: ");

            foreach (string item in csaladfa.személyeklistázása())
            {

                Console.Write("[" + item + "] ");

            }

            Console.WriteLine();

            Console.WriteLine("Melyik listabeli személyhez szeretne szülőt rendelni? ");

            string neve = Console.ReadLine();

            személy gyermek = csaladfa.személykeresés(neve);

            if (gyermek != null)
            {

                személy szülő = SzemélyLétrehoz();

                csaladfa.szülőrögzítése(szülő, gyermek);

            }
            else
            {
                Console.WriteLine();

                Console.WriteLine("{0} nem található, a szülő hozzárendelése kivitelezhetetlen! [ENTER]", neve);

                Console.ReadLine();
            }

        }
        private void GyermekRögzítése(ref családfa csaladfa)
        {

            Console.Clear();

            Console.WriteLine("Családfa adatai: ");

            foreach (string item in csaladfa.személyeklistázása())
            {

                Console.Write("[" + item + "] ");

            }

            Console.WriteLine();

            Console.WriteLine("Melyik listabeli személyhez szeretne gyermeket rendelni ?");

            string neve = Console.ReadLine();

            személy szülő = csaladfa.személykeresés(neve);

            if (szülő != null)
            {

                személy gyermek = SzemélyLétrehoz();

                csaladfa.gyermekrögzítése(szülő, gyermek);

            }
            else
            {

                Console.WriteLine();

                Console.WriteLine("{0} nem talákható, a gyermek hozzárendelése kvitelezhetetlen! [ENTER]",neve);

                Console.ReadLine();

            }

        }
        private személy SzemélyLétrehoz()
        {
            Console.WriteLine("Neve: ");

            string nev = Console.ReadLine();

            Console.WriteLine("Születési dátum(YYYY.MM.DD): ");

            string szulDatum = Console.ReadLine();

            Console.WriteLine("Halálozási datum(YYYY.MM.DD) / ha még életben van, nyomja meg az 'n' betűt: ");

            string halálozás_dátuma = Console.ReadLine();

            if (halálozás_dátuma.ToLower() == "x")
            {

                return new személy(nev, new DateTime(int.Parse(szulDatum.Split('.')[0]), 
                    int.Parse(szulDatum.Split('.')[1]), int.Parse(szulDatum.Split('.')[2])));

            }
            else
            {

                return new személy(nev, new DateTime(int.Parse(szulDatum.Split('.')[0]), 
                    int.Parse(szulDatum.Split('.')[1]), int.Parse(szulDatum.Split('.')[2])),
                    new DateTime(int.Parse(halálozás_dátuma.Split('.')[0]), 
                    int.Parse(halálozás_dátuma.Split('.')[1]), int.Parse(halálozás_dátuma.Split('.')[2])));

            }
        }

        private void Rokonlistázása(ref családfa csaladfa)
        {
            Console.Clear();

            Console.WriteLine("Családfa adatai: ");

            foreach (string item in csaladfa.személyeklistázása())
            {

                Console.Write("[" + item + "] ");

            }

            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Melyik listabeli elem rokonait szeretné listázni?");

            döntött_egyed = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("{0} rokonai:", döntött_egyed);

            try
            {

                csaladfa.Rokonság(döntött_egyed);

            }
            catch (NullReferenceException)
            {

                Console.WriteLine();

                Console.WriteLine("Nem található ez a személy! \t[ENTER]");

                Console.ReadLine();

                Rokonlistázása(ref csaladfa);

            }

            Console.ReadLine();


        }
        private void Nemnépesintervallum(ref családfa csaladfa)
        {
            Console.Clear();

            Intervallum inter = csaladfa.Nemnépes();

            Console.WriteLine("Legkevesebb fővel rendelkező intervallum eleje: {0}", inter.intervallum_kezdete.ToString("yyyy.MM.dd"));

            Console.WriteLine("Legkevesebb fővel rendelkező intervallum vége: {0}", ((DateTime)(inter.intervallum_vége)).ToString("yyyy.MM.dd"));

            Console.WriteLine("Családfő: {0}", inter.intervallum_élői.Count);

            Console.ReadLine();
        }

        private void Népesintervallum(ref családfa csaladfa)
        {

            Console.Clear();

            Intervallum inter = csaladfa.Népes();

            Console.WriteLine("Legnépesebb idő eleje: {0}" ,inter.intervallum_kezdete.ToString("yyyy.MM..dd"));

            DateTime? inter_vége = inter.intervallum_vége;

            if (inter_vége == null)
            {

                Console.WriteLine("Legnépesebb idő vége: Még nincs vége");

            }
            else
            {

                Console.WriteLine("Legnépesebb idő vége: " + ((DateTime)(inter_vége)).ToString("yyyy.MM.dd"));

            }

            Console.WriteLine("Ebben az esteben az átlag életkor: {0}" , Math.Round(inter.Átlagkor()), 4);

            Console.WriteLine("Ebben az esteben a családfő: {0}", inter.intervallum_élői.Count);

            Console.ReadLine();

        }
        private void LehetőségKézi(ref családfa csaladfa)
        {
            Console.Clear();

            Console.WriteLine("Lehetőségek");

            Console.WriteLine("[1] Személy rokonai");

            Console.WriteLine("[2] Legnépesebb intervallum és átlagéletkor");

            Console.WriteLine("[3] Legkevesebb fővel rendlekező intervallum");

            Console.WriteLine("[4] Kész");

            try
            {

                döntés = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {

                döntés = 0;

            }
            switch (döntés)
            {

                case 1:

                    Rokonlistázása(ref csaladfa);

                    LehetőségKézi(ref csaladfa);

                    break;

                case 2:

                    Népesintervallum(ref csaladfa);

                    LehetőségKézi(ref csaladfa);

                    break;

                case 3:

                    Nemnépesintervallum(ref csaladfa);

                    LehetőségKézi(ref csaladfa);

                    break;

                case 4:

                    LehetőségSzemélyekkel(ref csaladfa);

                    break;

                default:

                    LehetőségKézi(ref csaladfa);

                    break;

            }

        }

        private void LehetőségFájl(ref családfa csaladfa)
        {
            Console.Clear();
            Console.WriteLine("Lehetőségek");

            Console.WriteLine("[1] Személy rokonai:");

            Console.WriteLine("[2] Legnépesebb intervallum és átlagéletkor");

            Console.WriteLine("[3] Legkevesebb fővel rendlekező intervallum");

            Console.WriteLine("[4] Kész");

            Console.WriteLine("[5] Bezár");

            try
            {

                döntés = int.Parse(Console.ReadLine());

            }
            catch (Exception)
            {

                döntés = 0;

            }
            switch (döntés)
            {

                case 1:

                    Rokonlistázása(ref csaladfa);

                    LehetőségFájl(ref csaladfa);

                    break;

                case 2:

                    Népesintervallum(ref csaladfa);

                    LehetőségFájl(ref csaladfa);

                    break;

                case 3:

                    Nemnépesintervallum(ref csaladfa);

                    LehetőségFájl(ref csaladfa);

                    break;

                case 4:

                    KonzolI();

                    break;

                case 5:

                    break;

                default:

                    LehetőségFájl(ref csaladfa);

                    break;
            }
        }

    }
}
