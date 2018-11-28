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
    public class teamsController : ControllerBase
    {
        private readonly RocketLeagueStatsModel _context;

        public teamsController(RocketLeagueStatsModel context)
        {
            _context = context;
        }

        // GET: api/teams
        [HttpGet]
        public IEnumerable<team> Getteams()
        {
            return _context.teams;
        }

        // GET: api/teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Getteam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.teams.FindAsync(id);

            if (team == null)
            {
                return NotFound();
            }

            return Ok(team);
        }

        // PUT: api/teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Putteam([FromRoute] int id, [FromBody] team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.teamid)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/teams
        [HttpPost]
        public async Task<IActionResult> Postteam([FromBody] team team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getteam", new { id = team.teamid }, team);
        }

        // DELETE: api/teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteteam([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var team = await _context.teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.teams.Remove(team);
            await _context.SaveChangesAsync();

            return Ok(team);
        }

        private bool teamExists(int id)
        {
            return _context.teams.Any(e => e.teamid == id);
        }
    }
}