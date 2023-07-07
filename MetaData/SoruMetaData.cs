using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SurucuKursu.MetaData;

public class SoruMetaData
{
    public long Id { get; set; }

    public long? TipId { get; set; }
    [Required]
    public string Ad { get; set; } = null!;
	[DataType(DataType.EmailAddress), Required, DisplayName("E-Mail")]
	public string Mail { get; set; } = null!;
    [Required]
    public string Metin { get; set; } = null!;

    public string? Cevap { get; set; }

    public long? Visibility { get; set; }

    public string? Telefon { get; set; }
}
