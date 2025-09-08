using Microsoft.EntityFrameworkCore;
using Tmf683.PartyInteraction.Application.Repositories;
using Tmf683.PartyInteraction.Domain.Entities;
using Tmf683.PartyInteraction.Infrastructure.Data;

namespace Tmf683.PartyInteraction.Infrastructure.Repositories
{
    public class PartyInteractionRepository : IPartyInteractionRepository
    {
        private readonly PartyInteractionDbContext _context;

        public PartyInteractionRepository(PartyInteractionDbContext context)
        {
            _context = context;
        }

        //GET All Interactions
        public async Task<IEnumerable<Domain.Entities.PartyInteraction>> GetAllPartyInteractionsAsync()
        {
            return await _context.PartyInteractions.Include(pi => pi.RelatedParty).ToListAsync();
        }


        //Busca uma interação de party pelo ID, incluindo a entidade RelatedParty
        public async Task<Domain.Entities.PartyInteraction?> GetPartyInteractionByIdAsync(string id)
        {
            return await _context.PartyInteractions.Include(pi => pi.RelatedParty).FirstOrDefaultAsync(pi => pi.Id == id);
        }

        //UPDATE
        public async Task UpdatePartyInteractionAsync(Domain.Entities.PartyInteraction entity)
        {
            _context.PartyInteractions.Update(entity);
            await _context.SaveChangesAsync();
        }

        //Remove as entradas em RelatedPartyRef que é uma lista dentro de PartyInteract
        //PartyInteract é o que registra a interação, RelatedPartyRef são todas as partes envolvidas na interação
        public async Task RemovePartyInteractionAsync(RelatedPartyOrPartyRole entity)
        {
            _context.RelatedParties.Remove(entity);
            await _context.SaveChangesAsync();

        }

        //Apenas para salvar as modificações
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }

}
