using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;

public partial class AracResim
{
    public long Id { get; set; }

    public long ParentId { get; set; }

    public long Resimler { get; set; }
}
