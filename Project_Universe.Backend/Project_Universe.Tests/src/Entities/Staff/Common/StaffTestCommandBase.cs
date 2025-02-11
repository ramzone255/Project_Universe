using Project_Universe.Persistence.src.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Staff.Common
{
    public abstract class StaffTestCommandBase : IDisposable
    {
        protected readonly Project_UniverseDbContext Context;

        public StaffTestCommandBase()
        {
            Context = StaffContextFactory.Create();
        }

        public void Dispose()
        {
            StaffContextFactory.Destroy(Context);
        }
    }
}
