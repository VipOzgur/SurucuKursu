using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Soru
{
    public long Id { get; set; }

    public long? ParentId { get; set; }

    public string Ad { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Metin { get; set; } = null!;

    public string? Cevap { get; set; }
}
