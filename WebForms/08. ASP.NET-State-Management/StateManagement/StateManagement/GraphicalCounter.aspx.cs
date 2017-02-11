using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;

namespace StateManagement
{
    public partial class GraphicalCounter : Page
    {
        private static int visitorsCount = 1;

        protected override void OnPreLoad(EventArgs e)
        {
            if (this.Session["visits"] == null)
            {
                this.Session["visits"] = 1;
            }
            else
            {
                visitorsCount = (int)this.Session["visits"];

                this.Session["visits"] = visitorsCount++;
            }

            DrawImageFromVisitorsCount(visitorsCount);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void DrawImageFromVisitorsCount(int visitorsCount)
        {
            Bitmap image = new Bitmap(400, 200);
            using (image)
            {
                Graphics graphics = Graphics.FromImage(image);
                using (graphics)
                {
                    graphics.DrawString($"Visitors count: {visitorsCount}",
                        new Font("Segoe UI", 25),
                        new SolidBrush(Color.Bisque),
                        new PointF(100, 100));

                    this.Response.ContentType = "image/jpeg";
                    image.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}