using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace scaffoldingdbcontext.Models
{
    public partial class LankaCleardbContext : DbContext
    {
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyDocumentType> CompanyDocumentType { get; set; }
        public virtual DbSet<CompanyUser> CompanyUser { get; set; }
        public virtual DbSet<CompanyUserDocumentType> CompanyUserDocumentType { get; set; }
        public virtual DbSet<CompanyUserTokenMapping> CompanyUserTokenMapping { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<Token> Token { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LankaCleardb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.ProgressStatus).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<CompanyDocumentType>(entity =>
            {
                entity.Property(e => e.CompanyId).ValueGeneratedNever();

                entity.HasOne(d => d.Company)
                    .WithOne(p => p.CompanyDocumentType)
                    .HasForeignKey<CompanyDocumentType>(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyDocument_Company");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.CompanyDocumentType)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyDocument_Company1");
            });

            modelBuilder.Entity<CompanyUser>(entity =>
            {
                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyUser)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyUser_CompanyUser");

                entity.HasOne(d => d.LoginUser)
                    .WithMany(p => p.CompanyUser)
                    .HasForeignKey(d => d.LoginUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyUser_User");
            });

            modelBuilder.Entity<CompanyUserDocumentType>(entity =>
            {
                entity.Property(e => e.CompanyUserId).ValueGeneratedNever();

                entity.HasOne(d => d.CompanyUser)
                    .WithOne(p => p.CompanyUserDocumentType)
                    .HasForeignKey<CompanyUserDocumentType>(d => d.CompanyUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyUserDocument_CompanyUser");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.CompanyUserDocumentType)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyUserDocument_DocumentType");
            });

            modelBuilder.Entity<CompanyUserTokenMapping>(entity =>
            {
                entity.HasOne(d => d.CompanyUser)
                    .WithMany(p => p.CompanyUserTokenMapping)
                    .HasForeignKey(d => d.CompanyUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTokenMapping_CompanyUser");

                entity.HasOne(d => d.Token)
                    .WithMany(p => p.CompanyUserTokenMapping)
                    .HasForeignKey(d => d.TokenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTokenMapping_Token");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}


public partial class BaseClass
{
    public long Id { get; set; }
}
