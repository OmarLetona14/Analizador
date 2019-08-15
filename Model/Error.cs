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
        private String caracter;
        private int columna;
        private int fila;
        private String descripcion;

        public Error(int noError, String caracter, int columna, int fila, string descripcion)
        {
            this.noError = noError;
            this.caracter = caracter;
            this.columna = columna;
            this.fila = fila;
            this.descripcion = descripcion;
        }

        public int getNoError()
        {
            return noError;
        }

        public int getColumna()
        {
            return columna;
        }

        public int getFila()
        {
            return fila;
        }
        public String getCaracter()
        {
            return caracter;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setNoError(int noError)
        {
            this.noError = noError;
        }

        public void setColumna(int columna)
        {
            this.columna = columna;
        }

        public void setFila(int fila)
        {
            this.fila = fila;
        }

        public void setCaracter(String caracter)
        {
            this.caracter = caracter;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
