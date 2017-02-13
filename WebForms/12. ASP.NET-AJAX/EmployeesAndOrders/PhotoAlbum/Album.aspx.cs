using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace PhotoAlbum
{
    public partial class Album : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static Slide[] GetImages()
        {
            IList<Slide> slides = new List<Slide>();

            string path = HttpContext.Current.Server.MapPath("~/images/");
            if (path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1);
            }

            Uri pathUri = new Uri(path, UriKind.Absolute);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Uri filePathUri = new Uri(file, UriKind.Absolute);
                slides.Add(new Slide
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Description = $"{Path.GetFileNameWithoutExtension(file)} - description",
                    ImagePath = $"/{pathUri.MakeRelativeUri(filePathUri).ToString()}"
                });
            }

            return slides.ToArray();
        }
    }
}