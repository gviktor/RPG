using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class TaskaTargy
    {
        public Targy Reszletek { get; set; }
        public int Mennyiseg { get; set; }

        public TaskaTargy(Targy leiras, int mennyiseg)
        {
            Reszletek = leiras;
            Mennyiseg = mennyiseg;
        }
    }
}