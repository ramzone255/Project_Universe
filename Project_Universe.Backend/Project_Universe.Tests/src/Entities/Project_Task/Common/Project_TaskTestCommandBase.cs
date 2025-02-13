using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project_Task.Common
{
    public abstract class Project_TaskTestCommandBase : IDisposable
    {
        protected readonly Project_UniverseDbContext Context;

        public Project_TaskTestCommandBase()
        {
            Context = Project_TaskContextFactory.Create();
        }

        public void Dispose()
        {
            Project_TaskContextFactory.Destroy(Context);
        }
    }
}
