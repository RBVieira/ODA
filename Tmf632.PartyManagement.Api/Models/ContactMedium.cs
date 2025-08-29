using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models
{
    // Classe para informações de contato (ex: email, telefone)
    public class ContactMedium
    {
        [Key]
        public string Id { get; set; }
        public string MediumType { get; set; }
        public string Preferred { get; set; }
        public string Value { get; set; }
        public string IndividualId { get; set; }

    }
    

    }
