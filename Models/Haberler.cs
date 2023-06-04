using SurucuKursu.MetaData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SurucuKursu.Models;
[MetadataType(typeof(HaberlerMetaDataClass))]
public partial class Haberler
{
    public long Id { get; set; }

    public string Baslik { get; set; } = null!;

    public string Metin { get; set; } = null!;

    public string? Medya { get; set; }

    public string? Tarih { get; set; }
}
