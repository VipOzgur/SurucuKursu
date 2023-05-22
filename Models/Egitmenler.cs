using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Egitmenler
{
    public long Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Soyad { get; set; } = null!;

    public string Aciklama { get; set; } = null!;

    public string? Profil { get; set; }
}
