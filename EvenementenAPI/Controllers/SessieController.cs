using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EvenementenAPI.Models.BO;
using EvenementenAPI.Models.DAL;

namespace EvenementenAPI.Controllers
{
    public class SessieController : ApiController
    {
        private SessieContext db = new SessieContext();

        // GET: api/Sessie
        public IQueryable<Sessie> GetSessies()
        {
            return db.Sessies;
        }

        // GET: api/Sessie/5
        [ResponseType(typeof(Sessie))]
        public IHttpActionResult GetSessie(int id)
        {
            Sessie sessie = db.Sessies.Find(id);
            if (sessie == null)
            {
                return NotFound();
            }

            return Ok(sessie);
        }

        // PUT: api/Sessie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSessie(int id, Sessie sessie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sessie.ID)
            {
                return BadRequest();
            }

            db.Entry(sessie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sessie
        [ResponseType(typeof(Sessie))]
        public IHttpActionResult PostSessie(Sessie sessie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sessies.Add(sessie);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sessie.ID }, sessie);
        }

        // DELETE: api/Sessie/5
        [ResponseType(typeof(Sessie))]
        public IHttpActionResult DeleteSessie(int id)
        {
            Sessie sessie = db.Sessies.Find(id);
            if (sessie == null)
            {
                return NotFound();
            }

            db.Sessies.Remove(sessie);
            db.SaveChanges();

            return Ok(sessie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SessieExists(int id)
        {
            return db.Sessies.Count(e => e.ID == id) > 0;
        }
    }
}