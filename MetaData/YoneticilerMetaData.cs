using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.MetaData
{
    public class YoneticilerMetaData
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string KullaniciAdi { get; set; } = null!;

        [DataType(DataType.EmailAddress), Required]
        public string Meil { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        public string Pasword { get; set; } = null!;

        public long? Durum{get; set; }
    }
}
