using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class frfmConversions : Form
    {
        public frfmConversions()
        {
            InitializeComponent();
        }
        private int BinaireDecimal(string sBinaire)
        {
            int nbDecimal = 0;
            int i;
            int exposant = 0;
            for (i = sBinaire.Length - 1; i >= 0; i--)
            {
                if ((sBinaire[i] == '1'))
                    nbDecimal += (int)Math.Pow(2, exposant);
                exposant++;
            }
            return nbDecimal;
        }
        private int HexaDec(string sHexa)
        {
            int nbDecimal = 0;
            int i;
            int exposant = 0;
            for (i = sHexa.Length - 1; i >= 0; i--)
            {
                if (sHexa[i] <= '9' && sHexa[i] >= '0')
                {
                    int valeur = int.Parse(sHexa[i].ToString());
                    nbDecimal += valeur * (int)Math.Pow(16, exposant);
                }
                else if (sHexa[i] <= 'F' && sHexa[i] >= 'A')
                {
                    int valeur = (int)(sHexa[i] - 'A') + 10;
                    nbDecimal += valeur * (int)Math.Pow(16, exposant);
                }
                exposant++;

            }
            return nbDecimal;
        }
        private string DecBin(int division)
        {
            int reste;
            string nbBin = "";
            while (division > 0)
            {
                reste = division % 2;
                division /= 2;
                nbBin = reste.ToString() + nbBin;
            }
            return nbBin;
        }

        private string DecHexa(int division)
        {
            string nbHexa = "";
            int reste;
            while (division != 0)
            {
                reste = division % 16;
                if (reste >= 10)
                {
                    nbHexa = nbHexa.Insert(0, ((char)(reste - 10 + 'A')).ToString());
                }
                else
                {
                    nbHexa = nbHexa.Insert(0, (reste).ToString());
                }
                division = (division - reste) / 16;            
            }
            return nbHexa;
        }

        private void btnBinaireDecimal_Click(object sender, EventArgs e)
        {
            //lecture
            string sBinaire = txtBinaireADec.Text;
            int i = 0;

            //validation
            if (sBinaire.Length > 8)
            {
                MessageBox.Show("doit être sur 8 bits ou moins");
                return;
            }
            while ((i < sBinaire.Length) && (sBinaire[i] == '0' || sBinaire[i] == '1'))
            {
                i++;
            }
            if (i < sBinaire.Length)
            {
                MessageBox.Show("quand c'est binaire, c'est des 1 ou des 0");
                return;
            }
            //affichage
            txtDecimalDeBin.Text = BinaireDecimal(sBinaire).ToString();
        }

        private void btnDecBin_Click(object sender, EventArgs e)
        {
            string sDec = txtDecimalABin.Text;
            if (sDec.Length > 8)
            {
                MessageBox.Show("Doit être sur 8 bits ou moins");
                return;
            }

            if (!int.TryParse(sDec, out int division))
            {
                MessageBox.Show("L'entrer doit etre un chifre");
                return;
            }

            txtBinaireDeDec.Text = DecBin(division);
        }
        private void btnHexaDec_Click(object sender, EventArgs e)
        {
            string sHexa = txtHexaADec.Text;
            int i = 0;
            if (sHexa.Length > 8)
            {
                MessageBox.Show("doit être sur 8 bits ou moins");
                return;
            }
            while ((i < sHexa.Length))
            {
                if (sHexa[i] <= 'F' && sHexa[i] >= '0')
                    i++;
                else
                {
                    MessageBox.Show("Doit etre entre 0 et F");
                    return;
                }
            }

            txtDecimalDeHexa.Text = HexaDec(sHexa).ToString();
        }

        private void btnDecHexa_Click(object sender, EventArgs e)
        {
            string sDec = txtDecimalAHexa.Text;
            if (sDec.Length > 8)
            {
                MessageBox.Show("doit être sur 8 bits ou moins");
                return;
            }
            if (!int.TryParse(sDec, out int division))
            {
                MessageBox.Show("L'entrer doit etre un chifre");
                return;
            }

            txtHexaDeDec.Text = DecHexa(division);
        }

        private void btnHexaBin_Click(object sender, EventArgs e)
        {

        }
    }
}

