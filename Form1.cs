using AnalizadorLexico.Helper;
using AnalizadorLexico.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        String Op_filename, Sa_filename,htmlFile_route;
        public static String currentFile;
        OpenFileDialog openFile;
        SaveFileDialog saveFile;
        CustomFileReader reader;
        private int page_count = 1;
        RichTextBox CodeTxt = null;
        Analizador analisis;
        List<Planificacion> plans;
        CustomFileGenerator file;
        List<MatrixToken> tokens;

        private void crearPestaña()
        {
            if (!button1.Enabled) {
                button1.Enabled = true;
            }
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
            crearPestaña();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            GenerarPlanificador generate = new GenerarPlanificador();
            analisis = new Analizador();
            tokens = new List<MatrixToken>();
            file = new CustomFileGenerator();
            tokens = analisis.analizar(getTextBox().Text);
            if (getTextBox()!=null)
            {
                if (!Analizador.sintaxisError)
                {
                    htmlFile_route = "C:\\Users\\Omar\\Documents\\Omar\\Lenguajes Formales y de programación\\AnalizadorLexico" +
                        "\\AnalizadorLexico\\Helper\\tokens.html";
                    file.generateHTMLTokensFile(tokens, htmlFile_route);
                    Process.Start(htmlFile_route);
                    analisis.imprimirTokens();
                    plans = generate.generar(tokens);
                   // generateTreeView();

                }
                else
                {
                    htmlFile_route = "D:\\Users\\Omar\\Desktop\\errores.html";
                    file.generateErrorsHTMLFile(Analizador.errores, htmlFile_route);
                    MessageBox.Show("Ocurrió un error al leer el código", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Analizador.sintaxisError = false;
                }
                
            }
            

        }

        public void generateTreeView()
        {
            foreach (Planificacion plan in plans)
            {
                PlanificacionTree.Nodes[0].Text = plan.Nombre;
                for (int y = 0; y <= plan.Years.Count; y++)
                {
                    PlanificacionTree.Nodes[1].Text = Convert.ToString(plan.Years[y].YearVariable);
                    for (int m = 0; m <= plan.Years[y].Mouths.Count; m++)
                    {
                        PlanificacionTree.Nodes[2].Text = Convert.ToString(plan.Years[y].Mouths[m].MouthVariable);
                        for (int d = 0; d <= plan.Years[y].Mouths[m].Days.Count;d++)
                        {
                            PlanificacionTree.Nodes[3].Text = Convert.ToString(plan.Years[y].Mouths[m].Days[d].DayVariable);
                        }
                    }
                }
                
            }
        }


        private void GuardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             guardarComo();
            
        }

        private void PlanificacionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

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

       

        

        public analizador()
        {
            InitializeComponent();
        }

        private void AbrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabsControlPane.TabCount == 0) {
                crearPestaña();
                currentFile = "";
                openFile = new OpenFileDialog();
                openFile.Filter = "Archivos de entrada(*.ly)|*.ly";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    reader = new CustomFileReader();
                    Op_filename = openFile.FileName;
                    currentFile = Op_filename;
                    reader.ReadArchive(Op_filename, getTextBox());
                }
                tabsControlPane.SelectedTab.Text = Op_filename;
                openFile.Dispose();
            }
            else
            {
                currentFile = "";
                openFile = new OpenFileDialog();
                openFile.Filter = "Archivos de entrada(*.ly)|*.ly";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    reader = new CustomFileReader();
                    Op_filename = openFile.FileName;
                    currentFile = Op_filename;
                    reader.ReadArchive(Op_filename, getTextBox());
                }
                tabsControlPane.SelectedTab.Text = Op_filename;
                openFile.Dispose();
            }
            if (!button1.Enabled)
            {
                button1.Enabled = true;
            }

        }

        public RichTextBox getTextBox()
        {
            RichTextBox txtBox = null;
            if (tabsControlPane.TabCount!=0)
            {
                foreach (Control control in tabsControlPane.SelectedTab.Controls)
                {
                    if (control.Name == "CodeTxt")
                    {
                        txtBox = new RichTextBox();
                        txtBox = (RichTextBox)control;
                    }
                }
            }
            return txtBox;
        }
    }
}
