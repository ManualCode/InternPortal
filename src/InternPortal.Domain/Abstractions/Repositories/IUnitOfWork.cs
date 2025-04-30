using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternPortal.Domain.Abstractions.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IInternRepository InternRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IInternshipRepository InternshipRepository { get; }

        void Save();
    }
}
