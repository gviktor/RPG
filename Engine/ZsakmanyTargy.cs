using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class ZsakmanyTargy
    {
        public Item Reszletek { get; set; }
        public int SzazalekbanEsik { get; set; }
        public bool AlapertelmezettE { get; set; }

        public ZsakmanyTargy(Item reszletek, int szazalekbanEsik, bool alapertelmezettE)
        {
            Reszletek = reszletek;
            SzazalekbanEsik = szazalekbanEsik;
            AlapertelmezettE = alapertelmezettE;
        }
    }
}