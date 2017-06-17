using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Login.Models
{
  public class DbContexto : DbContext
  {
    public DbSet<Usuario> db_usuario { get; set; }
  }
}