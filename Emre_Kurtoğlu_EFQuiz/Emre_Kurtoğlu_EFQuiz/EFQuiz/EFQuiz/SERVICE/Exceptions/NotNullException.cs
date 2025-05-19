using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Exceptions
{
    /// <summary>
    /// Doğrulama hataları oluştuğunda fırlatılan özel hata sınıfı.
    /// </summary>
    public class NotNullException : Exception
    {
        public NotNullException() : base("Boş Geçilmemelidir.") { }

        public NotNullException(string message) : base(message) { }

        public NotNullException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
