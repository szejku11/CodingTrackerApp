using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodingTracker
{
    internal static class Validation
    {
        internal static string CodingSessionDuration(string startTime, string endTime)
        {
            DateTime dateTimeStart = DateTime.ParseExact(startTime, "dd-MM-yyyy HH:mm:ss",
                   CultureInfo.InvariantCulture, DateTimeStyles.None);
            
            DateTime dateTimeEnd = DateTime.ParseExact(endTime, "dd-MM-yyyy HH:mm:ss",
                   CultureInfo.InvariantCulture, DateTimeStyles.None);

            TimeSpan dif = dateTimeEnd - dateTimeStart;

            return dif.ToString();
        }
    }
}
