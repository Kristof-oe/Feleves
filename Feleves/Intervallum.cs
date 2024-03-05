using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Intervallum
    {
        public Intervallum(DateTime intervallum_kezdete, DateTime? intervallum_vége , List<személy> intervallum_élői)
        {
            this.intervallum_élői = intervallum_élői;

            this.intervallum_kezdete = intervallum_kezdete;

            this.intervallum_vége = intervallum_vége;

        }

        public List<személy> intervallum_élői { get; set; }

        public DateTime intervallum_kezdete { get; set; }

        public DateTime? intervallum_vége { get; set; }

        public double Átlagkor()
        {

            List<double> kor = new List<double>();

            foreach (var item in intervallum_élői)
            {

                kor.Add(((intervallum_kezdete - item.született).TotalDays) / 365.2425);

            }

            return (kor.Sum()) / kor.Count;
        }

    }
}
