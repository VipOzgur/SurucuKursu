using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SurucuKursu.Models;

public partial class SkContext : DbContext
{
    public SkContext()
    {
    }

    public SkContext(DbContextOptions<SkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AracResim> AracResims { get; set; }

    public virtual DbSet<Araclar> Araclars { get; set; }

    public virtual DbSet<CikmisSorular> CikmisSorulars { get; set; }

    public virtual DbSet<Egitmenler> Egitmenlers { get; set; }

    public virtual DbSet<Galeri> Galeris { get; set; }

    public virtual DbSet<HaberResim> HaberResims { get; set; }

    public virtual DbSet<Haberler> Haberlers { get; set; }

    public virtual DbSet<Harclar> Harclars { get; set; }

    public virtual DbSet<OnKayit> OnKayits { get; set; }

    public virtual DbSet<Soru> Sorus { get; set; }

    public virtual DbSet<Yoneticiler> Yoneticilers { get; set; }

    public virtual DbSet<Yorumlar> Yorumlars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=.\\Data\\sk.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AracResim>(entity =>
        {
            entity.ToTable("aracResim");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
            entity.Property(e => e.Resimler).HasColumnName("resimler");
        });

        modelBuilder.Entity<Araclar>(entity =>
        {
            entity.ToTable("araclar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adı).HasColumnName("adı");
            entity.Property(e => e.Plaka).HasColumnName("plaka");
        });

        modelBuilder.Entity<CikmisSorular>(entity =>
        {
            entity.ToTable("cikmisSorular");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Baslik).HasColumnName("baslik");
            entity.Property(e => e.Url).HasColumnName("url");
        });

        modelBuilder.Entity<Egitmenler>(entity =>
        {
            entity.ToTable("egitmenler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Ad).HasColumnName("ad");
            entity.Property(e => e.Profil).HasColumnName("profil");
            entity.Property(e => e.Soyad).HasColumnName("soyad");
        });

        modelBuilder.Entity<Galeri>(entity =>
        {
            entity.ToTable("galeri");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Resim).HasColumnName("resim");
        });

        modelBuilder.Entity<HaberResim>(entity =>
        {
            entity.ToTable("haberResim");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.ParentId).HasColumnName("parentId");

            entity.HasOne(d => d.Parent).WithMany(p => p.HaberResims)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Haberler>(entity =>
        {
            entity.ToTable("haberler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Baslik).HasColumnName("baslik");
            entity.Property(e => e.Medya).HasColumnName("medya");
            entity.Property(e => e.Metin).HasColumnName("metin");
            entity.Property(e => e.Tarih).HasColumnName("tarih");
        });

        modelBuilder.Entity<Harclar>(entity =>
        {
            entity.ToTable("harclar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Belge).HasColumnName("belge");
            entity.Property(e => e.KagitBedeli).HasColumnName("kagitBedeli");
            entity.Property(e => e.Ucret).HasColumnName("ucret");
            entity.Property(e => e.VakifBedeli).HasColumnName("vakifBedeli");
        });

        modelBuilder.Entity<OnKayit>(entity =>
        {
            entity.ToTable("onKayit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Aciklama).HasColumnName("aciklama");
            entity.Property(e => e.Ad).HasColumnName("ad");
            entity.Property(e => e.Mail).HasColumnName("mail");
            entity.Property(e => e.Sayad).HasColumnName("sayad");
            entity.Property(e => e.TelNo).HasColumnName("telNo");
        });

        modelBuilder.Entity<Soru>(entity =>
        {
            entity.ToTable("soru");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ad).HasColumnName("ad");
            entity.Property(e => e.Cevap).HasColumnName("cevap");
            entity.Property(e => e.Mail).HasColumnName("mail");
            entity.Property(e => e.Metin).HasColumnName("metin");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
        });

        modelBuilder.Entity<Yoneticiler>(entity =>
        {
            entity.ToTable("yoneticiler");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Durum).HasColumnName("durum");
            entity.Property(e => e.KullaniciAdi).HasColumnName("kullaniciAdi");
            entity.Property(e => e.Meil).HasColumnName("meil");
            entity.Property(e => e.Pasword).HasColumnName("pasword");
        });

        modelBuilder.Entity<Yorumlar>(entity =>
        {
            entity.ToTable("yorumlar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ad).HasColumnName("ad");
            entity.Property(e => e.Mail).HasColumnName("mail");
            entity.Property(e => e.Metin).HasColumnName("metin");
            entity.Property(e => e.ParentId).HasColumnName("parentId");
            entity.Property(e => e.Yildiz).HasColumnName("yildiz");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
