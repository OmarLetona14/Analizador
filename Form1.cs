using AnalizadorLexico.Helper;
using AnalizadorLexico.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Day = AnalizadorLexico.Model.Day;

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
        String tab_name;
        Pintar pintar =  new Pintar();

        private void crearPestaña()
        {
            if (!button1.Enabled) {
                button1.Enabled = true;
            }
            tab_name = "Tab" + page_count;
            TabPage tab = new TabPage()
            {
                Text = "Pestaña " + page_count,
                Name = tab_name
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

            guardarComo();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void generateCalendar()
        {
            if (plans !=null)
            {
                for (int p=0;p<plans.Count;p++)
                {
                    for (int y=0;y<plans[p].Years.Count;y++)
                    {
                        for (int m=0;m< plans[p].Years[y].Mouths.Count;m++)
                        {
                            for (int d = 0;d< plans[p].Years[y].Mouths[m].Days.Count;d++ )
                            {
                                Calendar.AddBoldedDate(plans[p].Years[y].Mouths[m].Days[d].CurrentDate);
                            }
                        }
                    }
                }
            }
            
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (plans!=null)
            {
                plans.Clear();
            }
            contenedor.Panel1.Controls.Clear();
            contenedor.Panel2.Controls.Clear();
            PlanificacionTree.Nodes.Clear();
            Calendar.RemoveAllBoldedDates();
            GenerarPlanificador generate = new GenerarPlanificador();
            analisis = new Analizador();
            tokens = new List<MatrixToken>();
            file = new CustomFileGenerator();
            tokens = analisis.analizar(getTextBox(null).Text);
            if (getTextBox(null)!=null)
            {
                if (!Analizador.lexicError)
                {
                    if (!Analizador.sintError)
                    {
                        htmlFile_route = "C:\\Users\\Omar\\Documents\\Omar\\Lenguajes Formales y de programación\\AnalizadorLexico" +
                       "\\AnalizadorLexico\\Helper\\tokens.html";
                        file.generateHTMLTokensFile(tokens, htmlFile_route);
                        MessageBox.Show("Analisis completado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (MessageBoxButtons.OK == 0)
                        {
                            Process.Start(htmlFile_route);
                            analisis.imprimirTokens();
                            plans = generate.generar(tokens);
                            generateTreeView();
                            generateCalendar();
                        }
                    }
                    else {
                        htmlFile_route = "C:\\Users\\Omar\\Documents\\Omar\\Lenguajes Formales y de programación\\AnalizadorLexico" +
                       "\\AnalizadorLexico\\Helper\\tokens.html";
                        file.generateHTMLTokensFile(tokens, htmlFile_route);
                        MessageBox.Show("El analisis lexico se completó pero existen errores sintacticos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                    }
                   
                    
                }
                else if(Analizador.lexicError)
                {
                    htmlFile_route = "C:\\Users\\Omar\\Documents\\Omar\\Lenguajes Formales y de programación\\AnalizadorLexico" +
                        "\\AnalizadorLexico\\Helper\\erroes.html";
                    file.generateErrorsHTMLFile(Analizador.errores, htmlFile_route);
                    MessageBox.Show("Ocurrió un error al leer el código", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Analizador.lexicError = false;
                    Process.Start(htmlFile_route);
                }
                
            }
            

        }

        public void generateTreeView()
        {
            for(int p = 0; p<plans.Count;p++)
            {
                PlanificacionTree.Nodes.Add(plans[p].Nombre);
                
                PlanificacionTree.Nodes[p].ExpandAll();
                for (int y = 0; y < plans[p].Years.Count; y++)
                {
                    PlanificacionTree.Nodes[p].Nodes.Add(Convert.ToString(plans[p].Years[y].YearVariable));
                    PlanificacionTree.Nodes[p].Nodes[y].Expand();
                    for (int m = 0; m < plans[p].Years[y].Mouths.Count; m++)
                    {
                        PlanificacionTree.Nodes[p].Nodes[y].Nodes.Add(Convert.ToString(plans[p].Years[y].Mouths[m].MouthVariable));
                        PlanificacionTree.Nodes[p].Nodes[y].Nodes[m].Expand();
                        for (int d = 0; d < plans[p].Years[y].Mouths[m].Days.Count;d++)
                        {
                            PlanificacionTree.Nodes[p].Nodes[y].Nodes[m].Nodes.Add(Convert.ToString(plans[p].Years[y].Mouths[m].Days[d].DayVariable));
                            PlanificacionTree.Nodes[p].Nodes[y].Nodes[m].Nodes[d].Expand();

                        }
                    }
                }
                
            }
        }

        
        

        private void GuardarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabsControlPane != null)
            {
                if (tabsControlPane.SelectedTab.Text == "")
                {
                  
                    guardarComo();
                }
                else
                {
                    if (File.Exists(tabsControlPane.SelectedTab.Text))
                    {
                        guardar(tabsControlPane.SelectedTab.Text);
                    }
                    else
                    {
                        guardarComo();
                    } 
                }
            }
            else {
                guardarComo();
            }  
        }

        private void PlanificacionTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

          
        }

        private void guardar(String route)
        {
            reader = new CustomFileReader();
            reader.SaveFile(route, getTextBox(null));
        }

        public void guardarComo()
        {
            reader = new CustomFileReader();
            saveFile = new SaveFileDialog();
            saveFile.Filter = "Archivos de entrada(*.ly)|*.ly";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Sa_filename = saveFile.FileName;
                reader.SaveFile(Sa_filename, getTextBox(null));
                tabsControlPane.SelectedTab.Text = Sa_filename;
            }
            
            saveFile.Dispose();
        }

       

        

        public analizador()
        {
            InitializeComponent();
        }

        private void PlanificacionTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            int mes, dia, anio;
            String planificacion_nombre;
            Day day;
            TreeNode node = new TreeNode();
             node = e.Node;
            if (node.Level==3){
                dia = Convert.ToInt32(node.Text);
                mes = Convert.ToInt32(node.Parent.Text);
                anio = Convert.ToInt32(node.Parent.Parent.Text);
                planificacion_nombre = node.Parent.Parent.Parent.Text;
                day = getDay(planificacion_nombre, dia, mes, anio);
                if (day != null)
                {
                    if (contenedor.Panel1.Controls.Count != 0)
                    {
                        contenedor.Panel1.Controls.Clear();
                    }
                    if (contenedor.Panel2.Controls.Count != 0)
                    {
                        contenedor.Panel2.Controls.Clear();
                    }
                    Label descrip_lbl = new Label() {
                       Height = contenedor.Panel1.Height,
                       Width = contenedor.Panel1.Width
                    };
                    descrip_lbl.Text = day.Description;
                    descrip_lbl.AutoSize = true;
                    Label img = new Label() {
                        Dock = DockStyle.Fill
                    };
                    Image image = null;
                    try
                    {
                        image = Image.FromFile(day.UrlImage);
                        image = resize(contenedor.Panel2.Width -50, contenedor.Panel2.Height-20, image);
                        img.Image = image;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("No se pudo encontrar la imagen especificada");
                    }
                    
                    if (image!=null)
                    {
                        contenedor.Panel2.Controls.Add(img);
                    }
                    contenedor.Panel1.Controls.Add(descrip_lbl);
                }
            }

        }

        public Image resize( int newWidth, int newHeight, Image srcImage)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                gr.DrawImage(srcImage, new Rectangle(0, 0, newWidth, newHeight));
            }
            return newImage;
        }


        private Day getDay(String nombre_plan, int dia, int mes, int anio)
        {
            for (int p = 0; p<plans.Count;p++)
            {
                if (plans[p].Nombre==nombre_plan)
                {
                    for (int y = 0;y<plans[p].Years.Count;y++)
                    {
                        if (plans[p].Years[y].YearVariable==anio)
                        {
                            for (int m=0;m< plans[p].Years[y].Mouths.Count;m++)
                            {
                                if (plans[p].Years[y].Mouths[m].MouthVariable==mes)
                                {
                                    for (int d= 0;d< plans[p].Years[y].Mouths[m].Days.Count;d++)
                                    {
                                        if (plans[p].Years[y].Mouths[m].Days[d].DayVariable==dia)
                                        {
                                            return plans[p].Years[y].Mouths[m].Days[d];
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void abrirArchivo(Boolean nuevo) {
            openFile = new OpenFileDialog();
            openFile.Filter = "Archivos de entrada(*.ly)|*.ly";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (nuevo)
                {
                    crearPestaña();
                }
                currentFile = "";
                reader = new CustomFileReader();
                Op_filename = openFile.FileName;
                currentFile = Op_filename;
                if (nuevo)
                {
                    reader.ReadArchive(Op_filename, getTextBox(tab_name));
                    pintar.pintarLetras(getTextBox(tab_name).Text, getTextBox(tab_name));
                }
                else { reader.ReadArchive(Op_filename, getTextBox(null));
                    pintar.pintarLetras(getTextBox(null).Text, getTextBox(tab_name));
                }
                
            }
            if (Op_filename != null)
            {
                foreach (TabPage tab in tabsControlPane.TabPages)
                {
                    if (tab.Name == tab_name)
                    {
                        tab.Text = Op_filename;
                    }
                }
                if (!button1.Enabled)
                {
                    button1.Enabled = true;
                }
            }
            openFile.Dispose();

        }

        private void AcercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Universidad de San Carlos de Guatemala \n" +
                "Programador: Erick Omar Letona Figueroa \n" +
                "Carnet: 201700377 \n" +
                "Lenguajes formales y de programacion", "Información", MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        
        }
        
        private void TabsControlPane_KeyUp(object sender, KeyEventArgs e)
        {
          //  Pintar(getTextBox(null).Text);
        }


        

        private void AbrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabsControlPane.TabCount == 0) {
                abrirArchivo(true);
            }
            else
            {
                if (getTextBox(null).Text == "")
                {
                    abrirArchivo(false);
                }
                else {
                    abrirArchivo(true);
                }
            }
            

        }

        public RichTextBox getTextBox(String tab_name)
        {
            if (tab_name == null)
            {
                RichTextBox txtBox = null;
                if (tabsControlPane.TabCount != 0)
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
            else {
                RichTextBox txtBox = null;
                if (tabsControlPane.TabCount != 0)
                {
                    foreach (TabPage tab in tabsControlPane.TabPages)
                    {
                        if (tab.Name == tab_name)
                        {
                            foreach (Control control in tab.Controls)
                            {
                                txtBox = new RichTextBox();
                                txtBox = (RichTextBox)control;
                            }
                        }
                    }
                }
                return txtBox;
            }


           
        }
    }
}
