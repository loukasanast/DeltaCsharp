using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltabank.Models
{
    public class DeltaContext : DbContext
    {
        public DeltaContext()
            :base("name=MainConnectionString")
        {

        }

        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Konto> Konten { get; set; }
        public DbSet<Umsatz> Umsaetze { get; set; }
    }
}
