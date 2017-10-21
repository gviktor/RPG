using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Fegyver : Item
    {
        public int MinSebzes { get; set; }
        public int MaxSebzes { get; set; }
        public Fegyver(int id, string nev, string tobbesszam, int minSebzes, int maxSebzes) : base(id, nev, tobbesszam)
{
            MinSebzes = minSebzes;
            MaxSebzes = maxSebzes;
        }
    }
}
