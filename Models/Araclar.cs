using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Araclar
{
    public long Id { get; set; }

    public string Adı { get; set; } = null!;

    public string? Plaka { get; set; }
}
