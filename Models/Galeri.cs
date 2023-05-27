using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Galeri
{
    public long Id { get; set; }

    public string? Aciklama { get; set; }

    public string? Resim { get; set; }
}
