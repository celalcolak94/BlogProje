using System.ComponentModel.DataAnnotations;

namespace BlogProje.Models
{
	public class WriterRegisterModel
	{
		[MinLength(2,ErrorMessage = "En az 2 karakter giriniz.")]
		[MaxLength(50,ErrorMessage = "En fazla 50 karakter giriniz.")]
		[Required(ErrorMessage = "Yazar adı soyadı kısmı boş geçilemez.")]
		public string WriterName { get; set; }

		[EmailAddress(ErrorMessage ="E-posta formatında giriniz.")]
		[Required(ErrorMessage = "Mail adresi boş geçilemez.")]
		public string WriterMail { get; set; }

		[RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,12}$", ErrorMessage = "Güvenli Parola seçiniz, 8-12 karakter arası ")]
		[Required(ErrorMessage = "Şifre boş geçilemez.")]
		public string WriterPassword { get; set; }

		[Compare("WriterPassword",ErrorMessage = "Parola eşleşmiyor.")]
		[Required(ErrorMessage = "Şifre boş geçilemez.")]
		public string WriterRePassword { get; set; }
	}
}
