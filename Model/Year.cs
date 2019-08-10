using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class Year
    {
        private int year;
        private List<Mouth> mouths;

        public Year(int year, List<Mouth> mouths)
        {
            this.year = year;
            this.mouths = mouths;

        }

        public Year()
        {

        }

        public int YearVariable
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public List<Mouth> Mouths
        {
            get
            {
                return mouths;
            }
            set
            {
                mouths = value;
            }
        }
    }
}
