using Microsoft.EntityFrameworkCore;
using Project.Application.Common.Interfaces;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Domain.Entities.Project> Projects { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Project>().ToTable("Project");
            modelBuilder.Entity<Domain.Entities.Status>().ToTable("Status");
            modelBuilder.Entity<Domain.Entities.Task>().ToTable("Task");
            modelBuilder.Entity<Domain.Entities.SubTask>().ToTable("SubTask");
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            //foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            //{
            //    switch (entry.State)
            //    {
            //        case EntityState.Added:
            //            entry.Entity.CreatedBy = _currentUserService.UserId;
            //            entry.Entity.Created = _dateTime.Now;
            //            break;

            //        case EntityState.Modified:
            //            entry.Entity.LastModifiedBy = _currentUserService.UserId;
            //            entry.Entity.LastModified = _dateTime.Now;
            //            break;
            //    }
            //}

            int result = await base.SaveChangesAsync(cancellationToken);

            //await DispatchEvents(cancellationToken);

            return result;
        }
    }
}
