using System;

namespace Conversions.Classes
{
    public static class Cbase
    {
        public static int BinaireDecimal(string sBinaire)
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
        public static int HexaDec(string sHexa)
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
        public static string DecBin(int division)
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
        public static string DecHexa(int division)
        {
            string nbHexa = "";
            int reste;
            while (division != 0)
            {
                reste = division % 16;
                if (reste >= 10)
                    nbHexa = nbHexa.Insert(0, ((char)(reste - 10 + 'A')).ToString());
                else
                    nbHexa = nbHexa.Insert(0, (reste).ToString());
                division = (division - reste) / 16;
            }
            return nbHexa;
        }
    }
}