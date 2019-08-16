using AnalizadorLexico.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico.Helper
{
    class Analizador
    {

        List<MatrixToken> matrix;
        public static List<Error> errores;
        int state;
        String auxLex;
        public static Boolean lexicError, sintError;
        CustomFileGenerator file = new CustomFileGenerator();
        List<Char> signos = new List<Char> {'[',']','{','}','(',')',';','"',':'};

        private void addToken(TokenModel.TYPE tipo)
        {
            TokenModel token = new TokenModel(auxLex,tipo);
            matrix.Add(new MatrixToken(matrix.Count+1, token));
            auxLex = "";

        }

        private Boolean errorLexico(Char e)
        {
            Boolean error = false;

            foreach (Char c in signos)
            {
                if (c==e)
                {
                    error = true;
                }
            }
            return error;
        }

        private void addError(String lexema, int columna, int fila, String descripcion)
        {
            errores.Add(new Error(errores.Count+1, lexema, columna, fila, descripcion));
            auxLex = "";
            lexicError = true;
        }

        public List<MatrixToken> analizar(String entrance)
        {
            int columna = 0, fila = 1;
            matrix = new List<MatrixToken>();
            errores = new List<Error>();
            state = 0;
            auxLex = "";
            Char c;
            for (int i = 0; i < entrance.Length; i++)
            {
                c = entrance.ElementAt(i);
                if (c != '\n')
                {
          
                    columna+=1;
                }
                else
                {
                    columna = 0;
                    fila += 1;
                }
                switch (state)
                {

                    case 0:
                        if (Char.IsLetter(c))
                        { 
                            auxLex += c;
                        }
                        else if (c.Equals(':'))
                        {
                            switch (auxLex.ToLower())
                            {
                                case "planificador":
                                    state = 1;
                                    addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                                    auxLex += c;
                                    addToken(TokenModel.TYPE.DOS_PUNTOS);
                                    break;
                                case "año":
                                    state = 1;
                                    addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                                    auxLex += c;
                                    addToken(TokenModel.TYPE.DOS_PUNTOS);
                                    break;
                                case "dia":
                                    state = 1;
                                    addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                                    auxLex += c;
                                    addToken(TokenModel.TYPE.DOS_PUNTOS);
                                    break;
                                case "mes":
                                    state = 1;
                                    addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                                    auxLex += c;
                                    addToken(TokenModel.TYPE.DOS_PUNTOS);
                                    break;
                                case "descripcion":
                                    state = 1;
                                    addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                                    auxLex += c;
                                    addToken(TokenModel.TYPE.DOS_PUNTOS);
                                    break;
                                case "imagen":
                                    state = 1;
                                    addToken(TokenModel.TYPE.PALABRA_RESERVADA);
                                    auxLex += c;
                                    addToken(TokenModel.TYPE.DOS_PUNTOS);
                                    break;
                                default:
                                    state = 1;
                                    addError(auxLex,columna, fila, "PALABRA O CARACTER DESCONOCIDO");
                                    break;
                            }


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
                                if (!errorLexico(c))
                                {
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }
                                
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
                                state = 0;
                                if (!errorLexico(c))
                                {
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }
                            }
                        }

                        break;
                    case 2:
                        
                        if (c.Equals('"'))
                        {
                            addToken(TokenModel.TYPE.CADENA);
                            auxLex += c;
                            addToken(TokenModel.TYPE.COMILLAS);
                            state = 3;
                        }
                        
                        else
                        {
                            auxLex += c;
                        }
                        
                        break;
                    case 3:
                        if (c.Equals('['))
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
                            if (!Char.IsWhiteSpace(c))
                            {
                                state = 0;
                                if (!errorLexico(c))
                                {
                                    addError(Char.ToString(c), columna, fila, "CARACTER DESCONOCIDO");
                                }
                                else
                                {
                                    sintError = true;
                                }
                            }  
                        }
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
