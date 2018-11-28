using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketLeagueStatsAPI.Models;

namespace RocketLeagueStatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class playersController : ControllerBase
    {
        // db
        private RocketLeagueStatsModel db;

        public playersController(RocketLeagueStatsModel db)
        {
            this.db = db;
        }

        // GET: api/players
        [HttpGet]
        public IEnumerable<player> Get()
        {
            return db.players;
        }

        // GET: api/players/4
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            player player = db.players.SingleOrDefault(a => a.playerid == id);

            if (player == null)
            {
                return NotFound();
            }
            return Ok(player);
        }

        // POST: api/players
        [HttpPost]
        public ActionResult Post([FromBody] player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.players.Add(player);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = player.playerid });
        }

        // PUT: api/players/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] player player)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Put", player);
        }

        // DELETE: api/players/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            player player = db.players.SingleOrDefault(a => a.playerid == id);

            if (player == null)
            {
                return NotFound();
            }

            db.players.Remove(player);
            db.SaveChanges();
            return Ok();
        }
    }
}