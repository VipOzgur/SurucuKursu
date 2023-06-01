using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Ehliyet
{
    public long Id { get; set; }

    public string Sinifi { get; set; } = null!;

    public string? Arac { get; set; }

    public string Aciklama { get; set; } = null!;
}
