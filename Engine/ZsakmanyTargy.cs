using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ZsakmanyTargy
    {
        public Targy Reszletek { get; set; }
        public int SzazalekbanEsik { get; set; }
        public bool AlapertelmezettE { get; set; }

        public ZsakmanyTargy(Targy reszletek, int szazalekbanEsik, bool alapertelmezettE)
        {
            Reszletek = reszletek;
            SzazalekbanEsik = szazalekbanEsik;
            AlapertelmezettE = alapertelmezettE;
        }
    }
}