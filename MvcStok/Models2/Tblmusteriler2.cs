using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcStok.Models2;

public partial class Tblmusteriler2
{
    public int Musteriid { get; set; }

    [Required(ErrorMessage ="Bu alanı boş bırakamazsınız...")]
    [MaxLength(50,ErrorMessage ="En fazla 50 karakterlik isim giriniz...")]
    public string? Musteriad { get; set; }

    public string? Musterisoyad { get; set; }

    public virtual ICollection<Tblsatislar> Tblsatislars { get; set; } = new List<Tblsatislar>();
}
