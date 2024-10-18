using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMS.CORE.Concrete.EFCore.Context.DbExtensions
{
    public static class DbContextOptionsBuilderExtension
    {
        public static void UseSqlServerConnection(this DbContextOptionsBuilder optionsBuilder,string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
