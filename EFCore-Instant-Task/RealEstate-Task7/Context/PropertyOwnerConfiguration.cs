using EFCore_Instant_Task.RealEstate_Task7.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore_Instant_Task.RealEstate_Task7.Context
{
    internal class PropertyOwnerConfiguration : IEntityTypeConfiguration<PropertyOwner>
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            builder.HasKey(po => new { po.PropertyId, po.OwnerId });
            builder.Property(po => po.Percent)
                   .HasColumnType("decimal(5,2)")
                   .IsRequired();
            builder.HasOne(po => po.Property)
                   .WithMany(p => p.PropertyOwners)
                   .HasForeignKey(po => po.PropertyId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(po => po.Owner)
                     .WithMany(o => o.PropertyOwners)
                     .HasForeignKey(po => po.OwnerId)
                     .OnDelete(DeleteBehavior.Restrict);

        }
    }
}