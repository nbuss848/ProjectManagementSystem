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
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
