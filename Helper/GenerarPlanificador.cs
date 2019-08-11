using AnalizadorLexico.Model;
using System;
using System.Collections.Generic;
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
                        
                        if (tokens[x + 2].getToken().getTipoToken().Equals("COMILLAS"))
                        {
                            if (tokens[x + 4].getToken().getTipoToken().Equals("COMILLAS"))
                            {
                                nuevaPlanificacion.Nombre = tokens[x + 2].getToken().getValor();

                            }
                        }
                        if (tokens[x + 5].getToken().getTipoToken().Equals("CORCHETE_IZQ"))
                        {
                            while (!(tokens[x].getToken().getTipoToken().Equals("CORCHETE_DER")) ||
                                    x<tokens.Count)
                            {
                                x +=6;
                                if (tokens[x].getToken().getTipoToken().Equals("PALABRA_RESERVADA"))
                                {
                                    if (tokens[x +1].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                    {
                                        year = new Year();         
                                        
                                        if (tokens[x + 2].getToken().getTipoToken().Equals("IDENTIFICADOR")) {
                                            try
                                            {
                                                year.YearVariable = Int32.Parse(tokens[x + 2].getToken().getValor());
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine("Ocurrió un error al intentar parsear un valor");
                                            }
                                            if (tokens[x + 3].getToken().getTipoToken().Equals("LLAVE_IZQ"))
                                            {
                                                int u = x;
                                                while (!(tokens[u].getToken().getTipoToken().Equals("LLAVE_DER")) || 
                                                    u<tokens.Count)
                                                {
                                                    if (tokens[u].getToken().getTipoToken().Equals("PALABRA_RESERVADA"))
                                                    {
                                                        if (tokens[u + 1].getToken().getTipoToken().Equals("DOS_PUNTOS"))
                                                        {
                                                            mouth = new Mouth();
                                                            mouths = new List<Mouth>();
                                                            mouth.Year = year.YearVariable;

                                                            days = new List<Day>();
                                                            mouth.Days = days;
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
                                                                    while (!(tokens[i].getToken().getTipoToken().Equals("PARENTESIS_DER")))
                                                                    {
                                                                        if (tokens[i].getToken().getTipoToken().Equals("PALABRA_RESERVADA"))
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
                                                                }

                                                            }
                                                        }
                                                        mouths.Add(mouth);
                                                    }
                                                    year.Mouths = mouths;
                                                    u++;
                                                }

                                                mouths.OrderBy(p => p.MouthVariable);
                                                nuevaPlanificacion.Years.Last().Mouths = mouths;
                                            }
                                        }
                                    }
                                    //years.Add(year);
                                x++;
                            }
                                nuevaPlanificacion.Years = years;

                               
                            }
                            years.OrderBy(p => p.YearVariable);
                            nuevaPlanificacion.Years = years;
                            continue;
                        }
                    }
               
                
                planificaciones.Add(nuevaPlanificacion);
            }
            return planificaciones;
        }

    }
}
