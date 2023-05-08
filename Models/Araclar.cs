using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class Araclar
{
	[Key]
	public long Id { get; set; }

    public string Adı { get; set; } = null!;

    public string? Plaka { get; set; }
}
