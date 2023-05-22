using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Haberler
{
    public long Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Metin { get; set; } = null!;

    public string? Medya { get; set; }

    public string? Tarih { get; set; }

    public virtual ICollection<HaberResim> HaberResims { get; set; } = new List<HaberResim>();
}
