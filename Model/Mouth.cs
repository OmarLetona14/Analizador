using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class Mouth
    {

        private int mouth;
        private int year;
        private List<Day> days;

        public Mouth(int mouth, int year, List<Day> days)
        {
            this.mouth = mouth;
            this.year = year;
            this.days = days;
        }

        public Mouth()
        {

        }
        public int MouthVariable
        {
            get
            {
                return mouth;
            }
            set
            {
                mouth = value;
            }
        }

        public List<Day> Days
        {
            get
            {
                return days;
            }
            set
            {
                days = value;
            }
        }

        public int Year
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
    }
}
