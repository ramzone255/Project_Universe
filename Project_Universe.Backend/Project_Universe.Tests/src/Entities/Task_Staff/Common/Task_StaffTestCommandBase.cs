using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Task_Staff.Common
{
    public abstract class Task_StaffTestCommandBase : IDisposable
    {
        protected readonly Project_UniverseDbContext Context;

        public Task_StaffTestCommandBase()
        {
            Context = Task_StaffContextFactory.Create();
        }

        public void Dispose()
        {
            Task_StaffContextFactory.Destroy(Context);
        }
    }
}
