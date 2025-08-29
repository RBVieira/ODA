using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;

namespace Tmf632.PartyManagement.Api.Models
{
    public class Individual
    {

        // A anotação [Key] define esta propriedade como a chave primária
        // do banco de dados.
        [Key]
        public Guid Id { get; set; }

        // Propriedades para dados pessoais básicos
        [Required, MaxLength(100)]
        public string FamilyName { get; set; }
        [Required, MaxLength(100)]
        public string GivenName { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; }

        // Propriedades para contato e endereço
        [Required, MaxLength(100)]
        public string Gender { get; set; }
        [Required, MaxLength(100)]
        public string Nationality { get; set; }
        public DateTime? BirthDate { get; set; }

        // Coleções para relacionamentos com outras entidades
        // O Entity Framework Core irá mapear estas coleções automaticamente.
        public List<ContactMedium> ContactMedium { get; set; } = new();
        public List<RelatedParty> RelatedParty { get; set; } = new();
        public List<Characteristic> Characteristic { get; set; } = new();

        // Construtor
        public Individual()
        {
            Id = Guid.NewGuid();
        }

    }
}
