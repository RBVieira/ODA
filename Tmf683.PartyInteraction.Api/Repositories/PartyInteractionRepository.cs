using Microsoft.EntityFrameworkCore;
using Tmf683.PartyInteraction.Api.Data;
using Tmf683.PartyInteraction.Api.Models;
using Tmf683.PartyInteraction.Api.Repositories.Interfaces;
//new main
namespace Tmf683.PartyInteraction.Api.Repositories
{
    public class PartyInteractionRepository : IPartyInteractionRepository
    {
        private readonly PartyInteractionDbContext _context;

        public PartyInteractionRepository(PartyInteractionDbContext context)
        {
            _context = context;
        }

        //GET All Interactions
        public async Task<IEnumerable<PartyInteract>> GetAllPartyInteractionsAsync()
        {
            return await _context.PartyInteractions.Include(pi => pi.RelatedParty).ToListAsync();
        }


        //Busca uma interação de party pelo ID, incluindo a entidade RelatedParty
        public async Task<PartyInteract?> GetByIdAsync(string id)
        {
            return await _context.PartyInteractions.Include(pi => pi.RelatedParty).FirstOrDefaultAsync(pi => pi.Id == id);
        }

        //UPDATE
        public async Task UpdateAsync(PartyInteract entity)
        {
            _context.PartyInteractions.Update(entity);
            await _context.SaveChangesAsync();
        }

        //Remove as entradas em RelatedPartyRef que é uma lista dentro de PartyInteract
        //PartyInteract é o que registra a interação, RelatedPartyRef são todas as partes envolvidas na interação
        public async Task RemoveAsync(RelatedPartyRef entity)
        {
            _context.RelatedPartyRefs.Remove(entity);
            await _context.SaveChangesAsync();

        }

        //Apenas para salvar as modificações
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }

}
