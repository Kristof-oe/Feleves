using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Ezacsúcsnincs_exception : Exception
    {
        public string neve { get; set; }

        public Ezacsúcsnincs_exception(string üzenet, string neve) : base(üzenet)
        {

            this.neve = neve;

        }
    }
}
