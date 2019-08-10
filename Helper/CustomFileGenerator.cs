using AnalizadorLexico.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Helper
{
    class CustomFileGenerator
    {
        StreamWriter sw;

        public void generateHTMLTokensFile(List<MatrixToken> tokens, String filename)
        {
            String init;
            try
            {
                sw = new StreamWriter(filename);
                init = "<html>" +
                    "<head>" + "</head>" +
                    "<body>" +
                        "<table class=\"egt\">" +
                        "<tr>" +
                            "<th> Numero </th>" +
                            "<th > Lexema </th>" +
                            "<th> Tipo </th>" +
                          "</tr>";
                foreach (MatrixToken token in tokens)
                {
                                        init += "<tr>"
                            + "<td align=\"center\">" + token.getNumber() + "</td>"
                            + "<td>" + token.getToken().getValor() + "</td>"
                            + "<td>" + token.getToken().getTipoToken() + "</td>"
                        + "</tr>";
                }
                init += "</body>" +
                    "</html> ";
                sw.Write(init);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            sw.Close();
        }


        public void generateErrorsHTMLFile(List<Error> errores, String filename)
        {
            String init;
            try
            {
                sw = new StreamWriter(filename);
                init = "<html>" +
                    "<head>" + "</head>" +
                    "<body>" +
                        "<table class=\"egt\" style= \"text - align:center;\" >" +
                        "<tr>" +
                            "<th> Numero de error </th>" +
                            "<th> Error </th>" +
                            "<th> Descripcion </th>" +
                          "</tr>";
                foreach (Error error in errores)
                {

                    init += "<tr>"
                            + "<td>" + error.getNoError() + "</td>"
                            + "<td>" + error.getLexema() + "</td>"
                            + "<td>" + error.getDescripcion() + "</td>"
                        + "</tr>";
                }
                init += "</body>" +
                    "</html> ";
                sw.Write(init);
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            sw.Close();
            
            

        }
    }
}
