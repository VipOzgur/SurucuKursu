using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class AracResim
{
    public long Id { get; set; }

    public long ParentId { get; set; }

    public string Resim { get; set; } = null!;
}
