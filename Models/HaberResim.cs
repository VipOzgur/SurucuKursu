using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class HaberResim
{
	[Key]
	public long Id { get; set; }

    public long ParentId { get; set; }

    public string? Aciklama { get; set; }

    public virtual Haberler Parent { get; set; } = null!;
}
