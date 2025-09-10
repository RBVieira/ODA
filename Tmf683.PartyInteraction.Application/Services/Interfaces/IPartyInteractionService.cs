using Tmf683.PartyInteraction.Application.Models.Dtos.Requests;
using Tmf683.PartyInteraction.Application.Models.Dtos.Responses;
using PartyInteractionEntity = Tmf683.PartyInteraction.Domain.Entities.PartyInteraction; //Um alias para a entidade PartyInteraction

namespace Tmf683.PartyInteraction.Application.Services.Interfaces
{
    /// <summary>
    /// Define o contrato para a lógica de negócio relacionada à PartyInteraction.
    /// </summary>
    public interface IPartyInteractionService
    {
        /// <summary>
        /// Busca todas as interações.
        /// </summary>
        Task<IEnumerable<PartyInteractionResponseDto>> GetAllAsync();

        /// <summary>
        /// Busca uma interação específica pelo seu Id.
        /// </summary>
        Task<PartyInteractionResponseDto?> GetByIdAsync(string id);

        /// <summary>
        /// Cria uma nova interação, aplicando regras de negócio e validações.
        /// </summary>
        /// <returns>Uma tupla contendo a entidade criada e uma mensagem de erro, se houver.</returns>
        Task<(PartyInteractionEntity? CreatedInteraction, string? ErrorMessage)> CreateAsync(PartyInteractionCreateDto createDto);

        /// <summary>
        /// Atualiza parcialmente uma interação existente.
        /// </summary>
        /// <returns>Uma tupla contendo a entidade atualizada e uma mensagem de erro, se houver.</returns>
        Task<(PartyInteractionEntity? UpdatedInteraction, string? ErrorMessage)> UpdateAsync(string id, PartyInteractionUpdateDto updateDto);

        /// <summary>
        /// Deleta uma interação.
        /// </summary>
        /// <returns>Uma tupla indicando sucesso e uma mensagem de erro, se houver.</returns>
        Task<(bool Success, string? ErrorMessage)> DeleteAsync(string id);
    }
}
