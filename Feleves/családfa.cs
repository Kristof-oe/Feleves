using System;
using System.Collections.Generic;
using System.Linq;

namespace Feleves
{
    class családfa
    {
        protected gráf<személy, IK> csgráf;


        public családfa(személy szemely)
        {
            csgráf = new gráf<személy, IK>(szemely);
        }
        protected családfa(string fajlnev)
        {
            csgráf = new gráf<személy, IK>(Fájlgyökérelem(fajlnev));
        }

        public void személytörlés(string neve) 
        {
            személy szemely = személykeresés(neve);

            if (szemely != null)
            {

                csgráf.törlés(szemely);

            }

            foreach (személy grafcsúcs in csgráf.csúcsok)
            {
                List<személy> törölt_házastársak_listázása = new List<személy>();

                foreach (személy házastársak in grafcsúcs.házastárs)//házastársból történő eltávolítás
                {

                    if (házastársak != szemely)
                    {

                        törölt_házastársak_listázása.Add(házastársak);

                    }

                }

                grafcsúcs.házastárs = törölt_házastársak_listázása;

            }
           
            foreach (személy grafcsúcs in csgráf.csúcsok) //gyermekekből történő eltávolítás
            {
                List<személy> törölt_gyermekek_listázása = new List<személy>();

                foreach (személy gyermekek in grafcsúcs.gyermek)
                {

                    if (gyermekek != szemely)
                    {

                        törölt_gyermekek_listázása.Add(gyermekek);

                    }

                }

                grafcsúcs.gyermek = törölt_gyermekek_listázása;
            }

        }
        public családfa személytörlés(személy töröl)
        {

            if (csgráf.csVanE(töröl))
            {

                csgráf.törlés(töröl);

            }

            
            foreach (személy gráfcsúcs in csgráf.csúcsok)//házastársból történő eltávolítás végrehajtása
            {

                List<személy> törölt_házastársak_listázása = new List<személy>();

                foreach (személy házastársak in gráfcsúcs.házastárs)
                {

                    if (házastársak != töröl)
                    {

                        törölt_házastársak_listázása.Add(házastársak);

                    }

                }

                gráfcsúcs.házastárs = törölt_házastársak_listázása;
            }

            

            foreach (személy gráfcsúcs in csgráf.csúcsok)//gyermekekből történő eltávolítás végrehajtása
            {

                List<személy> törölt_gyermekek_listázása = new List<személy>();

                foreach (személy gyermekek in gráfcsúcs.gyermek)
                {

                    if (gyermekek != töröl)
                    {

                        törölt_gyermekek_listázása.Add(gyermekek);

                    }

                }

                gráfcsúcs.gyermek = törölt_gyermekek_listázása;
            }

            return this;

        }

        public List<string> személyeklistázása()
        {

            List<string> személyek = new List<string>();

            foreach (személy item in csgráf.csúcsok)
            {

                személyek.Add(item.név);

            }

            return személyek;
        }
        public családfa gyermekrögzítése(személy szülő, személy gyermek)
        {

            if (!csgráf.csVanE(szülő))
            {

                csgráf.ucsucs(szülő);

            }

            if (!csgráf.csVanE(gyermek))
            {

                csgráf.ucsucs(gyermek);

            }

            if (!csgráf.ÉlhúzódikE(gyermek, szülő))
            {

                csgráf.uél(gyermek, szülő, new Szülő());

            }

            if (!csgráf.ÉlhúzódikE(szülő, gyermek))
            {

                csgráf.uél(szülő, gyermek, new Gyermek());

                szülő.gyermek.Add(gyermek);

            }
            

            return this;

        }
        public családfa gyermekrögzítése(személy szülő, személy szülő_, személy gyermek)
        {
            if (!csgráf.csVanE(szülő_))
            {

                csgráf.ucsucs(szülő_);

            }

            if (!csgráf.csVanE(szülő))
            {

                csgráf.ucsucs(szülő);

            }

            if (!csgráf.csVanE(gyermek))
            {

                csgráf.ucsucs(gyermek);

            }

            if (!csgráf.ÉlhúzódikE(szülő, gyermek))
            {

                csgráf.uél(szülő, gyermek, new Gyermek());

                szülő.gyermek.Add(gyermek);

            }

            if (!csgráf.ÉlhúzódikE(szülő_, gyermek))
            {
                csgráf.uél(szülő_, gyermek, new Gyermek());

                szülő_.gyermek.Add(gyermek);

            }

            if (!csgráf.ÉlhúzódikE(gyermek, szülő))
            {

                csgráf.uél(gyermek, szülő, new Szülő());

            }

            if (!csgráf.ÉlhúzódikE(gyermek, szülő_))
            {

                csgráf.uél(gyermek, szülő_, new Szülő());

            }

            return this;
        }
        public családfa házastársrögzítése(személy házastárs, személy házastárs_, Házas házasság)
        {
            if (!csgráf.csVanE(házastárs))
            {

                csgráf.ucsucs(házastárs);

            }

            if (!csgráf.csVanE(házastárs_))
            {

                csgráf.ucsucs(házastárs_);

            }

            if (!csgráf.ÉlhúzódikE(házastárs_, házastárs))
            {

                csgráf.uél(házastárs_, házastárs, házasság);

                házastárs_.házastárs.Add(házastárs);

            }

            if (!csgráf.ÉlhúzódikE(házastárs, házastárs_))
            {

                csgráf.uél(házastárs, házastárs_, házasság);

                házastárs.házastárs.Add(házastárs_);

            }

            return this;

        }
        public családfa szülőrögzítése(személy szülő, személy gyermek)
        {
            csgráf.ucsucs(szülő);

            if (!csgráf.csVanE(gyermek))
            {

                csgráf.ucsucs(gyermek);

            }

            if (!csgráf.ÉlhúzódikE(szülő, gyermek))
            {

                csgráf.uél(szülő, gyermek, new Gyermek());

                szülő.gyermek.Add(gyermek);

            }

            if (!csgráf.ÉlhúzódikE(gyermek, szülő))
            {

                csgráf.uél(gyermek, szülő, new Szülő());

            }

            return this;

        }

        public void Rokonság(string neve)
        {

            bool elsohagyva = false;

            csgráf.Járás(személykeresés(neve), segéd =>
            {

                if (elsohagyva == true)
                {

                    Console.WriteLine(segéd.név);

                }

                elsohagyva = true;

            });

        }

        public személy személykeresés(string neve)
        {

            személy szemely = null;

            foreach (személy item in csgráf.csúcsok)
            {

                if (item.név == neve)
                {

                    szemely = item;

                }

            }

            return szemely;

        }

        public virtual személy Fájlgyökérelem(string fájl)
        {

            return null;

        }


        public virtual void CsaládfaOlvasásfájlból(string fájl) { }


        public List<DateTime> Dátum()//halálozásért és születésért felelős metódus
        {
            
            List<DateTime> datumok = new List<DateTime>();

            foreach (személy item in csgráf.csúcsok)
            {

                datumok.Add(item.született);

                if (item.elhunyt != null)
                {

                    datumok.Add((DateTime)item.elhunyt);

                }

            }
            
            datumok = datumok.Distinct().ToList();//a dátumok ismétlődése végett történő szűrés, visszaadás

            datumok.Sort();

            return datumok;

        }


        public bool ÉlE(DateTime kora, személy személy )
        {

            if (személy.elhunyt != null)
            {

                return személy.született <= kora && személy.elhunyt > kora;

            }
            else
            {

                return személy.született <= kora;

            }

        }

        public Dictionary<DateTime, List<személy>> Élők()//tárolja az adott időben élő személyeket, és azon létszámát is
        {

            Dictionary<DateTime, List<személy>> élnek = new Dictionary<DateTime, List<személy>>();

            List<DateTime> dátumok = Dátum();

            foreach (DateTime dátum in dátumok)
            {

                List<személy> szemelyek = new List<személy>();

                foreach (személy szemely in csgráf.csúcsok)
                {

                    if (ÉlE(dátum, szemely ))
                    {

                        szemelyek.Add(szemely);

                    }
                }

                élnek.Add(dátum, szemelyek);
            }

            return élnek;

        }


        public Intervallum Nemnépes()
        {
            List<KeyValuePair<DateTime, List<személy>>> lista = new List<KeyValuePair<DateTime, List<személy>>>();
            
            Dictionary<DateTime, List<személy>> élnek = Élők();

            var segéd = élnek.ToList().OrderBy(x => x.Value.Count);// a növekvő sorrend élők mentén

            int max = segéd.First().Value.Count;

            foreach (var item in segéd)
            {
                
                lista.Add(item);//változás be nem következéséig ismétlődik

                if (item.Value.Count != max)
                {

                    break;

                }

            }

            var Intervallum = lista.ToList().OrderBy(x => x.Key).ToList();
           
            

            return new Intervallum(Intervallum.First().Key, Intervallum.Last().Key, Intervallum.First().Value);//egy újabb intervallum használata során mentjük az adatot
            

        }
        public Intervallum Népes()
        {
            Dictionary<DateTime, List<személy>> élnek = Élők();

            
            var segéd = élnek.ToList().OrderBy(x => x.Value.Count).Reverse();// a csökkenő sorrend élők mentén

            
            List<KeyValuePair<DateTime, List<személy>>> intervallum_listázása = new List<KeyValuePair<DateTime, List<személy>>>();//halálozásig helyezi bele az elemeket

            int max = segéd.First().Value.Count;

            foreach (var item in segéd)
            {

                intervallum_listázása.Add(item);
               

                if (item.Value.Count != max)
                {

                    break;

                }
            }

            var Intervallum = intervallum_listázása.ToList().OrderBy(x => x.Key).ToList();// intervallumot listázzuk, a KeyValuePair miatt, dátum meg Key mentén renedződik

            //egy újabb intervallum használata során mentjük az adatot
            if (Intervallum.First().Value.Count > Intervallum.Last().Value.Count)
            {

                return new Intervallum(Intervallum.First().Key, Intervallum.Last().Key, Intervallum.First().Value);

            }
            else
            {

                return new Intervallum(Intervallum.Last().Key, null, Intervallum.Last().Value);

            }

           

        }

    }
}
