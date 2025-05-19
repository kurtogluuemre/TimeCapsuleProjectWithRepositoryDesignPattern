using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFQuiz.CORE.Models;

namespace EFQuiz.REPO.Configs
{
    public class CapsuleDetailConfiguration : IEntityTypeConfiguration<CapsuleDetail>
    {
        public void Configure(EntityTypeBuilder<CapsuleDetail> builder)
        {
            builder.HasKey(cc => cc.Id); // Primary key olarak Id alanı tanımlanır

            builder.Property(cc => cc.Text) // Text alanı zorunludur
                   .IsRequired();

            builder.Property(cc => cc.ContentType) // Bu alanda zorunludur
                   .IsRequired();

            builder.HasOne(cc => cc.Capsule) // CapsuleDetail ile Capsule arasında çoktan-bire ilişki kurulur
                   .WithMany(c => c.Contents)
                   .HasForeignKey(cc => cc.CapsuleId);
        }
    }
}
