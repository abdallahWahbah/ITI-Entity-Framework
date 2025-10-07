using _02_entities_to_DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_entities_to_DB.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(a => a.StdId);
            builder.Property(x => x.StdId).ValueGeneratedNever();
            builder.HasOne(a => a.Department)
                    .WithMany(a => a.Students)
                    .HasForeignKey(a => a.DeptNo)
                    .IsRequired();
        }
    }
}
