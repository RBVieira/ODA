using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tmf683.PartyInteraction.Api.Data;
using Tmf683.PartyInteraction.Api.Models;
using Tmf683.PartyInteraction.Api.Models.Dtos;
using AutoMapper;
using System.Net.Http;
using System.Net;
using Microsoft.Extensions.Options;
using Tmf683.PartyInteraction.Api.Models.APIs;
using Tmf683.PartyInteraction.Api.Services.Interfaces;



[ApiController]
[Route("api/[controller]")]
public class PartyInteractionController : ControllerBase
{
    private readonly PartyInteractionDbContext _context; //Utiliza o DB Context direto mas paulatinamente será substituído pelo _service
    private readonly IMapper _mapper;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly Tmf632ApiConfiguration _tmf632Config; // Configuração da API TMF632
    private readonly IPartyInteractionService _service; //service de acesso aos dados



    public PartyInteractionController(
        PartyInteractionDbContext context,
        IMapper mapper, 
        IHttpClientFactory httpClientFactory, //Cliente HTTP para chamadas externas
        IOptions<Tmf632ApiConfiguration> tmf632Config, // injeção de configuração dos dados da API TMF632
        IPartyInteractionService service) 
    {
        _context = context;
        _mapper = mapper;
        _httpClientFactory = httpClientFactory;
        _tmf632Config = tmf632Config.Value;
        _service = service;

    }


    //Traz a relação de todas as interações do cliente ou organização
    [HttpGet]
    public async Task<IActionResult> GetPartyInteractions()
    {
        var result = await _service.GetAllPartyInteractionsAsync();
        return Ok(result);
    }

    //Consulta uma interação específica pelo seu ID
    [HttpGet("{id}")]
    public async Task<ActionResult<PartyInteractionDto>> GetPartyInteractions(string id)
    {
        var interaction = await _context.PartyInteractions.Include(pi => pi.RelatedParty).FirstOrDefaultAsync(pi => pi.Id == id);

        if (interaction == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<PartyInteractionDto>(interaction));
    }


    // Operação de UPDATE (PATCH) em uma interação, seguindo o padrão TM Forum
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchPartyInteraction(string id, [FromBody] PartyInteractionDto dto)
    {
        //chamada do serviço que implementa a lógica de patch
        return await _service.PatchInteractionAsync(id, dto);

    }



    //Este POST é para criar uma nova interação para um cliente ou organização, o cliente ou organização deve existir na API TMF632
    //A API TMF683 Party Interaction atua como um orquestrador. Ela não armazena dados de Individual ou Organization em seu próprio banco de dados,
    //mas sim consulta a fonte oficial (TMF632) e armazena apenas a referência, criando uma nova interação associada a esse PartyId em seu banco de dados.
    [HttpPost]
    public async Task<IActionResult> PostPartyInteraction([FromBody] PartyInteractionDto interactionDto)
    {
        // 1. Validação de dados de entrada
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // 2. Orquestração: Valida se o PartyId existe na API no POST recebido
        var relatedPartyRefDto = interactionDto.RelatedParty.FirstOrDefault();
        if (relatedPartyRefDto == null)
        {
            return BadRequest("A Party Interaction deve ter pelo menos um Related Party.");
        }

        //Cria o cliente HTTP para chamar a API TMF632
        var client = _httpClientFactory.CreateClient("PartyManagementClient");

        // Define a URL base para o cliente HTTP usando a configuração injetada
        var endpointUrl = $"{_tmf632Config.BaseUrl}{_tmf632Config.GetIndividualEndpoint}{relatedPartyRefDto.PartyId}";

        // Chama a API TMF632 para buscar os dados do PartyID
        var response = await client.GetAsync(endpointUrl);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return NotFound($"PartyId '{relatedPartyRefDto.PartyId}' não encontrado na API TMF632.");
        }

        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        // 3. Conversão e persistência
        var interaction = _mapper.Map<PartyInteract>(interactionDto);

        // Define valores padrão para os campos
        interaction.Id = Guid.NewGuid().ToString();
        interaction.CreationDate = DateTime.UtcNow;
        interaction.LastUpdateDate = DateTime.UtcNow;
        interaction.Status = "Iniciado"; // ou outro status inicial padrão

        foreach (var relatedPartyRef in interaction.RelatedParty)
        {
            relatedPartyRef.PartyInteractionId = interaction.Id;
        }

        _context.PartyInteractions.Add(interaction);
        await _context.SaveChangesAsync();

        // 4. Retorno HTTP com o recurso criado
        var createdInteractionDto = _mapper.Map<PartyInteractionDto>(interaction);
        return CreatedAtAction(nameof(GetPartyInteractions), new { id = createdInteractionDto.Id }, createdInteractionDto);
    }
}
