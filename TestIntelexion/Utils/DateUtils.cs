using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntelexion.Utils
{
    public class DateUtils
    {

        public static string GetDayOfWeek(DateTime date)
        {
            string dayOfWeek = "";
            switch (date.DayOfWeek) {
                case DayOfWeek.Sunday:
                    dayOfWeek = "Domingo";
                    break;
                case DayOfWeek.Monday:
                    dayOfWeek = "Lunes";
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeek = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeek = "Miercoles";
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeek = "Jueves";
                    break;
                case DayOfWeek.Friday:
                    dayOfWeek = "Viernes";
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeek = "Sabado";
                    break;
            }
            return dayOfWeek;
        }
    }
}
