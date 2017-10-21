using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Gyogyital : Targy
    {
        public int MennyitGyogyit { get; set; }
        public Gyogyital(int id, string nev, int mennyitGyogyit) : base(id, nev)
        {
            MennyitGyogyit = mennyitGyogyit;
        }
    }
}
