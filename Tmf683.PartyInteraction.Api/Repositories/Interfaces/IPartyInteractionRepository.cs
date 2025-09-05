using Tmf683.PartyInteraction.Api.Models;

namespace Tmf683.PartyInteraction.Api.Repositories.Interfaces
{
    public interface IPartyInteractionRepository
    {
        //GET All Interactions
        Task<IEnumerable<PartyInteract>> GetAllPartyInteractionsAsync();
        //GET by ID
        Task<PartyInteract?> GetByIdAsync(string id);
        //UPDATE
        Task UpdateAsync(PartyInteract entity);

        Task RemoveAsync(RelatedPartyRef entity);
        Task SaveChangesAsync();
    }


}
