using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DevExtremeMvcApp1.Models
{
    public class MainModel : DbContext
    {
        public MainModel() : base("name=MainModel")
        { }
        public DbSet<UserAccount> UserAccount { get; set; }
        public DbSet<Arac> Arac { get; set; }
        public DbSet<YetkiliServis> YetkiliServis { get; set; }
        public DbSet<BakimTalep> BakimTalep { get; set; }
    }
}