using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class KuldeteshezTargy
    {
        public Targy Reszletek { get; set; }
        public int Mennyiseg { get; set; }

        public KuldeteshezTargy(Targy reszletek, int mennyiseg)
        {
            Reszletek = reszletek;
            Mennyiseg = mennyiseg;
        }
    }
}