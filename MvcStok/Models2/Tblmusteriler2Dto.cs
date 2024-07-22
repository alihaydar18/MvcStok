using System.ComponentModel.DataAnnotations;

namespace MvcStok.Models2
{
    public class Tblmusteriler2Dto
    {

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız...")]
        [MaxLength(50, ErrorMessage = "En fazla 50 karakterlik isim giriniz...")]
        public string Musteriad { get; set; }

        public string? Musterisoyad { get; set; }
    }
}
