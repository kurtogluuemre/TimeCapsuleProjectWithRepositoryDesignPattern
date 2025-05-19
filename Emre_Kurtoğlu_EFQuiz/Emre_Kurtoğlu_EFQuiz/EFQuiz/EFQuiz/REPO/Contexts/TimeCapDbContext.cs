using EFQuiz.CORE.Models;
using EFQuiz.REPO.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.Contexts
{
    public class TimeCapDbContext : DbContext
    {
        /// <summary>
        /// DATABASEDEKI TABLOLARIMA KARSILIK GELIRLER
        /// </summary>
        public DbSet<Capsule> Capsules { get; set; }
        public DbSet<CapsuleDetail> CapsuleDetails { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            optionsBuilder.UseSqlServer("Server=LAPTOP-7B92414D;Database=TimeCapsuleDB;Trusted_Connection=True;;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /// <summary>
            /// FluentApi kullanarak yaptığımız konfigürasyonları metot olarak çağırıyoruz kodda kalabalık yapmasını istemediğimiz için farklı
            /// birer class olarak tanımladık yoksa burda da modelBuilder kullanarak yapabilirdik.
            /// </summary>
            modelBuilder.ApplyConfiguration(new CapsuleConfiguration());
            modelBuilder.ApplyConfiguration(new CapsuleDetailConfiguration());
        }
    }
}
