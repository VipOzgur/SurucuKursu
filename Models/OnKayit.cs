using SurucuKursu.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SurucuKursu.Models;
[MetadataType(typeof(OnKayitMetaData))]
public partial class OnKayit
{
	public long Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Sayad { get; set; } = null!;

	public long TelNo { get; set; }

	public string Mail { get; set; } = null!;

    public string? Aciklama { get; set; }
}
