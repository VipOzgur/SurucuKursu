using Microsoft.AspNetCore.Mvc;
using SurucuKursu.MetaData;
using System;
using System.Collections.Generic;

namespace SurucuKursu.Models;
[ModelMetadataType(typeof(OnKayitMetaData))]
public partial class OnKayit
{
    public long Id { get; set; }

    public string Ad { get; set; } = null!;

    public string Sayad { get; set; } = null!;

    public long TelNo { get; set; }

    public string Mail { get; set; } = null!;

    public string? Aciklama { get; set; }
}
