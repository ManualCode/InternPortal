using InternPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Application.Abstractions.Services
{
    public interface IProjectSevice
    {
        Task<Project> FindOrCreate(Project project);
    }
}
