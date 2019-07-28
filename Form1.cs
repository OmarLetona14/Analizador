using AnalizadorLexico.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class analizador : Form
    {
        String Op_filename, Sa_filename, entrada, auxLex;
        public static String currentFile;
        OpenFileDialog openFile;
        RichTextBox codeTxt;
        Boolean identificador, sintaxisError, savedOnce;
        SaveFileDialog saveFile;
        CustomFileReader reader;

        private void GuardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String filenameSave = currentFile;
            if (!File.Exists(currentFile))
            {
                guardarComo();

            }
            else if (File.Exists(currentFile))
            {
                reader.SaveFile(currentFile, CodeTxt);
            }

            this.Text = currentFile;
        }

        private void GuardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             guardarComo();
            
        }

        public void guardarComo()
        {
            reader = new CustomFileReader();
            saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivos de entrada(*.ddc)|*.ddc";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Sa_filename = saveFile.FileName;
                reader.SaveFile(Sa_filename, CodeTxt);
            }
            saveFile.Dispose();
        }

        

        public analizador()
        {
            InitializeComponent();
        }

        private void AbrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CodeTxt.Clear();
            currentFile = "";
            openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de entrada(*.ddc)|*.ddc";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                reader = new CustomFileReader();
                codeTxt = new RichTextBox();
                Op_filename = openFile.FileName;
                currentFile = Op_filename;
                codeTxt = CodeTxt;
                reader.ReadArchive(Op_filename, codeTxt);

            }
            openFile.Dispose();
        }
    }
}
