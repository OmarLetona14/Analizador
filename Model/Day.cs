using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class Day
    {
        private int day;
        private Mouth mouth;
        private String description;
        private String urlImage;
        private DateTime currentDate;

        public Day(int day, string description, string urlImage, Mouth mouth, DateTime currentDate)
        {
            this.day = day;
            this.description = description;
            this.urlImage = urlImage;
            this.mouth = mouth;
            this.currentDate = currentDate;
        }

        public DateTime CurrentDate
        {
            get
            {
                return currentDate;
            }
            set
            {
                currentDate = value;
            }
        }

        public Day()
        {

        }

        public int DayVariable
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public String UrlImage
        {
            get
            {
                return urlImage;
            }
            set
            {
                urlImage = value;
            }
        }

        public Mouth Mouth
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




        
    }
}
