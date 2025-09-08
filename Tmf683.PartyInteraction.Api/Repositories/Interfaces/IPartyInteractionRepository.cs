using Tmf683.PartyInteraction.Api.Models.Entities;

namespace Tmf683.PartyInteraction.Api.Repositories.Interfaces
{
    public interface IPartyInteractionRepository
    {
        //GET All Interactions
        Task<IEnumerable<Models.Entities.PartyInteraction>> GetAllPartyInteractionsAsync();
        //GET by ID
        Task<Models.Entities.PartyInteraction?> GetPartyInteractionByIdAsync(string id);
        //UPDATE
        Task UpdatePartyInteractionAsync(Models.Entities.PartyInteraction entity);

        Task RemovePartyInteractionAsync(RelatedPartyOrPartyRole entity);
        Task SaveChangesAsync();
    }


}
