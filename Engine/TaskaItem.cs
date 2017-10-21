using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class TaskaItem
    {
        public Item Reszletek { get; set; }
        public int Mennyiseg { get; set; }

        public TaskaItem(Item leiras, int mennyiseg)
        {
            Reszletek = leiras;
            Mennyiseg = mennyiseg;
        }
    }
}