using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class JatekosKuldetes
    {
        public Kuldetes Reszletek { get; set; }
        public bool TeljesitveE { get; set; }

        public JatekosKuldetes(Kuldetes reszletek)
        {
            Reszletek = reszletek;
            TeljesitveE = false;
        }
    }
}