using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SurucuKursu.Models;

public partial class OnKayit
{
	[Key]
	public long Id { get; set; }

	[Required]
    public string Ad { get; set; } = null!;

	[Required, DisplayName("Soyad")]
    public string Sayad { get; set; } = null!;

	[Required, DisplayName("Telefon")]
	public long TelNo { get; set; }

	[DataType(DataType.EmailAddress), Required]
	public string Mail { get; set; } = null!;

    public string? Aciklama { get; set; }
}
