using EvenementenAPI.Models.BO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvenementenAPI.Models.DAL
{
    public class SessieInitializer : DropCreateDatabaseIfModelChanges<SessieContext>
    {
        public SessieInitializer()
        {

        }

        protected override void Seed(SessieContext db)
        {
            db.Sessies.Add(new Sessie() { Naam = "Sessie1" });
            db.Sessies.Add(new Sessie() { Naam = "Sessie2" });
            db.Sessies.Add(new Sessie() { Naam = "Sessie3" });

            db.SaveChanges();
        }   
    }
}