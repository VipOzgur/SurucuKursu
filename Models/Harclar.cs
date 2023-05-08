using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class Harclar
{
	[Key]
	public long Id { get; set; }

    public string Belge { get; set; } = null!;

    public string Ucret { get; set; } = null!;

    public long KagitBedeli { get; set; }

    public long VakifBedeli { get; set; }
}
