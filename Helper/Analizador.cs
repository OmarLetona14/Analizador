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
        int state;
        String auxLex;
        CustomFileGenerator file = new CustomFileGenerator();

        private void addToken(TokenModel.TYPE tipo)
        {
            TokenModel token = new TokenModel(auxLex,tipo);
            matrix.Add(new MatrixToken(matrix.Count, token));
            auxLex = "";

        }

        public List<MatrixToken> analizar(String entrance)
        {
            entrance += "#";
            matrix = new List<MatrixToken>();
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
                        break;

                    default:

                        break;
                }


            }
            file.generateHTMLTokensFile(matrix, "D:\\Users\\Omar\\Desktop\\tokens.html");
            imprimirTokens();
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
