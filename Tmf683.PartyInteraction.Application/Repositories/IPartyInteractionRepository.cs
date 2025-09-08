using Tmf683.PartyInteraction.Domain.Entities;

namespace Tmf683.PartyInteraction.Application.Repositories

{
    public interface IPartyInteractionRepository
    {
        //GET All Interactions
        Task<IEnumerable<Domain.Entities.PartyInteraction>> GetAllPartyInteractionsAsync();
        //GET by ID
        Task<Domain.Entities.PartyInteraction?> GetPartyInteractionByIdAsync(string id);
        //UPDATE
        Task UpdatePartyInteractionAsync(Domain.Entities.PartyInteraction entity);

        Task RemovePartyInteractionAsync(RelatedPartyOrPartyRole entity);
        Task SaveChangesAsync();
    }


}
