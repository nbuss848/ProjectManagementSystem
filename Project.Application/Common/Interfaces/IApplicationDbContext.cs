using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Common.Interfaces
{
    public interface IApplicationDbContext 
    {
        DbSet<Domain.Entities.Project> Projects { get; set; }
        DbSet<Status> Statuses { get; set; }
        DbSet<Domain.Entities.Task> Tasks { get; set; }
        DbSet<SubTask> SubTasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
