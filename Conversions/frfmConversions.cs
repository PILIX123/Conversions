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

        private void btnBinaireDecimal_Click(object sender, EventArgs e)
        {
            //lecture
            string sBinaire = txtBinaireADec.Text;
            int nbDecimal = 0;
            int i = 0;
            int exposant = 0;

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

            //traitement
            for (i = sBinaire.Length - 1; i >= 0; i--)
            {
                if ((sBinaire[i] == '1'))
                    nbDecimal += (int)Math.Pow(2, exposant);
                exposant++;
            }

            //affichage
            txtDecimalDeBin.Text = nbDecimal.ToString();

        }

        private void btnDecBin_Click(object sender, EventArgs e)
        {

        }
    }
}
