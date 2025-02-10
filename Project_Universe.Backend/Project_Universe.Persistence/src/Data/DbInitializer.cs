using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Universe.Persistence.src.Data
{
    public class DbInitializer
    {
        public static void Initialize(Project_UniverseDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
