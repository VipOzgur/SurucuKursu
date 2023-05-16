using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SurucuKursu.MetaData
{
    public class OnKayitMetaData
    {
        [Key]
        public long Id { get; set; }

        [Required, DisplayName("Ad")]
        public string Ad { get; set; } = null!;

        [Required, DisplayName("Soyad")]
        public string Sayad { get; set; } = null!;

        [Required, DisplayName("Telefon")]
        public long TelNo { get; set; }

        [DataType(DataType.EmailAddress), Required, DisplayName("E-Mail")]
        public string Mail { get; set; } = null!;

        [DisplayName("Mesaj")]
        public string? Aciklama { get; set; }
    }
}
