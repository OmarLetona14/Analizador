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
        private String nombre;
        private DateTime date;
        private List<Year> years;
        

        public Planificacion()
        {}

        public Planificacion(int idPlanificacion, string nombre, DateTime date, List<Year> years)
        {
            this.idPlanificacion = idPlanificacion;
            this.nombre = nombre;
            this.date = date;
            this.years = years;
        }

        public int IdPlanificacion
        {
            get { return idPlanificacion; }
            set{ idPlanificacion = value; }
        }

        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
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
        

        public List<Year> Years
        {
            get
            {
                return years;
            }
            set
            {
                years = value;
            }
        }

    }
}
