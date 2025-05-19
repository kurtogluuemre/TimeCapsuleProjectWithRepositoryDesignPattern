using EFQuiz.CORE.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFQuiz.REPO.Configs
{
    public class CapsuleConfiguration : IEntityTypeConfiguration<Capsule>
    {
        public void Configure(EntityTypeBuilder<Capsule> builder)
        {
            builder.HasKey(c => c.Id); // Primary key olarak Id özelliği tanımlanır 

            builder.Property(c => c.Title)  // Title alanı boş geöilemez ve max 100 karakterdir
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.OpenDate) // OpenDate alanı zorunludur
                   .IsRequired();

            builder.HasMany(c => c.Contents)// Capsule ile CapsuleDetail arasında bire-çok ilişki kurulur Bir kapsülün birden fazla içeriği olabilir
                   .WithOne(cc => cc.Capsule)
                   .HasForeignKey(cc => cc.CapsuleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
