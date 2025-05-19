using EFQuiz.SERVICE.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.CORE.Helpers
{
    public static class Guard
    {
        /// <summary>
        /// Verilen string değeri kontrol eder ve boş veya null içeren bir ifade ise hata fırlatır.
        /// </summary>
        public static string SetData(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new NotNullException($"{nameof(value)} bu alan boş geçilmemelidir.");
            return value;
        }

        /// <summary>
        /// Etkinlik tarihini kontrol eder ve geçmiş bir tarihse hata fırlatır.
        /// </summary>
        public static DateTime SetDate(DateTime eventDate)
        {
            if (eventDate < DateTime.Now)
                throw new InvalidDateException("Etkinlik tarihi geçmiş bir tarih olmamalıdır.");
            return eventDate;
        }
    }
}
