using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico.Helper
{
    class Pintar
    {
        String[] reservadas = new String[] { "planificador", "descripcion", "año", "dia", "mes", "imagen" };
        public void pintarLetras(string cadena, RichTextBox richText)
        {
            for (int i = 0; i < reservadas.Length; i++)
            {
                int Inicio = richText.Find(reservadas[i].ToLower());
                int Final = richText.Text.LastIndexOf(reservadas[i].ToLower());
                if ((Inicio >= 0) && (Final >= 0))
                {
                    richText.SelectionStart = Final;
                    richText.SelectionLength = reservadas[i].Length;
                    richText.SelectionColor = Color.Blue;
                }
                else
                {
                    int final = richText.Text.LastIndexOf("//");
                    if ((richText.Find("//") >= 0) && (final >= 0))
                    {
                        richText.SelectionColor = Color.Green;

                    }
                    else
                    {
                        richText.SelectionColor = Color.Black;
                    }
                }
                richText.SelectionStart = richText.Text.Length;
                richText.SelectionColor = Color.Black;

            }

        }
    }
}
