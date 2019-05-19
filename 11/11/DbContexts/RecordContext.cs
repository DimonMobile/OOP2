using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContexts
{
    class RecordContext : DbContext
    {
        public RecordContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\MyFiles\BSTU\2st\2st\OOP\OOP2\11\11\Database1.mdf;Integrated Security=True")
        { }
        public DbSet<Record> Record { get; set; }
    }
}
