using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Ellenfel : Leny
    {
        public int ID { get; set; }
        public string Nev { get; set; }
        public int MaxSebzes { get; set; }
        public int ErtekXP { get; set; }
        public int ErtekArany { get; set; }
        public List<ZsakmanyTargy> MiketDobhat { get; set; }
        public Ellenfel(int id, string nev, int maxSebzes,
int ertekXP, int ertekArany, int aktualisHP, int maxHP) : 
            base(aktualisHP, maxHP)
{
            ID = id;
            Nev = nev;
            MaxSebzes = maxSebzes;
            ErtekXP = ertekXP;
            ErtekArany = ertekArany;
            MiketDobhat = new List<ZsakmanyTargy>();
        }
    }
}
