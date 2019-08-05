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
            CORCHETE_DER,
            CORCHETE_IZQ,
            PALABRA_RESERVADA_APERTURA,
            PALABRA_RESERVADA_CIERRE,
            NUMERO,
            COMILLAS,
            IDENTIFICADOR
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

                case TYPE.NUMERO:
                    return "NUMERO";
                case TYPE.CORCHETE_DER:
                    return "CORCHETE DERECHO";
                case TYPE.CORCHETE_IZQ:
                    return "CORCHETE IZQUIERDO";
                case TYPE.IDENTIFICADOR:
                    return "IDENTIFICADOR";
                case TYPE.PALABRA_RESERVADA_APERTURA:
                    return "PALABRA RESERVADA DE APERTURA";
                case TYPE.PALABRA_RESERVADA_CIERRE:
                    return "PALABRA RESERVADA DE CIERRE";
                case TYPE.COMILLAS:
                    return "COMILLAS";
                default:
                    return "CARACTER DESCONOCIDO";
            }
        }
    }
}
