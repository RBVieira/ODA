using Microsoft.AspNetCore.Mvc;
using Tmf683.PartyInteraction.Api.Models;
using Tmf683.PartyInteraction.Api.Models.Dtos;

namespace Tmf683.PartyInteraction.Api.Services.Interfaces
{
    public interface IPartyInteractionService
    {
        //MÉTODOS DE CRUD
        //PATCH
        Task<IActionResult> PatchPartyInteractionAsync(string id, PartyInteractionDto dto);
        //GET ALL
        Task<IEnumerable<PartyInteractionDto>> GetAllPartyInteractionsAsync();
        //GET by ID
        Task<PartyInteractionDto?> GetPartyInteractionByIdAsync(string id);
        //UPDATE
        Task<bool> UpdatePartyInteractionAsync(string id, PartyInteractionDto dto);
    }
}
