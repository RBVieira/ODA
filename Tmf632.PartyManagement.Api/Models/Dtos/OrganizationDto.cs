using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models.Dtos
{
    public class OrganizationDto
    {
        // A anotação [Key] define esta propriedade como a chave primária.
        [Key]
        [ValidateNever]
        public string Id { get; set; }

        // Propriedades para dados da organização.
        [Required]
        public string Name { get; set; }
        [Required]
        public string TradingName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsHeadOffice { get; set; }

        // Coleções para relacionamentos com outras entidades, seguindo o padrão
        // que usamos para a classe Individual.
        public List<ContactMediumDto> ContactMedium { get; set; } = new();
        public List<RelatedPartyDto> RelatedParty { get; set; } = new();
        public List<CharacteristicDto> Characteristic { get; set; } = new();

    }
}

