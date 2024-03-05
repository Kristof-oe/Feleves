using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class Nincsezafájl_exception : Exception
    {
        public Nincsezafájl_exception(string fájlnév) : base("Nincs ilyen fájl az adott mappában: " + fájlnév)
        {
            nincs_fájl = fájlnév;
        }

        public string nincs_fájl { get; private set; }

    }
}
