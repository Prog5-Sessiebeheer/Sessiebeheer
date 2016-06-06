using EvenementenAPI.Models.BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvenementenAPI.Models.DAL
{
    public class SessieContext: DbContext
    {
        
            public DbSet<Sessie> Sessies { get; set; }
        

        public SessieContext():base("def")
        {
            Database.SetInitializer<SessieContext>(new SessieInitializer());

        }

    }
}