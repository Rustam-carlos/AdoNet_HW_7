using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_HW_7
{
    class VisitorContext : DbContext
    {
        public VisitorContext(): base("DbConnection") { }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
