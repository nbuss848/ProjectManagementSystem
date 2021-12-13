using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Project.Application.Common.Interfaces;

#nullable disable

namespace Project.Infrastructure.Models
{
    public partial class PMSContext : DbContext, IApplicationDbContext
    {
        public virtual DbSet<Project.Domain.MySql.Project> Projects { get; set; }
        public virtual DbSet<Project.Domain.MySql.Statuscode> Statuscodes { get; set; }
        public virtual DbSet<Project.Domain.MySql.Task> Tasks { get; set; }

        public PMSContext()
        {
        }

        public PMSContext(DbContextOptions<PMSContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, 
 //               you should move it out of source code. You can avoid scaffolding the connection string by using the 
  //                  Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.                                                                           
                //For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                
                

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project.Domain.MySql.Project>(entity =>
            {
                entity.ToTable("project");

                entity.HasIndex(e => e.StatusId, "StatusId_Constraint_2");

                entity.Property(e => e.ProjectId).HasColumnType("mediumint(9)");

                entity.Property(e => e.Desciption)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.ProjectImage)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.Size)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StatusId)
                    .HasColumnType("mediumint(9)")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("StatusId_Constraint_2");
            });

            modelBuilder.Entity<Project.Domain.MySql.Statuscode>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PRIMARY");

                entity.ToTable("statuscode");

                entity.Property(e => e.StatusId).HasColumnType("mediumint(9)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Project.Domain.MySql.Task>(entity =>
            {
                entity.ToTable("task");

                entity.HasIndex(e => e.ProjectId, "ProjectId_Constraint");

                entity.HasIndex(e => e.ParentTaskId, "ProjectId_Constraint_2");

                entity.HasIndex(e => e.StatusId, "StatusId_Constraint");

                entity.Property(e => e.TaskId).HasColumnType("mediumint(9)");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'NULL'")
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.ParentTaskId)
                    .HasColumnType("mediumint(9)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.ProjectId).HasColumnType("mediumint(9)");

                entity.Property(e => e.Size)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.StatusId).HasColumnType("mediumint(9)");

                entity.HasOne(d => d.ParentTask)
                    .WithMany(p => p.InverseParentTask)
                    .HasForeignKey(d => d.ParentTaskId)
                    .HasConstraintName("ProjectId_Constraint_2");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProjectId_Constraint");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("StatusId_Constraint");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
