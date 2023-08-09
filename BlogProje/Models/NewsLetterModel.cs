using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
    public class NewsLetterModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Lütfen email formatında giriniz.")]
        public string Mail { get; set; }
    }
}
