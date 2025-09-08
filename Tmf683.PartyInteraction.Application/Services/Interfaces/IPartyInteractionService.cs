
using Microsoft.AspNetCore.Mvc;
using Tmf683.PartyInteraction.Application.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Application.Models.Dtos.Responses;

namespace Tmf683.PartyInteraction.Application.Services.Interfaces
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
