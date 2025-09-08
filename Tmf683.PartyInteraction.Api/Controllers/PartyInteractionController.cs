using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tmf683.PartyInteraction.Application.Common;
using Tmf683.PartyInteraction.Application.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Application.Models.Dtos.Responses;
using Tmf683.PartyInteraction.Application.Services.Interfaces;

namespace Tmf683.PartyInteraction.Api.Controllers
{
    [ApiController]
    [Route("api/tmf683/partyInteraction")]
    [Produces("application/json")]
    public class PartyInteractionController : ControllerBase
    {
        private readonly IPartyInteractionService _service;
        private readonly IMapper _mapper;

        public PartyInteractionController(IPartyInteractionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Cria uma nova Party Interaction.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<PartyInteractionResponseDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PartyInteractionCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ApiResponse<object>.Fail(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            }

            var (createdInteraction, errorMessage) = await _service.CreateAsync(createDto);

            if (errorMessage != null)
            {
                // Erros de negócio, como PartyId não encontrado, retornam BadRequest.
                return BadRequest(ApiResponse<object>.Fail(errorMessage));
            }

            var responseDto = _mapper.Map<PartyInteractionResponseDto>(createdInteraction);
            return CreatedAtAction(nameof(GetById),
                                   new { id = responseDto.Id },
                                   ApiResponse<PartyInteractionResponseDto>.Success(responseDto, StatusCodes.Status201Created));
        }

        /// <summary>
        /// Lista todas as Party Interactions.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<PartyInteractionResponseDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var interactions = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<PartyInteractionResponseDto>>.Success(interactions));
        }

        /// <summary>
        /// Busca uma Party Interaction específica pelo seu ID.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<PartyInteractionResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(string id)
        {
            var interactionDto = await _service.GetByIdAsync(id);

            if (interactionDto == null)
            {
                return NotFound(ApiResponse<object>.Fail($"Interaction with ID '{id}' not found.", StatusCodes.Status404NotFound));
            }

            return Ok(ApiResponse<PartyInteractionResponseDto>.Success(interactionDto));
        }

        /// <summary>
        /// Atualiza parcialmente uma Party Interaction.
        /// </summary>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string id, [FromBody] PartyInteractionUpdateDto updateDto)
        {
            var (updatedInteraction, errorMessage) = await _service.UpdateAsync(id, updateDto);

            if (errorMessage != null)
            {
                if (errorMessage.Contains("não encontrada"))
                    return NotFound(ApiResponse<object>.Fail(errorMessage, StatusCodes.Status404NotFound));

                return BadRequest(ApiResponse<object>.Fail(errorMessage));
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta uma Party Interaction.
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var (success, errorMessage) = await _service.DeleteAsync(id);

            if (!success)
            {
                return NotFound(ApiResponse<object>.Fail(errorMessage, StatusCodes.Status404NotFound));
            }

            return NoContent();
        }
    }
}