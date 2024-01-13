using ELibrary.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.EntityFrameworkCore
{
    internal static class ModelBuilderExtensions
    {
        public static ModelBuilder ConfigureBook(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Book>();
            entity.HasKey(item => item.Id);
            entity.Property(item => item.Title).HasMaxLength(100).IsRequired();
            entity.Property(item => item.Language).HasMaxLength(25);
            entity.Property(item => item.Description);
            entity.Property(item => item.Pages).IsRequired();
            entity.Property(item => item.PublishYear).IsRequired();

            entity.HasMany(item => item.CollectedBooks)
                .WithOne(item => item.Book)
                    .HasForeignKey(item => item.BookId)
                    .OnDelete(DeleteBehavior.SetNull);

            entity.HasMany(item => item.Comments)
                .WithOne(item => item.Book)
                    .HasForeignKey(item => item.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(item => item.Scores)
                .WithOne(item => item.Book)
                    .HasForeignKey(item => item.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

            return modelBuilder;
        }

        public static ModelBuilder ConfigureCollection(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Collection>();
            entity.HasKey(item => item.Id);
            entity.Property(item => item.UserId).IsRequired();
            entity.Property(item => item.UserName).IsRequired();
            entity.Property(item => item.Name).HasMaxLength(100).IsRequired();
            entity.Property(item => item.Description).IsRequired();
            entity.HasMany(item => item.CollectedBooks)
                .WithOne(item => item.Collection)
                .HasForeignKey(item => item.CollectionId)
                .OnDelete(DeleteBehavior.Cascade);

            return modelBuilder;
        }

        public static ModelBuilder ConfigureCollectedBook(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<CollectedBook>();
            entity.HasKey(item => item.Id);
            return modelBuilder;
        }

        public static ModelBuilder ConfigureComment(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Comment>();
            entity.HasKey(item => item.Id);
            entity.Property(item => item.UserId).IsRequired();
            entity.Property(item => item.UserName).IsRequired();
            entity.Property(item => item.Description).IsRequired();
            return modelBuilder;
        }

        public static ModelBuilder ConfigureScore(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Score>();
            entity.HasKey(item => item.Id);
            entity.Property(item => item.UserId).IsRequired();
            entity.Property(item => item.Value).IsRequired();
            return modelBuilder;
        }
    }
}
