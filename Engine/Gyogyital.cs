using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Gyogyital : Item
    {
        public int MennyitGyogyit { get; set; }
        public Gyogyital(int id, string nev, string tobbesSzam, int mennyitGyogyit) : base(id, nev, tobbesSzam)
        {
            MennyitGyogyit = mennyitGyogyit;
        }
    }
}
