using Tmf683.PartyInteraction.Application;
using Tmf683.PartyInteraction.Application.Repositories;
using Tmf683.PartyInteraction.Infrastructure.Data;
using Tmf683.PartyInteraction.Infrastructure.Repositories;

namespace Tmf683.PartyInteraction.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PartyInteractionDbContext _context;
        public IPartyInteractionRepository PartyInteractions { get; private set; }

        public UnitOfWork(PartyInteractionDbContext context)
        {
            _context = context;
            PartyInteractions = new PartyInteractionRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}