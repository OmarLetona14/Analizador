using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class TokenModel
    {
        public enum TYPE
        {
            DOS_PUNTOS,
            LLAVE_DER,
            LLAVE_IZQ,
            PARENTESIS_DER,
            PARENTESIS_IZQ,
            MAYOR_QUE,
            MENOR_QUE,
            COMA,
            PUNTO_Y_COMA,
            CORCHETE_DER,
            CORCHETE_IZQ,
            PALABRA_RESERVADA,
            NUMERO,
            COMILLAS,
            IDENTIFICADOR,
            CADENA
        }

        private String valor;
        private TYPE tipo;

        public TokenModel(String valor, TYPE tipo)
        {
            this.valor = valor;
            this.tipo = tipo;
        }

        public String getValor()
        {
            return valor;
        }

        public String getTipoToken()
        {
            switch (tipo)
            {
                case TYPE.DOS_PUNTOS:
                    return "DOS_PUNTOS";
                case TYPE.COMA:
                    return "COMA";
                case TYPE.LLAVE_DER:
                    return "LLAVE_DER";
                case TYPE.LLAVE_IZQ:
                    return "LLAVE_IZQ";
                case TYPE.MAYOR_QUE:
                    return "MAYOR_QUE";
                case TYPE.MENOR_QUE:
                    return "MENOR_QUE";
                case TYPE.PALABRA_RESERVADA:
                    return "PALABRA_RESERVADA";
                case TYPE.PUNTO_Y_COMA:
                    return "PUNTO_Y_COMA";
                case TYPE.PARENTESIS_DER:
                    return "PARENTESIS_DER";
                case TYPE.PARENTESIS_IZQ:
                    return "PARENTESIS_IZQ";
                case TYPE.NUMERO:
                    return "NUMERO";
                case TYPE.CORCHETE_DER:
                    return "CORCHETE_DER";
                case TYPE.CORCHETE_IZQ:
                    return "CORCHETE_IZQ";
                case TYPE.IDENTIFICADOR:
                    return "IDENTIFICADOR";
                case TYPE.COMILLAS:
                    return "COMILLAS";
                case TYPE.CADENA:
                    return "CADENA";
                default:
                    return "CARACTER DESCONOCIDO";
            }
        }
    }
}
