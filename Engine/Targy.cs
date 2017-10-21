using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Targy
    {
        public int ID { get; set; }
        public string Nev { get; set; }
        public Targy(int id, string nev)
        {
            ID = id;
            Nev = nev;
        }
    }
}
