using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class MatrixToken
    {
        private int number;
        private TokenModel token;

        public MatrixToken(int number, TokenModel token)
        {
            this.number = number;
            this.token = token;
        }

        public int getNumber()
        {
            return number;
        }
        public TokenModel getToken()
        {

            return token;
        }
        public void setNumber(int number)
        {
            this.number = number;
        }

        public void setToken(TokenModel token)
        {
            this.token = token;
        }
    }
}
