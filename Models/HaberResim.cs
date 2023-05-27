using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class HaberResim
{
    public long Id { get; set; }

    public long ParentId { get; set; }

    public string? Aciklama { get; set; }

    public string? Resim { get; set; }

    public virtual Haberler Parent { get; set; } = null!;
}
