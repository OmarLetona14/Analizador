using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico.Helper
{
    class CustomFileReader
    {
        String sLine = "", auxLine;
        ArrayList arrText;
        FileStream fileStream;
        StreamWriter sw;

        public void ReadArchive(String filename, RichTextBox codeText)
        {
         
            arrText = new ArrayList();
            StreamReader objReader = new StreamReader(filename);
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                    arrText.Add(sLine);
            }
            objReader.Close();

            foreach (String line in arrText)
            {
                auxLine += line + Environment.NewLine;

            }
            codeText.Text = auxLine;
        }

        public void SaveFile(String filename, RichTextBox codeText)
        {
            if (!File.Exists(filename))
            {
                fileStream = File.Create(filename);
                fileStream.Close();
                WriteArchive(filename, codeText);
                MessageBox.Show("Archivo guardado correctamente", "Analizador",
                    MessageBoxButtons.OK);
            }
            

        }

        public void WriteArchive(String filename, RichTextBox codeText)
        {
            try
            {
                sw = new StreamWriter(filename);
                foreach (String lineStr in codeText.Lines)
                {
                    sw.WriteLine(lineStr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            sw.Close();
        }
    }
}
