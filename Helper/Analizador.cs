using AnalizadorLexico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Helper
{
    class Analizador
    {

        List<MatrixToken> matrix;
        public static List<Error> errores;
        int state;
        String auxLex;
        public static Boolean sintaxisError;
        CustomFileGenerator file = new CustomFileGenerator();

        private void addToken(TokenModel.TYPE tipo)
        {
            TokenModel token = new TokenModel(auxLex,tipo);
            matrix.Add(new MatrixToken(matrix.Count, token));
            auxLex = "";

        }

        private void addError(String descripcion, char lexema)
        {
            errores.Add(new Error(errores.Count, descripcion, lexema));
            auxLex = "";
            sintaxisError = true;
        }

        public List<MatrixToken> analizar(String entrance)
        {
            matrix = new List<MatrixToken>();
            errores = new List<Error>();
            state = 0;
            auxLex = "";
            Char c;
            for (int i = 0; i < entrance.Length; i++)
            {
                c = entrance.ElementAt(i);
                switch (state)
                {

                    case 0:
                        if (Char.IsLetter(c))
                        {
                            auxLex += c;
                        }
                        else if (c.Equals(':'))
                        {
                            state = 1;
                            addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                            auxLex += c;
                            addToken(TokenModel.TYPE.DOS_PUNTOS);
                        }else if (Char.IsDigit(c))
                        {
                            state = 1;
                            auxLex += c;
                        }


                        else if (c.Equals('>'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.MAYOR_QUE);
                            
                        }else if (c.Equals(')'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.PARENTESIS_DER);
                           
                        }
                        else if (c.Equals(']'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.CORCHETE_DER);
                        }else if (c.Equals('}'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.LLAVE_DER);
                        }
                        else
                        {
                            if (!Char.IsWhiteSpace(c))
                            {
                                addError("CARACTER DESCONOCIDO", c);
                            }
                            
                        }
                        
                    break;
                    case 1:
                        if (c.Equals('"'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.COMILLAS);
                            state = 2;
                        }
                        else if (Char.IsDigit(c))
                        {
                            auxLex += c;
                            
                        }else if (c.Equals('{') || c.Equals('(') || c.Equals('<'))
                            {
                                state = 0;
                                addToken(TokenModel.TYPE.IDENTIFICADOR);
                                auxLex += c;
                                switch (c)
                                {
                                    case '{':
                                        addToken(TokenModel.TYPE.LLAVE_IZQ);
                                        break;
                                    case '(':
                                        addToken(TokenModel.TYPE.PARENTESIS_IZQ);
                                        break;
                                    case '<':
                                        addToken(TokenModel.TYPE.MENOR_QUE);
                                        break;
                                }

                            }
                        else
                        {
                            if (!Char.IsWhiteSpace(c))
                            {
                                addError("CARACTER DESCONOCIDO", c);
                            }
                        }

                        break;
                    case 2:
                        
                        if (c.Equals('"'))
                        {
                            addToken(TokenModel.TYPE.CADENA);
                            auxLex += c;
                            addToken(TokenModel.TYPE.COMILLAS);
                        }
                        else if (c.Equals('['))
                        {
                            state = 0;
                            auxLex += c;
                            addToken(TokenModel.TYPE.CORCHETE_IZQ);
                        }
                        else if (c.Equals(';'))
                        {
                            state = 0;
                            auxLex += c;
                            addToken(TokenModel.TYPE.PUNTO_Y_COMA);

                        }
                        else
                        {
                            auxLex += c;
                        }
                        
                        break;
                    case 3:
                        if (c.Equals('}'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.LLAVE_DER);
                        }
                        else if (c.Equals(')'))
                        {
                            auxLex += c;
                            addToken(TokenModel.TYPE.PARENTESIS_DER);
                        }
                        else if (c.Equals(']'))
                        {
                            state = 0;
                            auxLex += c;
                            addToken(TokenModel.TYPE.CORCHETE_DER);
                        }else if (c.Equals('#'))
                        {
                            state = 0;
                        }
                        else
                        {
                            if (!Char.IsWhiteSpace(c) || !c.Equals('#'))
                            {
                                addError("CARACTER DESCONOCIDO", c);
                            }
                        }
                        break;

                    default:

                        break;
                }


            }
            
            return matrix;
        }

        public void imprimirTokens()
        {
            foreach (MatrixToken mt in matrix)
            {
                Console.WriteLine(mt.getNumber() + " | " + mt.getToken().getValor() +
                   " | " + mt.getToken().getTipoToken());
            }
            

        }
    }
}
