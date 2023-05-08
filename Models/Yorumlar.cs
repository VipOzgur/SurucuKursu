using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class Yorumlar
{
	[Key]
	public long Id { get; set; }

    public long? ParentId { get; set; }

    public string Ad { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string? Metin { get; set; }

    public long? Yildiz { get; set; }
}
