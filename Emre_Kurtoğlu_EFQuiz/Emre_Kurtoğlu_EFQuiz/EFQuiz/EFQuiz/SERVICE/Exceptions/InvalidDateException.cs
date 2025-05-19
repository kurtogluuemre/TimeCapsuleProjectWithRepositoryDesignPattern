using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Exceptions
{
    /// <summary>
    /// Geçersiz bir tarih girildiğinde fırlatılan özel hata sınıfı.
    /// </summary>
    public class InvalidDateException : Exception
    {
        public InvalidDateException() : base("Geçersiz bir tarih girildi.Lütfen geçerli bir tarih giriniz.") { }

        public InvalidDateException(string message) : base(message) { }

        public InvalidDateException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
