using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Tmf632.PartyManagement.Api.Models
{
    // Classe para características estendidas (atributos personalizados)
    public class Characteristic
    {
        [Key]
        [ValidateNever]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        [ValidateNever]
        public string IndividualId { get; set; }

    }

}
