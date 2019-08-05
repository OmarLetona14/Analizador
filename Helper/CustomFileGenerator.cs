using AnalizadorLexico.Model;
using System;
using System.Collections.Generic;
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
                            + "<td>" + token.getNumber() + "</td>"
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
    }
}
