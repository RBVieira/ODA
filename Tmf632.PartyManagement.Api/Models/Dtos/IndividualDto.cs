using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace Tmf632.PartyManagement.Api.Models.Dtos
{
    public class IndividualDto
    {

        // A anotação [Key] define esta propriedade como a chave primária
        // do banco de dados.
        [Key]
        [ValidateNever]
        public string Id { get; set; } 

        // Propriedades para dados pessoais básicos
        [Required]
        public string FamilyName { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string FullName { get; set; }

        // Propriedades para contato e endereço
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }

        // Coleções para relacionamentos com outras entidades
        // O Entity Framework Core irá mapear estas coleções automaticamente.
        public List<ContactMediumDto> ContactMedium { get; set; } = new();
        public List<RelatedPartyDto> RelatedParty { get; set; } = new();
        public List<CharacteristicDto> Characteristic { get; set; } = new();

    }
}
