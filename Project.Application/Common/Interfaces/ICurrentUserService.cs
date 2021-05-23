using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; set; }
    }
}
