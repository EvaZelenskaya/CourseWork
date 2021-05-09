using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data;

namespace Coursework
{
    class AppContext : DbContext
    {
        public DbSet<User> Staff { get; set; }


        public AppContext() : base("DefaultConnection") { }
    }
}
