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

        public async Task<Domain.Entities.PartyInteraction?> GetByIdAsync(string id)
        {
            // Carrega o agregado completo com todas as suas entidades filhas
            return await _context.PartyInteractions
                .Include(p => p.RelatedParty)
                .Include(p => p.Note)
                .Include(p => p.InteractionItem)
                .Include(p => p.Attachment)
                .Include(p => p.ExternalIdentifier)
                .Include(p => p.InteractionRelationship)
                .Include(p => p.RelatedChannel)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Domain.Entities.PartyInteraction>> GetAllAsync()
        {
            // Para listagens, podemos otimizar e não carregar todos os detalhes,
            // mas para manter a consistência inicial, carregamos as partes relacionadas.
            return await _context.PartyInteractions
                .Include(p => p.RelatedParty)
                .AsNoTracking() // Boa prática para consultas de leitura, melhora o desempenho.
                .ToListAsync();
        }

        public async Task CreateAsync(Domain.Entities.PartyInteraction interaction)
        {
            await _context.PartyInteractions.AddAsync(interaction);
        }

        public void Update(Domain.Entities.PartyInteraction interaction)
        {
            // Apenas informa ao EF Core que a entidade inteira foi modificada.
            _context.PartyInteractions.Update(interaction);
        }

        public void Delete(Domain.Entities.PartyInteraction interaction)
        {
            _context.PartyInteractions.Remove(interaction);
        }
    }
}