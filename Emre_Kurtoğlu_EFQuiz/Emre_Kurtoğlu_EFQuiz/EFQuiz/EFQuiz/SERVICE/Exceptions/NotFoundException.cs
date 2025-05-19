using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.SERVICE.Exceptions
{
    /// <summary>
    /// İstenilen veri bulunamadığında fırlatılan özel hata sınıfı.
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Aranan kayıt bulunamadı.") { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
