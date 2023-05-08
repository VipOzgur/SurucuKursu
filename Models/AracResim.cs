using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class AracResim
{
	[Key]
	public long Id { get; set; }

    public long ParentId { get; set; }

    public long Resimler { get; set; }
}
