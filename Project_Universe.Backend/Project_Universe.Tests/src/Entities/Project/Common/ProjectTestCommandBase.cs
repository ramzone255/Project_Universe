using Project_Universe.Persistence.src.Data;
using Project_Universe.Tests.src.Entities.Staff.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Tests.src.Entities.Project.Common
{
    public class ProjectTestCommandBase : IDisposable
    {
        protected readonly Project_UniverseDbContext Context;

        public ProjectTestCommandBase()
        {
            Context = ProjectContextFactory.Create();
        }

        public void Dispose()
        {
            ProjectContextFactory.Destroy(Context);
        }
    }
}
