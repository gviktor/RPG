using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Fegyver : Targy
    {
        public int MinSebzes { get; set; }
        public int MaxSebzes { get; set; }
        public Fegyver(int id, string nev, int minSebzes, int maxSebzes) : base(id, nev)
{
            MinSebzes = minSebzes;
            MaxSebzes = maxSebzes;
        }
    }
}
