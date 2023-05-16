using System.Web;
using System.IO;
using System.Drawing;
namespace SurucuKursu
{
	public class PublicClass
	{		
		public string ImgToBase64(string path)
		{
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            string base64Image = Convert.ToBase64String(imageArray);
			return base64Image;
        }
		public void Base64ToImg(string base64)
		{
            byte[] bytes = Convert.FromBase64String(base64);

            using (MemoryStream ms = new MemoryStream(bytes))
            {
                //pic.Image = Image.FromStream(ms);
            }
        }
	}
}
