using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Leny
    {
        public int AktualisHP { get; set; }
        public int MaxHP { get; set; }
        public Leny(int aktualisHP, int maximumHP)
        {
            AktualisHP = aktualisHP;
            MaxHP = maximumHP;
        }
    }
}
