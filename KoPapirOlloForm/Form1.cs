using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoPapirOlloForm
{
    public partial class frmFo : Form
    {
        public int Jatekos { get; private set; }
        public int Szgep { get; private set; }

        public frmFo()
        {
            InitializeComponent();
            lblJatekos.Text = "";
            lblSzamitogep.Text = "";
            lblGyoztes.Text = "";
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUj_Click(object sender, EventArgs e)
        {
            KezdetiBeallitas();
        }

        private void KezdetiBeallitas()
        {
            lblGyoztes.Text = "";
            lblJatekos.Text = "0";
            lblSzamitogep.Text = "0";
            Jatekos = 0;
            Szgep = 0;
        }

        private void btnKo_Click(object sender, EventArgs e)
        {
            pbJatekos.Image = Image.FromFile("ko.jpg");
            Fordulo(1);
        }

        private void btnPapir_Click(object sender, EventArgs e)
        {
            pbJatekos.Image = Image.FromFile("papir.jpg");
            Fordulo(2);
        }

        private void btnOllo_Click(object sender, EventArgs e)
        {
            pbJatekos.Image = Image.FromFile("ollo.jpg");
            Fordulo(3);
        }

        private void EredmenyBeallitas()
        {
            lblJatekos.Text = Jatekos.ToString();
            lblSzamitogep.Text = Szgep.ToString();
        }

        private void Fordulo(int jatekos)
        {
            Random rnd = new Random();
            int gep = rnd.Next(1, 4);

            switch (gep)
            {
                case 1:
                    pbSzamitogep.Image = Image.FromFile("ko.jpg");
                    break;
                case 2:
                    pbSzamitogep.Image = Image.FromFile("papir.jpg");
                    break;
                case 3:
                    pbSzamitogep.Image = Image.FromFile("ollo.jpg");
                    break;
            }

            

            if (gep==jatekos)
            {
                Jatekos++;
                Szgep++;
                lblGyoztes.Text = "Döntetlen";
            }
            else
            {
                //kő:1  papír:2  olló:3
                if ((jatekos == 1 && gep == 3) || (jatekos == 2 && gep == 1) || (jatekos == 3 && gep == 2))
                {
                    Jatekos++;
                    lblGyoztes.Text = "Játékos";
                }
                else
                {
                    Szgep++;
                    lblGyoztes.Text = "Számítógép";
                }
            }
            EredmenyBeallitas();
        }
    }
}
