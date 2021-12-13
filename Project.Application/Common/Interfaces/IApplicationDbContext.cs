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
        DbSet<Domain.MySql.Project> Projects { get; set; }
        DbSet<Domain.MySql.Statuscode> Statuscodes { get; set; }
        DbSet<Domain.MySql.Task> Tasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);      
    }
}
