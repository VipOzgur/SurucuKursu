using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Text;
using SQLitePCL;

namespace SurucuKursu.Models;

public partial class Yoneticiler
{
    [Key]
    public long Id { get; set; }

    [Required]
    public string KullaniciAdi { get; set; } = null!;

    [DataType(DataType.EmailAddress), Required]
    public string Meil { get; set; } = null!;

    [Required, DataType(DataType.Password)]
    public string Pasword { get; set; } = null!;

    public long? Durum { get; set; }

    //Şifre hashleme kodları
    public void SetPasword(string password)
    {
        this.Pasword = Hash(password);
    }

    public string Hasher(string password)
    {
        string hashedPassword = Hash(password);
        return hashedPassword;
    }

    private static string Hash(string input)
    {
        //int hash = 0;
        //foreach(char c in input)
        //{
        //	int i=(int)c;
        //	hash += i;
        //}
        //if(hash %2==0)
        //{
        //	hash+=hash * 3 / 2;
        //}
        //else
        //{
        //	hash = hash - 1;
        //	hash+=hash * 3 / 2;
        //}
        //return hash.ToString();



        using (SHA256 sha256Hash = SHA256.Create())
        {
        	byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        	StringBuilder builder = new StringBuilder();
        	for (int i = 0; i < bytes.Length; i++)
        	{
        		builder.Append(bytes[i].ToString("x2"));
        	}
        	return builder.ToString();
        }
    }
}
