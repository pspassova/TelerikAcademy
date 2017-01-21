using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;

namespace ImageHandler
{
    public class TextAsImageHandler : IHttpHandler
    {
        private const string MapPath = "images/img.png";
        private const string FontFamilyName = "Sans-serif";
        private const int FontEmSize = 22;
        private const int ImageWidth = 480;
        private const int ImageHeigth = 220;
        private const int PointFCoordinateX = 20;
        private const int PointFCoordinateY = 22;

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string requestedUrl = context.Request.Url.ToString();

            string path = context.Server.MapPath(MapPath);
            Bitmap graphicsMap = new Bitmap(ImageWidth, ImageHeigth, PixelFormat.Format24bppRgb);

            using (Graphics graphics = Graphics.FromImage(graphicsMap))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Color backgroundColor = Color.Azure;
                Font font = new Font(FontFamilyName, FontEmSize, FontStyle.Italic);
                PointF pointF = new PointF(PointFCoordinateX, PointFCoordinateY);

                graphics.Clear(backgroundColor);
                graphics.DrawString(requestedUrl, font, SystemBrushes.WindowText, pointF);
                context.Response.ContentType = "image/png";
                graphicsMap.Save(context.Response.OutputStream, ImageFormat.Png);
            }

        }
    }
}