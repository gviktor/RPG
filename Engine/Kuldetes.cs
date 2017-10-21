using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Kuldetes
    {
        public int ID { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }
        public int ErtekXP { get; set; }
        public int ErtekArany { get; set; }
        public Targy ErtekItem { get; set; }
        public List<KuldeteshezTargy> KuldeteshezSzuksegesTargyak { get; set; }
        public Kuldetes(int id, string nev, string leiras,
int ertekXP, int ertekArany)
        {
            ID = id;
            Nev = nev;
            Leiras = leiras;
            ErtekXP = ertekXP;
            ErtekArany = ertekArany;
            KuldeteshezSzuksegesTargyak = new List<KuldeteshezTargy>();
        }
    }
}
