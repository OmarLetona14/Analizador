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
                    "<head>" +
                     "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/bootstrap.min.css\" >"
                    + "<script type=\"text/javascript\" src=\"js/bootstrap.min.js\"></script>"
                    + "<script type=\"text/javascript\" src=\"js/jquery-3.4.1.min.js\"></script>"
                    + "<style type=\"text/css\">"
                    + "table th{ text-align: center;} td{text-align: center;}"
                    + "</style>"
                    + "</head>" +
                    "<body>" +
                        "<table class=\"table table-dark\">" +
                        "<tr>" +
                            "<th scope=\"col\"> Numero </th>" +
                            "<th scope=\"col\"> Lexema </th>" +
                            "<th scope=\"col\"> Tipo </th>" +
                          "</tr>";
                foreach (MatrixToken token in tokens)
                {
                                        init += "<tr>"
                            + "<td >" + token.getNumber() + "</td>"
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
                    "<head>"
                    + "<link rel=\"stylesheet\" type=\"text/css\" href=\"css/bootstrap.min.css\" >"
                    + "<script type=\"text/javascript\" src=\"js/bootstrap.min.js\"></script>"
                    + "<script type=\"text/javascript\" src=\"js/jquery-3.4.1.min.js\"></script>"
                    + "</head>" +
                    "<body>" +
                        "<table class=\"table table-dark\" style= \"text - align:center;\" >" +
                        "<tr>" +
                            "<th> Numero de error </th>" +
                            "<th> Fila </th>" +
                            "<th> Columna </th>" +
                            "<th> Error </th>" +
                            "<th> Descripcion </th>" +
                          "</tr>";
                foreach (Error error in errores)
                {

                    init += "<tr>"
                            + "<td>" + error.getNoError() + "</td>"
                            + "<td>" + error.getFila() + "</td>"
                            + "<td>" + error.getColumna() + "</td>"
                            + "<td>" + error.getCaracter() + "</td>"
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
