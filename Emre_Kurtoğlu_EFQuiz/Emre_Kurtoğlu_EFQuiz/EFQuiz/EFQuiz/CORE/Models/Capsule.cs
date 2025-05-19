using EFQuiz.CORE.Abstracts;
using EFQuiz.CORE.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.CORE.Models
{
    public class Capsule : BaseEntity
    {
        private string title;
        public string Title 
        {
            get
            {
                return title;
            }
            set
            {
                title = Guard.SetData(value); // Oluşturduğumuz helpers klasöründen Guard sınıfını SetData metodyla değerin boş olup olmadığını kontrol ediyoruz
            } 
        }
        public DateTime OpenDate { get; set; }  

        public virtual List<CapsuleDetail> Contents { get; set; } = new(); // Navigation Property 'virtual' keyword'ü sayesinde lazy loading desteği sağlanır.
    }
}
