using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Hely
    {
        public int ID { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }

        public Item ItemABelepeshez { get; set; }
        public Kuldetes KuldetesVanItt { get; set; }
        public Ellenfel EllenfelVanItt { get; set; }
        public Hely HelyEszakra { get; set; }
        public Hely HelyKeletre { get; set; }
        public Hely HelyDelre { get; set; }
        public Hely HelyNyugatra { get; set; }

        public Hely(int id, string nev, string leiras, 
            Item itemABelepeshez = null,
            Kuldetes kuldetesVanItt = null,
            Ellenfel ellenfelVanItt = null)
        {
            ID = id;
            Nev = nev;
            Leiras = leiras;
            ItemABelepeshez = itemABelepeshez;
            KuldetesVanItt = kuldetesVanItt;
            EllenfelVanItt = ellenfelVanItt;
        }
    }
}
