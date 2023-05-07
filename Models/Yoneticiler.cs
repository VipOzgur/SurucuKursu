using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class Yoneticiler
{
    public long Id { get; set; }

    public string KullaniciAdi { get; set; } = null!;

    public string Meil { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public long? Durum { get; set; }
}
