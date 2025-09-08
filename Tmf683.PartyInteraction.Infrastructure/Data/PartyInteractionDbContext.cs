using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Tmf683.PartyInteraction.Domain.Entities;

namespace Tmf683.PartyInteraction.Infrastructure.Data
{
    public class PartyInteractionDbContext : DbContext
    {
        public PartyInteractionDbContext(DbContextOptions<PartyInteractionDbContext> options) : base(options)
        {
        }

        // --- Mapeamento das Entidades para Tabelas ---

        // Tabela principal
        public DbSet<Domain.Entities.PartyInteraction> PartyInteractions { get; set; }

        // Tabelas para as entidades aninhadas/relacionadas
        public DbSet<RelatedPartyOrPartyRole> RelatedParties { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<InteractionItem> InteractionItems { get; set; }
        public DbSet<InteractionRelationship> InteractionRelationships { get; set; }
        public DbSet<ExternalIdentifier> ExternalIdentifiers { get; set; }
        public DbSet<RelatedChannel> RelatedChannels { get; set; }
        public DbSet<AttachmentRefOrValue> Attachments { get; set; }

        // O método OnModelCreating é usado para configurar o modelo de forma explícita.
        // É uma boa prática para definir relacionamentos complexos.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define "ODA" como o schema padrão para todas as tabelas neste DbContext.
            modelBuilder.HasDefaultSchema("ODA");

        }
    }
}


