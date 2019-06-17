using System;
using Curiox.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Curiox.Data.Context
{
    public partial class CurioxContext : DbContext
    {
        public CurioxContext()
        {
        }

        public CurioxContext(DbContextOptions<CurioxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answer { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<QuestionUpvote> QuestionUpvote { get; set; }
        public virtual DbSet<AnswerUpvote> AnswerUpvote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=ec2-54-221-236-144.compute-1.amazonaws.com;Port=5432;User ID=gkrbtyrwzcxhmw;Password=5c0c9bae65d3e5f3a95fb389905dc35470e5899f0ebbddbe91dbfaa6fa5d649e;Database=df3l0in748n8;Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasIndex(e => e.QuestionId)
                    .HasName("fki_Answer_question_id_fkey");

                entity.HasIndex(e => e.UserId)
                    .HasName("fki_Answer_user_id_fkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content")
                    .HasMaxLength(10000);

                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("timestamp");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Answer_question_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Answer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Answer_user_id_fkey");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .HasName("fki_Question_category_id_fkey");

                entity.HasIndex(e => e.UserId)
                    .HasName("fki_Question_user_id_fkey");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("date_created")
                    .HasColumnType("timestamp");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("date_updated")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(1000);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("Question_category_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Question_user_id_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(5000);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30);

                entity.Property(e => e.Fullname)
                    .HasColumnName("fullname")
                    .HasMaxLength(40);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(30);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<QuestionUpvote>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();
                
                entity.Property(e => e.QuestionId).HasColumnName("question_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<AnswerUpvote>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseNpgsqlIdentityAlwaysColumn();

                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });
        }
    }
}
