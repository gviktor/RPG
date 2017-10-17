using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Item
    {
        public int ID { get; set; }
        public string Nev { get; set; }
        public Item(int id, string nev, string tobbesSzam)
        {
            ID = id;
            Nev = nev;
        }
    }
}
