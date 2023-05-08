using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class CikmisSorular
{
	[Key]
	public long Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Url { get; set; } = null!;
}
