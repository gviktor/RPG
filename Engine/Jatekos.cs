using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class Jatekos : Leny
    {
        public int Arany { get; set; }
        public int XP { get; set; }
        public int Szint { get; set; }
        public List<TaskaItem> Taska { get; set; }
        public List<JatekosKuldetes> Kuldetesek { get; set; }

        public Jatekos(int aktualisHP, int maxHP,
int arany, int xp, int szint) : base(aktualisHP, maxHP)
{
            Arany = arany;
            XP = xp;
            Szint = szint;
            Taska = new List<TaskaItem>();
            Kuldetesek = new List<JatekosKuldetes>();
        }
    }
}
