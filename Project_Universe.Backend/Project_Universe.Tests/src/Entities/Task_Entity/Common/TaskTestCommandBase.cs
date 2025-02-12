using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Entity.Common
{
    public abstract class TaskTestCommandBase : IDisposable
    {
        protected readonly Project_UniverseDbContext Context;

        public TaskTestCommandBase()
        {
            Context = TaskContextFactory.Create();
        }

        public void Dispose()
        {
            TaskContextFactory.Destroy(Context);
        }
    }
}
