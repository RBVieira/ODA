using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tmf632.PartyManagement.Api.Data;
using Tmf632.PartyManagement.Api.Models;
using Tmf632.PartyManagement.Api.Models.Dtos;

namespace Tmf632.PartyManagement.Api.Controllers
{
    [ApiController]
    [Route("api/tmf632/partyManagement")]
    public class PartyManagementController : ControllerBase
    {
        private readonly PartyManagementDbContext _context;
        private readonly IMapper _mapper;

        public PartyManagementController(PartyManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/tmf632/partyManagement/individual
        [HttpGet("individual")]
        public async Task<ActionResult<IEnumerable<IndividualDto>>> GetIndividuals()
        {
            var individuals = await _context.Individuals.ToListAsync();
            IEnumerable<IndividualDto> individualDto = _mapper.Map<IEnumerable<IndividualDto>>(individuals);
            return Ok(individualDto);
        }

        // GET: api/tmf632/partyManagement/individual/{id}
        [HttpGet("individual/{id}")]
        public async Task<ActionResult<IndividualDto>> GetIndividual(string id)
        {
            var individual = await _context.Individuals.FindAsync(id);

            if (individual == null)
            {
                return NotFound();
            }

            return _mapper.Map<IndividualDto>(individual);
        }

        // POST: api/tmf632/partyManagement/individual
        [HttpPost("individual")]
        public async Task<ActionResult<IndividualDto>> PostIndividual(IndividualDto individualDto)
        {
            var individual = _mapper.Map<Individual>(individualDto);

            // Garantir que um novo ID seja gerado para a nova organização
            individual.Id = Guid.NewGuid().ToString();

            _context.Individuals.Add(individual);
            await _context.SaveChangesAsync();

            var createdIndividualDto = _mapper.Map<IndividualDto>(individual);

            return CreatedAtAction(nameof(GetIndividual), new { id = createdIndividualDto.Id }, createdIndividualDto);
        }


        /// <summary>
        /// A PARTIR DAQUI É ORGANIZATIONS
        /// </summary>
 

        // GET: api/tmf632/partyManagement/organization
        [HttpGet("organization")]
        public async Task<ActionResult<IEnumerable<OrganizationDto>>> GetOrganizations()
        {
            var organizations = await _context.Organizations.ToListAsync();
            IEnumerable<OrganizationDto> organizationDto = _mapper.Map<IEnumerable<OrganizationDto>>(organizations);
            return Ok(organizationDto);//retorna uma lista de todas as organizações
        }

        // GET: api/tmf632/partyManagement/organization/{id}
        [HttpGet("organization/{id}")]
        public async Task<ActionResult<OrganizationDto>> GetOrganization(string id)
        {
            var organization = await _context.Organizations.FindAsync(id);

            if (organization == null)
            {
                return NotFound();
            }

            return _mapper.Map<OrganizationDto>(organization);
        }


        // POST: api/tmf632/partyManagement/organization
        [HttpPost("organization")]
        public async Task<ActionResult<IndividualDto>> PostOrganization(OrganizationDto organizationDto)
        {
            var organization = _mapper.Map<Organization>(organizationDto);

            // Garantir que um novo ID seja gerado para a nova organização
            organization.Id = Guid.NewGuid().ToString();

            _context.Organizations.Add(organization);
            await _context.SaveChangesAsync();

            var createdOrganizationDto = _mapper.Map<OrganizationDto>(organization);

            return CreatedAtAction(nameof(GetIndividual), new { id = createdOrganizationDto.Id }, createdOrganizationDto);
        }
    }
}
