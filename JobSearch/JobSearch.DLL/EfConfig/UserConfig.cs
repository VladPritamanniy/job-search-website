﻿using JobSearch.DLL.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.DLL.EfConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Email).IsUnicode(false);
            builder.Property(p => p.RefreshToken).IsUnicode(false);
            builder.Property(p => p.PasswordHash).IsUnicode(false);
        }
    }
}
