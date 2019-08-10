using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class Error
    {
        private int noError;
        private char lexema;
        private String descripcion;

        public Error(int noError, String descripcion, char lexema)
        {
            this.noError = noError;
            this.lexema = lexema;
            this.descripcion = descripcion;
        }

        public int getNoError()
        {
            return noError;
        }

        public char getLexema()
        {
            return lexema;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setNoError(int noError)
        {
            this.noError = noError;
        }

        public void setLexema(char lexema)
        {
            this.lexema = lexema;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
