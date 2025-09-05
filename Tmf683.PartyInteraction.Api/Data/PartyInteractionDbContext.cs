using Microsoft.EntityFrameworkCore;
using Tmf683.PartyInteraction.Api.Models.Entities;


namespace Tmf683.PartyInteraction.Api.Data
{
    public class PartyInteractionDbContext : DbContext
    {
        public PartyInteractionDbContext(DbContextOptions<PartyInteractionDbContext> options) : base(options)
        {
        }

        // Propriedades DbSet representam as coleções de entidades
        // que serão mapeadas para tabelas no banco de dados.
        public DbSet<PartyInteract> PartyInteractions { get; set; }
        public DbSet<RelatedPartyRef> RelatedPartyRefs { get; set; }

    }
}
