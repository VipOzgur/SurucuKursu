using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class Galeri
{
	[Key]
	public long Id { get; set; }

    public string? Aciklama { get; set; }

    public long Resim { get; set; }
}
