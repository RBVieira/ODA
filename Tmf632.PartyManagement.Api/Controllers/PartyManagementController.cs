using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tmf632.PartyManagement.Api.Data;
using Tmf632.PartyManagement.Api.Models;

namespace Tmf632.PartyManagement.Api.Controllers
{
    [ApiController]
    [Route("api/tmf632/partyManagement")]
    public class PartyManagementController : ControllerBase
    {
        private readonly PartyManagementDbContext _context;

        public PartyManagementController(PartyManagementDbContext context)
        {
            _context = context;
        }

        // GET: api/tmf632/partyManagement/individual
        [HttpGet("individual")]
        public async Task<ActionResult<IEnumerable<Individual>>> GetIndividuals()
        {
            return await _context.Individuals.ToListAsync();
        }

        // GET: api/tmf632/partyManagement/individual/{id}
        [HttpGet("individual/{id}")]
        public async Task<ActionResult<Individual>> GetIndividual(string id)
        {
            var individual = await _context.Individuals.FindAsync(id);

            if (individual == null)
            {
                return NotFound();
            }

            return individual;
        }

        // POST: api/tmf632/partyManagement/individual
        [HttpPost("individual")]
        public async Task<ActionResult<Individual>> PostIndividual(Individual individual)
        {
            _context.Individuals.Add(individual);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIndividual), new { id = individual.Id }, individual);
        }
    }
}
