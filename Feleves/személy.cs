using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feleves
{
    class személy
    {
        public string név { get; set; }
        public DateTime született { get; set; }
        public DateTime? elhunyt { get; set; }

        public List<személy> gyermek;

        public List<személy> házastárs;

        public személy(string neve, DateTime született, DateTime? elhunyt =null)
        {
            this.név = neve;

            this.született = született;
            
            this.elhunyt = elhunyt;
           
            gyermek = new List<személy>();
            
            házastárs = new List<személy>();

        }

        public override bool Equals(object obj)
        {
            személy x = this;

            személy y = obj as személy;

            return x.név == y.név;

        }

        public override int GetHashCode()
        {
            int hashCode = -1810954793;

            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(név);

            return hashCode;
        }

        public override string ToString()
        {
            return "Neve: " + név.PadRight(10) + "Született: " + született.Year + "." + született.Month + "." + született.Day;
        }
    }
}
