using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class Haberler
{
	[Key]
	public long Id { get; set; }

    [Required]
    public string Baslik { get; set; } = null!;

    [Required]
    public string Metin { get; set; } = null!;

    public string? Medya { get; set; }

    public string? Tarih { get; set; }

    public virtual ICollection<HaberResim> HaberResims { get; set; } = new List<HaberResim>();
}
