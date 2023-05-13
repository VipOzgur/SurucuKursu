using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using SQLitePCL;
using System.ComponentModel.DataAnnotations.Schema;
using SurucuKursu.MetaData;

namespace SurucuKursu.Models;
[MetadataType(typeof(YoneticilerMetaData))]
public partial class Yoneticiler
{
    public long Id { get; set; }

    public string KullaniciAdi { get; set; } = null!;

    public string Meil { get; set; } = null!;

    public string Pasword { get; set; } = null!;

    public long? Durum
    {
        get;set;
    }

}
