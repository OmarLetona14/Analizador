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
        private List<Year> years;
        

        public Planificacion()
        {}

        public Planificacion(int idPlanificacion, string nombre, DateTime date)
        {
            this.idPlanificacion = idPlanificacion;
            this.nombre = nombre;
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
