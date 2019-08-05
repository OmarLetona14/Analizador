using AnalizadorLexico.Helper;
using AnalizadorLexico.Model;
using System;
using System.Collections;
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
        int state;
        String Op_filename, Sa_filename, entrada, auxLex;
        public static String currentFile;
        OpenFileDialog openFile;
        RichTextBox codeTxt;
        Boolean identificador, sintaxisError, savedOnce;
        SaveFileDialog saveFile;
        CustomFileReader reader;
        private int page_count = 2;
        RichTextBox CodeTxt = null;
        ArrayList matrix;

        private void crearPestaña(String titulo)
        {
            TabPage tab = new TabPage()
            {
                Text = "Pestaña " + page_count,
                Name = "Tab" + page_count
            };
            CodeTxt = new RichTextBox()
            {
                Dock = DockStyle.Fill,
                AcceptsTab = true
            };
            CodeTxt.Name = "CodeTxt";
            tab.Controls.Add(CodeTxt);
            tabsControlPane.Controls.Add(tab);
            page_count += 1;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            crearPestaña("");
        }

        private void AddPage(TabPage tab, string v)
        {
            
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TabsControlPane_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void GuardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             guardarComo();
            
        }

        public void guardarComo()
        {
            reader = new CustomFileReader();
            saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivos de entrada(*.ly)|*.ly";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Sa_filename = saveFile.FileName;
                reader.SaveFile(Sa_filename, CodeTxt);
            }
            saveFile.Dispose();
        }

        public ArrayList Analizar(String entrance)
        {
            entrance += "#";
            matrix = new ArrayList();
            state = 0;
            auxLex = "";
            Char c;
            for (int i = 0; i<=entrance.Length;i++)
            {
                c = entrance.ElementAt(i);
                switch (state)
                {



                }


            }

            return matrix;
        }

        

        public analizador()
        {
            InitializeComponent();
        }

        private void AbrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            currentFile = "";
            openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de entrada(*.ddc)|*.ddc";
            
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                reader = new CustomFileReader();
                Op_filename = openFile.FileName;
                currentFile = Op_filename;
                RichTextBox txtBox = null;
              
                foreach (Control control in tabsControlPane.SelectedTab.Controls)
                {
                    if (control.Name == "CodeTxt")
                    {
                        txtBox = new RichTextBox();
                        txtBox = (RichTextBox)control;
                    }
                }

              
                reader.ReadArchive(Op_filename, txtBox);
            }
            tabsControlPane.SelectedTab.Text = Op_filename;
            openFile.Dispose();
        }
    }
}
