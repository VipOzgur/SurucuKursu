using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurucuKursu.MetaData
{
    public class YoneticilerMetaData
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string KullaniciAdi { get; set; } = null!;

		[DataType(DataType.EmailAddress), Required, DisplayName("E-Mail")]
		public string Meil { get; set; } = null!;

        [Required, DataType(DataType.Password)]
        public string Pasword { get; set; } = null!;

        public long? Durum{get; set; }

        [Required,NotMapped ]
        public bool ChkDurum { get; set; }
    }
}
