using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace RPG
{
    public partial class Fokepernyo : Form
    {
        Jatekos jatekos1;
        public Fokepernyo()
        {
            InitializeComponent();
            jatekos1 = new Jatekos(10,10,20,0,1);
            jatekos1.AktualisHP = 10;
            jatekos1.MaxHP = 10;
            jatekos1.Arany = 20;
            jatekos1.XP = 0;
            jatekos1.Szint = 1;
            lblHP.Text = jatekos1.AktualisHP.ToString();
            lblArany.Text = jatekos1.Arany.ToString();
            lblXP.Text = jatekos1.XP.ToString();
            lblSzint.Text = jatekos1.Szint.ToString();
            Hely hely1 = new Hely(1, "Barlang", "Itt laksz");
        }
    }
}
