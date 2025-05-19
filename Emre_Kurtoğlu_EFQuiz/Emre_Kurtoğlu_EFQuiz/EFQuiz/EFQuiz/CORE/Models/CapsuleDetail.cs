using EFQuiz.CORE.Abstracts;
using EFQuiz.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.CORE.Models
{
    public class CapsuleDetail : BaseEntity
    {
        public string Text { get; set; }
        public ContentType ContentType { get; set; }

        public int CapsuleId { get; set; } // Foreign Key
        public virtual Capsule Capsule { get; set; } // Navigation Property 'virtual' keyword'ü sayesinde lazy loading desteği sağlanır.
    }
}
