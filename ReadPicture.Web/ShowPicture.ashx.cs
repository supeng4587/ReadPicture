using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using ReadPicture.BLL;
using ReadPicture.Model;
using System.Drawing;
using System.IO;

namespace ReadPicture.Web
{
    /// <summary>
    /// ShowPicture 的摘要说明
    /// </summary>
    public class ShowPicture : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string fastName = context.Request.Form["txtFastName"].ToString();

            BLL.PictureService pictureService = new BLL.PictureService();
            Model.Picture picture = pictureService.readSingle(fastName);

            if (picture != null)
            {
                MemoryStream ms = new MemoryStream(picture.PictureBinary);
                // Image readResult = Image.FromStream(ms);
                string dir = "/Image/";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                string filename = Path.GetFileName(picture.FastDfsFileName);
                string fullName = dir + filename;
                using (Image img = Image.FromStream(ms))
                {
                    using (Bitmap map = new Bitmap(img.Width, img.Height))
                    {
                        using (Graphics g = Graphics.FromImage(map))
                        {
                            g.DrawImage(img, 0, 0, img.Width, img.Height);
                            map.Save(context.Request.MapPath(fullName));
                        }
                    }
                }

                context.Response.Write("<html><body><img src='" + fullName + "'/></body></html>");
            }
            else
            {
                context.Response.Write("未能正常读取图片。");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}