using AnalizadorLexico.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AnalizadorLexico.Helper
{
    class GenerarPlanificador
    {
        Planificacion nuevaPlanificacion;
        List<Planificacion> planificaciones;
        Year year;
        Mouth mouth;
        Day day;
        List<Year> years;
        List<Mouth> mouths;
        List<Day> days;

        public List<Planificacion> generar(List<MatrixToken> tokens)
        {
            planificaciones = new List<Planificacion>();
            for (int x = 0; x < tokens.Count; x++)
            {
                if (tokens[x].getToken().getValor().Equals("Planificador"))
                {
                    if (tokens[x+1].getToken().getValor().Equals(":"))
                    {
                        nuevaPlanificacion = new Planificacion();
                        nuevaPlanificacion.IdPlanificacion = planificaciones.Count;
                        years = new List<Year>();
                        nuevaPlanificacion.Years = years;
                        year = null;
                        if (tokens[x + 2].getToken().getTipoToken().Equals("COMILLAS"))
                        {
                            if (tokens[x + 4].getToken().getTipoToken().Equals("COMILLAS"))
                            {
                                nuevaPlanificacion.Nombre = tokens[x + 3].getToken().getValor();

                            }
                        }
                        if (tokens[x + 5].getToken().getTipoToken().Equals("CORCHETE_IZQ"))
                        {
                            int y = x;
                            while (!(tokens[y].getToken().getTipoToken().Equals("CORCHETE_DER")) &&
                                    x<tokens.Count)
                            {
                                if (y==87)
                                {
                                    int i = 0;
                                }
                                if (tokens[y].getToken().getTipoToken().Equals("PALABRA_RESERVADA")
                                    && tokens[y].getToken().getValor().ToLower().Equals("año"))
                                {
                                    if (tokens[y +1].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                    {
                                        year = new Year();
                                        mouths = new List<Mouth>();
                                        mouth = null;
                                        year.Mouths = mouths;
                                        if (tokens[y + 2].getToken().getTipoToken().Equals("IDENTIFICADOR")) {
                                            try
                                            {
                                                year.YearVariable = Int32.Parse(tokens[y + 2].getToken().getValor());
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Ocurrió un error al intentar parsear un valor");
                                            }
                                            if (tokens[y + 3].getToken().getTipoToken().Equals("LLAVE_IZQ"))
                                            {
                                                int u = y;
                                                while (!(tokens[u].getToken().getTipoToken().Equals("LLAVE_DER")) && 
                                                    u<tokens.Count && !(tokens[u].getToken().getValor().Equals('}')))
                                                {
                                                    
                                                    if (tokens[u].getToken().getTipoToken().Equals("PALABRA_RESERVADA") && tokens[u].getToken().getValor().ToLower().Equals("mes"))
                                                    {
                                                        if (tokens[u + 1].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                                        {
                                                            mouth = new Mouth();
                                                            mouth.Year = year.YearVariable;
                                                            days = new List<Day>();
                                                            mouth.Days = days;
                                                            day = null;
                                                        }            
                                                            if (tokens[u + 2].getToken().getTipoToken().Equals("IDENTIFICADOR"))
                                                            {
                                                                try
                                                                {
                                                                    mouth.MouthVariable = int.Parse(tokens[u + 2].getToken().getValor());
                                                                }
                                                                catch (Exception e)
                                                                {
                                                                    Console.WriteLine("Ocurrió un error al intentar parsear un valor ");
                                                                }
                                                                if (tokens[u + 3].getToken().getTipoToken().Equals("PARENTESIS_IZQ"))
                                                                {
                                                                    int i = u;
                                                                    while (!(tokens[i].getToken().getTipoToken().Equals("PARENTESIS_DER")) && i < tokens.Count)
                                                                    {
                                                                        if (tokens[i].getToken().getTipoToken().Equals("PALABRA_RESERVADA") && tokens[i].getToken().getValor().ToLower().Equals("dia"))
                                                                        {
                                                                            if (tokens[i+1].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                                                            {
                                                                                day = new Day();
                                                                             
                                                                                if (tokens[i + 2].getToken().getTipoToken().Equals("IDENTIFICADOR"))
                                                                                {
                                                                                    try
                                                                                    {
                                                                                        day.DayVariable = int.Parse(tokens[i + 2].getToken().getValor());
                                                                                    }
                                                                                    catch (Exception e)
                                                                                    {
                                                                                        Console.WriteLine("Ocurrió un error al intentar parsear el valor");
                                                                                    }
                                                                                    if (tokens[i + 3].getToken().getTipoToken().Equals("MENOR_QUE"))
                                                                                    {
                                                                                        if (tokens[i + 4].getToken().getTipoToken().Equals("PALABRA_RESERVADA"))
                                                                                        {
                                                                                            if (tokens[i + 5].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                                                                            {
                                                                                                if (tokens[i + 6].getToken().getTipoToken().Equals("COMILLAS"))
                                                                                                {
                                                                                                    if (tokens[i + 8].getToken().getTipoToken().Equals("COMILLAS"))
                                                                                                    {
                                                                                                        day.Description = tokens[i + 7].getToken().getValor();
                                                                                                        if (tokens[i + 9].getToken().getTipoToken().Equals("PUNTO_Y_COMA"))
                                                                                                        {
                                                                                                            if (tokens[i + 10].getToken().getTipoToken().Equals("PALABRA_RESERVADA"))
                                                                                                            {
                                                                                                                if (tokens[i + 11].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                                                                                                {
                                                                                                                    if(tokens[i + 12].getToken().getTipoToken().Equals("COMILLAS")) {
                                                                                                                        if (tokens[i + 14].getToken().getTipoToken().Equals("COMILLAS"))
                                                                                                                        {
                                                                                                                            day.UrlImage = tokens[i + 13].getToken().getValor();
                                                                                                                            if (tokens[i + 15].getToken().getTipoToken().Equals("PUNTO_Y_COMA")) {
                                                                                                                                if (tokens[i + 16].getToken().getTipoToken().Equals("MAYOR_QUE"))
                                                                                                                                {
                                                                                                                                    day.Mouth = mouth;
                                                                                                                                    day.CurrentDate = generateDate(day.Mouth.Year,
                                                                                                                                        day.DayVariable, day.Mouth.MouthVariable);
                                                                                                                                    days.Add(day);
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    
                                                                                }
                                                                            }
                                                                        }

                                                                        i++;
                                                                    }
                                                                mouth.Days = days;
                                                                days.OrderBy(p => p.DayVariable);
                                                                }

                                                            }
                                                        }
                                                        u++;
                                                        if (mouth !=null && !(verifyMouth(mouth, mouths)))
                                                        {
                                                            mouths.Add(mouth);
                                                            mouths.OrderBy(p => p.MouthVariable);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    if (year != null && !(verifyYear(year, years)))
                                    {
                                        years.Add(year);
                                        years.OrderBy(p => p.YearVariable);
                                    }
                                    y++;

                                }

                            }
                        }
                    }
                if (nuevaPlanificacion!=null && !(verifyPlanification(nuevaPlanificacion, planificaciones)))
                {
                    planificaciones.Add(nuevaPlanificacion);
                }
                
            }
            return planificaciones;
        }


        public DateTime generateDate(int year, int mouth, int day)
        {
            DateTime date =DateTime .Now;
            CultureInfo provider = CultureInfo.InvariantCulture;
            String fecha = day+"/"+mouth+"/"+year;
            try
            {
                date = Convert.ToDateTime(fecha);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error al obtener la fecha");
            }

            return date;
        }

        public Boolean verifyMouth(Mouth mouth, List<Mouth> mouths)
        {
            Boolean exists = false;
            foreach (Mouth mo in mouths)
            {
                if (mo==mouth)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public Boolean verifyYear(Year year, List<Year> years)
        {
            Boolean exists = false;
            foreach (Year y in years)
            {
                if (y==year)
                {
                    return true;
                }
            }
            return exists;
        }

        public Boolean verifyPlanification(Planificacion plan, List<Planificacion> planificaciones)
        {
            Boolean exists = false;
            foreach (Planificacion p in planificaciones)
            {
                if (p==plan)
                {
                    exists = true;
                }
            }
            return exists;
        }


    }
}
