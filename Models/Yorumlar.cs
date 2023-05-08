using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurucuKursu.Models;

public partial class Yorumlar
{
	[Key]
	public long Id { get; set; }

    public long? ParentId { get; set; }

	[Required]
	public string Ad { get; set; } = null!;

	[DataType(DataType.EmailAddress),Required]
	public string Mail { get; set; } = null!;

	[Required]
    public string? Metin { get; set; }

    public long? Yildiz { get; set; }
}
