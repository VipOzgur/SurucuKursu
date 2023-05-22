using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace SurucuKursu.Models
{
    public partial class Yoneticiler
    {
        //[NotMapped]
        //public bool ChkDurum
        //{
        //    get
        //    {
        //        if (Durum == null) { return false; }
        //        return Durum.Value == 0 ? false : true;
        //    }
        //    set;
        //}

        //Şifre hashleme kodları
        public void SetPasword(string password)
        {
            Pasword = Hash(password);
        }
        [NotMapped]
        public bool ChkDurum { 
            get {
                return Durum == 1 ? true : false;
            }
            set {
                Durum = value ? 1 : 0;
            }
        }

        public string Hash(string input)
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
}
