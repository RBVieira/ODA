using Tmf683.PartyInteraction.Application.Repositories;

namespace Tmf683.PartyInteraction.Application
{
    public interface IUnitOfWork : IDisposable
    {
        IPartyInteractionRepository PartyInteractions { get; }
        Task<int> CompleteAsync();
    }
}
