using Tmf683.PartyInteraction.Domain.Entities;

namespace Tmf683.PartyInteraction.Application.Repositories
{
    /// <summary>
    /// Define o contrato para o repositório da entidade PartyInteraction.
    /// É responsável por abstrair a lógica de acesso a dados para o agregado PartyInteraction.
    /// </summary>
    public interface IPartyInteractionRepository
    {
        /// <summary>
        /// Busca uma PartyInteraction pelo seu Id, carregando todas as suas entidades filhas.
        /// </summary>
        /// <param name="id">O Id da interação.</param>
        /// <returns>A entidade PartyInteraction completa ou nulo se não for encontrada.</returns>
        Task<Domain.Entities.PartyInteraction?> GetByIdAsync(string id);

        /// <summary>
        /// Busca todas as PartyInteractions.
        /// </summary>
        /// <returns>Uma coleção de entidades PartyInteraction.</returns>
        Task<IEnumerable<Domain.Entities.PartyInteraction>> GetAllAsync();

        /// <summary>
        /// Adiciona uma nova PartyInteraction ao contexto do banco de dados (não salva).
        /// </summary>
        /// <param name="interaction">A entidade a ser adicionada.</param>
        Task CreateAsync(Domain.Entities.PartyInteraction interaction);

        /// <summary>
        /// Marca uma entidade PartyInteraction como modificada no contexto (não salva).
        /// </summary>
        /// <param name="interaction">A entidade a ser atualizada.</param>
        void Update(Domain.Entities.PartyInteraction interaction);

        /// <summary>
        /// Marca uma entidade PartyInteraction para exclusão no contexto (não salva).
        /// </summary>
        /// <param name="interaction">A entidade a ser excluída.</param>
        void Delete(Domain.Entities.PartyInteraction interaction);
    }
}
