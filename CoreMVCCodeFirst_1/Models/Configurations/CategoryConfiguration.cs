﻿using CoreMVCCodeFirst_1.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMVCCodeFirst_1.Models.Configurations
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            //builder.ToTable("Kategoriler");
            //builder.Property(x=>x.CategoryName).HasColumnName("Kategori Adı").IsRequired().HasMaxLength(50);
        }
    }
}
