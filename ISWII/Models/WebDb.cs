using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ISWII.Models
{
    public class WebDb : DbContext
    {
        public WebDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Recomend> Recomendations { get; set; }
    }
}