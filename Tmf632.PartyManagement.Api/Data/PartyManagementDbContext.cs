using Microsoft.EntityFrameworkCore;
using Tmf632.PartyManagement.Api.Models; // Certifique-se de que o namespace esteja correto

namespace Tmf632.PartyManagement.Api.Data
{
    public class PartyManagementDbContext : DbContext
    {
        public PartyManagementDbContext(DbContextOptions<PartyManagementDbContext> options) : base(options)
        {
        }

        // Propriedades DbSet representam as coleções de entidades
        // que serão mapeadas para tabelas no banco de dados.
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Organization> Organizations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
