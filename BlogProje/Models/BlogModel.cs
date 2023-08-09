using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
    public class BlogModel
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Blog başlığını boş geçemezsiniz.")]
        [MaxLength(150,ErrorMessage = "Lütfen 150 karakterden daha az veri girişi yapın.")]
        [MinLength(5,ErrorMessage = "Lütfen 5 karakterden daha çok veri girişi yapın.")]
        public string BlogTitle { get; set; }

        [MaxLength(250, ErrorMessage = "Lütfen 250 karakterden daha az veri girişi yapın.")]
        [MinLength(5, ErrorMessage = "Lütfen 5 karakterden daha çok veri girişi yapın.")]
        [Required(ErrorMessage = "Blog içeriğini boş geçemezsiniz.")]
        public string BlogContent { get; set; }

        public string? BlogThumbnailImage { get; set; }

        [Required(ErrorMessage = "Blog görselini boş geçemezsiniz.")]
        public IFormFile BlogImage { get; set; }

        public int CategoryId { get; set; }

    }
}
