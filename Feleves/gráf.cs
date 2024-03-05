using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{

    class gráf<T, K> where K : IK
    {
        public delegate void BejaroHandler(T tartalom);

        public class Él
        {
            public T merről;

            public T merre;

            public K tipus;

        }

        List<List<Él>> szomszédok;
        public List<T> csúcsok { get; }

        public gráf(T gyoker)
        {

            szomszédok = new List<List<Él>>();

            csúcsok = new List<T>();

            ucsucs(gyoker);

        }
        public void törlés(T csucs)
        {

            List<T> torlendo = new List<T>();

            int index = csúcsok.IndexOf(csucs);

            foreach (Él item in szomszédok[index])
            {

                torlendo.Add(item.merre);

            }

            foreach (T item in torlendo)
            {

                List<Él> maradt_szomszéd = new List<Él>();

                int helyzet = csúcsok.IndexOf(item);

                foreach (Él el in szomszédok[helyzet])
                {

                    if (!el.merre.Equals(csucs))
                    {

                        maradt_szomszéd.Add(el);

                    }

                }

                szomszédok[helyzet] = maradt_szomszéd;
            }

            szomszédok.Remove(szomszédok[index]);

            csúcsok.Remove(csucs);

        }
        public void ucsucs(T csucs)
        {

            csúcsok.Add(csucs);

            szomszédok.Add(new List<Él>());

        }


        public void uél(T merről, T merre, K tipus)
        {

            int index = csúcsok.IndexOf(merről);

            szomszédok[index].Add(new gráf<T, K>.Él()
            {

                merről = merről,

                merre = merre,

                tipus = tipus
            });
        }
        public bool ÉlhúzódikE(T merről, T merre)
        {

            bool vanEl = false;

            int index = csúcsok.IndexOf(merről);

            foreach (Él item in szomszédok[index])
            {

                if ((item.merre).Equals(merre))
                {

                    vanEl = true;

                }

            }

            return vanEl;

        }

        public List<Él> CsúcsÉlei(T tartalom)
        {

            if (!csVanE(tartalom))
            {

                throw new Ezacsúcsnincs_exception("Csucs nincs benne! {0}", tartalom.ToString());

            }

            int segéd = csúcsok.IndexOf(tartalom);

            return szomszédok[segéd];

        }

        public bool csVanE(T csúcs)
        {

            return csúcsok.Contains(csúcs);

        }

        public void Járás(T merről, BejaroHandler _metodus)
        {

            BejaroHandler metodus = _metodus;

            Queue<T> S = new Queue<T>();

            List<T> F = new List<T>();

            S.Enqueue(merről);

            F.Add(merről);

            while (S.Count != 0)
            {

                T k = S.Dequeue();

                metodus?.Invoke(k);

                foreach (Él x in CsúcsÉlei(k))
                {

                    if (!F.Contains(x.merre) && x.tipus.Járható())
                    {

                        S.Enqueue(x.merre);

                        F.Add(x.merre);

                    }

                }
            }
        }


    }
}
