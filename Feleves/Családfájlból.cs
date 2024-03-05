using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Családfájlból : családfa
    {

        private string[] olvasott;

        private személy[] személy;

        public Családfájlból(string fájl) : base(fájl)
        {

        }

        public override void CsaládfaOlvasásfájlból(string fájl)
        {
            Fájlolvasás(fájl);

            Személyeklétrejötte();

            Házastársaklétrejötte();

            Gyermekeklétrejötte();

        }
        public override személy Fájlgyökérelem(string fájl)
        {
            Fájlolvasás(fájl);

            Személyeklétrejötte();

            return személy[0];

        }
        private void Fájlolvasás(string fajlnev)
        {
            if (File.Exists(fajlnev))
            {

                olvasott = File.ReadAllLines(fajlnev);

            }
            else
            {

                throw new Nincsezafájl_exception(fajlnev);

            }
        }
        private void Személyeklétrejötte()
        {
            személy = new személy[olvasott.Length];

            for (int i = 0; i < személy.Length; i++)
            {

                string[] szemely_seged = olvasott[i].Split(',');

                int év = int.Parse(szemely_seged[1].Split('.')[0]);

                int hónap = int.Parse(szemely_seged[1].Split('.')[1]);

                int nap = int.Parse(szemely_seged[1].Split('.')[2]);

                
                if (szemely_seged[2] == "")//az illeto meg el
                {

                    személy[i] = new személy(szemely_seged[0], new DateTime(év, hónap, nap));

                }

                else //az illeto mar meghalt
                {

                    int haláléve = int.Parse(szemely_seged[2].Split('.')[0]);

                    int halálhónapja = int.Parse(szemely_seged[2].Split('.')[1]);

                    int halálnapja = int.Parse(szemely_seged[2].Split('.')[2]);

                    személy[i] = new személy(szemely_seged[0], new DateTime(év, hónap, nap), 
                        new DateTime(haláléve, halálhónapja, halálnapja));

                }
                ;
            }
        }

        private void Gyermekeklétrejötte()
        {
            for (int i = 0; i < személy.Length; i++)
            {

                string[] szemely_seged = olvasott[i].Split(',')[3].Split(';');

                if (szemely_seged[0] != "")
                {

                    for (int j = 0; j < szemely_seged.Length; j++)
                    {

                        gyermekrögzítése(személy[i], személy[TombI(szemely_seged[j])]);

                    }

                }

            }

        }
        private void Házastársaklétrejötte()
        {
            for (int i = 0; i < személy.Length; i++)
            {

                string[] szemely_seged = olvasott[i].Split(',');

                
                if (szemely_seged[4] != "")//házas
                {

                    string[] hazastarsak = szemely_seged[4].Split(';');

                   
                    for (int j = 0; j < hazastarsak.Length; j++) //az eddigi összes házason végighalad
                    {

                        if (hazastarsak[j] != "")
                        {

                            string házastárs_neve = hazastarsak[j].Split('[')[0];

                            string[] datumok = hazastarsak[j].Split('[')[1].Split(']')[0].Split('-');


                            if (datumok[1] == "") //még együtt vannak
                            {

                               
                                int házasodási_év = int.Parse(datumok[0].Split('.')[0]);

                                int házasodási_hónap = int.Parse(datumok[0].Split('.')[1]);

                                int házasodási_nap = int.Parse(datumok[0].Split('.')[2]);

                                házastársrögzítése(személy[i], személy[TombI(házastárs_neve)],
                                    new Házas(new DateTime(házasodási_év, házasodási_hónap, házasodási_nap)));

                            }
                            else//elvált
                            {
                                
                                int házasodási_év = int.Parse(datumok[0].Split('.')[0]);

                                int házasodási_hónap = int.Parse(datumok[0].Split('.')[1]);

                                int házasodási_nap = int.Parse(datumok[0].Split('.')[2]);

                                int elválás_éve = int.Parse(datumok[1].Split('.')[0]);

                                int elválás_hónapja = int.Parse(datumok[1].Split('.')[1]);

                                int elválás_napja = int.Parse(datumok[1].Split('.')[2]);

                                házastársrögzítése(személy[i], személy[TombI(házastárs_neve)], 
                                    new Házas(new DateTime(házasodási_év, házasodási_hónap, házasodási_nap), 
                                    new DateTime(elválás_éve, elválás_hónapja, elválás_napja)));

                            }
                        }
                    }
                }
            }
        }
       
        private int TombI(string nev)
        {
            int i = 0;

            while (i < személy.Length && személy[i].név != nev)
            {

                i++;

            }

            return i;
        }
    }
}
