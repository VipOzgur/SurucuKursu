using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class CikmisSorular
{
    public long Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Url { get; set; } = null!;
}
