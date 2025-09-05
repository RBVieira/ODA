using Tmf683.PartyInteraction.Api.Models.Entities;

namespace Tmf683.PartyInteraction.Api.Repositories.Interfaces
{
    public interface IPartyInteractionRepository
    {
        //GET All Interactions
        Task<IEnumerable<PartyInteract>> GetAllPartyInteractionsAsync();
        //GET by ID
        Task<PartyInteract?> GetPartyInteractionByIdAsync(string id);
        //UPDATE
        Task UpdatePartyInteractionAsync(PartyInteract entity);

        Task RemovePartyInteractionAsync(RelatedPartyRef entity);
        Task SaveChangesAsync();
    }


}
