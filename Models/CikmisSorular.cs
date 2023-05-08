using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class CikmisSorular
{
	[Key]
	public long Id { get; set; }

	[Required]	
    public string Baslik { get; set; } = null!;

	[Required]
    public string Url { get; set; } = null!;
}
