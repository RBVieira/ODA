using Microsoft.AspNetCore.Mvc;
using Tmf683.PartyInteraction.Api.Models;
using Tmf683.PartyInteraction.Api.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Api.Models.Dtos.Responses;

namespace Tmf683.PartyInteraction.Api.Services.Interfaces
{
    public interface IPartyInteractionService
    {
        //MÉTODOS DE CRUD
        //PATCH
        Task<IActionResult> PatchPartyInteractionAsync(string id, PartyInteractionUpdateDto dto);
        //GET ALL
        Task<IEnumerable<PartyInteractionResponseDto>> GetAllPartyInteractionsAsync();
        //GET by ID
        Task<PartyInteractionResponseDto?> GetPartyInteractionByIdAsync(string id);
        //UPDATE
        Task<bool> UpdatePartyInteractionAsync(string id, PartyInteractionUpdateDto dto);
    }
}
