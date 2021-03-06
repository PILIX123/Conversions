/*Pierre-Luc Robitaille & Victor Saulnier
 * Lab Conversion
 * 01/09/2021
 * Travail sur l<utilisation de GitHub et de conversion entre Hexa, Decimal et Binaire*/
using System;
using System.Windows.Forms;
using Conversions.Classes;

namespace Conversions
{
    public partial class frfmConversions : Form
    {
        public frfmConversions()
        { InitializeComponent(); }
        private string validBin(string sBinaire)
        {
            if(sBinaire.Length > 8 || sBinaire.Length < 1)
                return "L'entré doit être sur 8 bits ou moins";
            for(int i = 0; i < sBinaire.Length; i++)
                if (sBinaire[i] != '0' && sBinaire[i]!= '1')
                    return "Lorsque c'est binaire c'est des 1 ou des 0";
            return sBinaire;
        }
        private int validDec(string sDec)
        {
            if(!int.TryParse(sDec, out int division))
                return -1;
            else if(division<0 || division > 255)
                return -1;
            else
                return division;
        }
        private string validHex(string sHexa)
        {
            if (sHexa.Length > 2 || sHexa.Length < 1)
                return "L'entrée doit être entre 1 et 2 charactère";
            for(int i = 0; i < sHexa.Length; i++)
                if(sHexa[i] > 'F' || sHexa[i] < '0')
                    return "Les charactère doivent être entre 0 et F";
            return sHexa;
        }
        private void btnBinaireDecimal_Click(object sender, EventArgs e)
        {
            //lecture
            string sBinaire = txtBinaireADec.Text;
            //validation
            if (validBin(sBinaire) != sBinaire)
            { MessageBox.Show(validBin(sBinaire)); return; }
            //affichage
            txtDecimalDeBin.Text = Cbase.BinaireDecimal(sBinaire).ToString();
        }

        private void btnDecBin_Click(object sender, EventArgs e)
        {
            //lecture
            string sDec = txtDecimalABin.Text;
            //validation
            if (validDec(sDec) == -1)
            { MessageBox.Show("L'entrée doit être un entier entre 0 et 255"); return; }
            //affichage
            txtBinaireDeDec.Text = Cbase.DecBin(validDec(sDec));
        }

        private void btnHexaDec_Click(object sender, EventArgs e)
        {
            //lecture
            string sHexa = txtHexaADec.Text;
            //validation
            if (validHex(sHexa) != sHexa)
            { MessageBox.Show(validHex(sHexa)); return; }
            //affichage
            txtDecimalDeHexa.Text = Cbase.HexaDec(sHexa).ToString();
        }

        private void btnDecHexa_Click(object sender, EventArgs e)
        {
            //lecture
            string sDec = txtDecimalAHexa.Text;
            //validation
            if (validDec(sDec) == -1)
            { MessageBox.Show("L'entrée doit être un chiffre entre 0 et 255"); return; }
            //affichage
            txtHexaDeDec.Text = Cbase.DecHexa(validDec(sDec));
        }

        private void btnHexaBin_Click(object sender, EventArgs e)
        {
            //lecture
            string sHexa = txtHexaABin.Text;
            //validation
            if (validHex(sHexa) != sHexa)
            { MessageBox.Show(validHex(sHexa)); return; }
            //affichage
            txtBinDeHexa.Text = Cbase.DecBin(Cbase.HexaDec(sHexa));
        }

        private void btnBinHexa_Click(object sender, EventArgs e)
        {
            //lecture
            string sBinaire = txtBinAHexa.Text;
            //validation
            if (validBin(sBinaire) != sBinaire)
            { MessageBox.Show(validBin(sBinaire)); return; }
            //affichage
            txtHexaDeBin.Text = Cbase.DecHexa(Cbase.BinaireDecimal(sBinaire));
        }
    }
}

