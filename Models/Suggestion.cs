using Newton = Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Perplex.Models
{
    public class Suggestion
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [StringLength(512, ErrorMessage = "Het onderwerp mag niet meer dan 512 characters hebben.")]
        [Required(ErrorMessage = "Het Onderwerp is vereist.")]
        public string Onderwerp { get; set; }
        [Required(ErrorMessage = "De Beschrijving is vereist.")]
        public string Beschrijving { get; set; }
        public int? UserId { get; set; }
        [StringLength(512, ErrorMessage = "De username mag niet meer dan 512 characters hebben.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "De Type is vereist.")]
        [RegularExpression(@"^(uitje|suggestie)$", ErrorMessage = "Type moet 'uitje' of 'suggestie' zijn.")]
        public string Type { get; set; }
        [RequiredIfUitje("Type", ErrorMessage = "Begindatum is vereist bij type 'uitje'.")]
        public DateTime? BeginDatum { get; set; }
        [RequiredIfUitje("Type", ErrorMessage = "Einddatum is vereist bij type 'uitje'.")]
        public DateTime? EindDatum { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public string? Categories { get; set; }
        [NotMapped]
        [MaxLength(512, ErrorMessage = "categories mag niet meer dan 512 characters hebben.")]
        [JsonPropertyName("categories")]
        public List<string>? CategoriesList
        {
            get => string.IsNullOrEmpty(Categories) ? new List<string>() : Newton.JsonConvert.DeserializeObject<List<string>>(Categories);
            set => Categories = Newton.JsonConvert.SerializeObject(value);
        }
        [NotMapped]
        [System.Text.Json.Serialization.JsonIgnore]
        public TimeSpan? Duur => EindDatum - BeginDatum;
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
