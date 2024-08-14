using CheckBox.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckBox.Data.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Born).IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Notes).HasForeignKey(x => x.UserId);
            
        }
    }
}
