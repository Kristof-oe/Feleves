using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Házas : IK
    {
        public DateTime? házasság_vége { get; set; }
        public DateTime házasság_kezdete { get; set; }

        public Házas(DateTime házasság_kezdete, DateTime? házasság_vége = null)
        {
           
            this.házasság_vége = házasság_vége;

            this.házasság_kezdete = házasság_kezdete;

        }

        public bool Járható()
        {

            return házasság_vége == null;

        }
    }
}
