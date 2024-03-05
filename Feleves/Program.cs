using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Program
    {
        static void Rokon_kiír(személy tartalom)
        {
            Console.WriteLine(tartalom.név);
        }
        static void Main(string[] args)
        {
            #region Iconsole
            FelhasználóI intFace = new FelhasználóI();
            #endregion

            #region Teszt_Fajlal
            családfa család_fájlból = new Családfájlból("szemely.txt");
            család_fájlból.CsaládfaOlvasásfájlból("szemely.txt");
            család_fájlból.Rokonság("Béla");
            Intervallum korszak_Fajl = család_fájlból.Népes();
            Intervallum korszak__Fajl = család_fájlból.Nemnépes();
            double atlageletkor_Fajl = korszak_Fajl.Átlagkor();
            #endregion

            #region Teszt_Kezzel
            //családfa csaladfa = CsaladfaKezzel();

            //List<DateTime> dátum = csaladfa.Dátum();

            //Dictionary<DateTime, List<személy>> segéd = csaladfa.Élők();

            //Intervallum korszak = csaladfa.Népes();

            //Intervallum korszak_ = csaladfa.Nemnépes();

            //double átlagkor = korszak.Átlagkor();

            //csaladfa.személytörlés("Elemér");

            #endregion

        }

        static családfa CsaladfaKezzel()
        {
            személy Béla = new személy("Béla", new DateTime(1945, 10, 01));

            személy Károly = new személy("Károly", new DateTime(1989, 10, 15));

            személy Patrícia = new személy("Patrícia", new DateTime(1950, 07, 01));

            személy Emese = new személy("Emese", new DateTime(1952, 07, 01));

            személy Cecília = new személy("Cecília", new DateTime(1950, 07, 01), new DateTime(1991, 12, 18));

            személy Gábor = new személy("Gábor", new DateTime(1950, 07, 01), new DateTime(1990, 09, 20));

            családfa csaladfa = new családfa(Károly);

            csaladfa.szülőrögzítése(Béla, Károly);

            csaladfa.gyermekrögzítése(Béla, Károly);

            csaladfa.házastársrögzítése(Béla, Patrícia, new Házas(Dátum(1989, 09, 05)));

            csaladfa.házastársrögzítése(Béla, Cecília, new Házas(Dátum(1980, 09, 05), Dátum(1981, 10, 08)));
            
            csaladfa.gyermekrögzítése(Cecília, Gábor);
            
            csaladfa.szülőrögzítése(Emese, Károly);
            
            csaladfa.Rokonság("Béla");

            return csaladfa;

        }
        static DateTime Dátum(int év, int hónap, int nap)
        {
            
            return new DateTime(év, hónap, nap);

        }
    }
}
