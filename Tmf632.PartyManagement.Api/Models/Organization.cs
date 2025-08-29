using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models
{
    public class Organization
    {
        // A anotação [Key] define esta propriedade como a chave primária.
        [Key]
        public Guid Id { get; set; }

        // Propriedades para dados da organização.
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string TradingName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(100)]
        public string IsHeadOffice { get; set; }

        // Coleções para relacionamentos com outras entidades, seguindo o padrão
        // que usamos para a classe Individual.
        public List<ContactMedium> ContactMedium { get; set; }
        public List<RelatedParty> RelatedParty { get; set; }
        public List<Characteristic> Characteristic { get; set; }

        // Construtor
        public Organization()
        {
            Id = Guid.NewGuid();
        }
    }
}

