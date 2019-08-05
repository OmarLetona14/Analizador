using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico.Model
{
    class Planificacion
    {
        private int idPlanificacion;
        private DateTime date;
        private int day;
        private int year;
        private int mouth;
        private String description;
        private String urlImage;

        public Planificacion(int idPlanificacion, DateTime date, int day, int year, int mouth, string description, string urlImage)
        {
            this.idPlanificacion = idPlanificacion;
            this.date = date;
            this.day = day;
            this.year = year;
            this.mouth = mouth;
            this.description = description;
            this.urlImage = urlImage;
        }

        public int IdPlanificacion
        {
            get { return idPlanificacion; }
            set{ idPlanificacion = value; }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        } 
        public int Day
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

        public int Mouth
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

       
    }
}
