using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Lib
{
    public class PublicTools_ImageController : Controller
    {
        // GET: PublicTools_Image
        public ActionResult Index()
        {
            //string _mark = "I am water mark";
            //string _img1 = @"d:\img1.png";
            //string _img2 = @"d:\img2.jpg";
            //string _saveimg = @"d:\save.jpg";
            //PublicToolsLib.HelpImg.ImageWaterMarkHelper imageWater = new PublicToolsLib.HelpImg.ImageWaterMarkHelper(_mark, _img1, _img2, _saveimg);
            //imageWater.MarkButtomSpace = 50;
            //imageWater.MarkRightSpace = 50;
            //imageWater.CreateMarkPhoto();
            return View();
        }

        /// <summary>
        /// 添加水印
        /// </summary>
        /// <param name="markImg">作为水印的图片</param>
        /// <param name="souceImg">待加水印的图片</param>
        public void ImageMark(HttpPostedFileBase markImg, HttpPostedFileBase sourceImg)
        {
            try
            {

                string _director = "~/content/resource/mark/";
                if (!Directory.Exists(Server.MapPath(_director)))
                {
                    Directory.CreateDirectory(Server.MapPath(_director));
                }

                if (markImg == null || sourceImg == null)
                {
                    return;
                }

                //上传两张图片(水印图片和源图片)到服务器
                string _mImg = Server.MapPath(_director + markImg.FileName);
                string _sImg = Server.MapPath(_director + sourceImg.FileName);
                string _nImg = Server.MapPath(_director + Guid.NewGuid() + ".jpg");
                markImg.SaveAs(_mImg);
                sourceImg.SaveAs(_sImg);

                PublicToolsLib.HelpImg.ImageWaterMarkHelper imageWater = new PublicToolsLib.HelpImg.ImageWaterMarkHelper();
                imageWater.MarkPath = _mImg;//水印图片路径
                imageWater.PhotoPath = _sImg;//源图片路径
                imageWater.SavePath = _nImg;//保存生成后的图片路径
                imageWater.MarkButtomSpace = 50;//水印图片距离源图片底部距离
                imageWater.MarkRightSpace = 50;//水印图片距离源图片右边距离
                imageWater.CreateMarkPhoto();//开始合成

                //合成结束后，删除那两张一传的图片
                if (System.IO.File.Exists(Server.MapPath(_director + markImg.FileName)))
                    System.IO.File.Delete(Server.MapPath(_director + markImg.FileName));
                if (System.IO.File.Exists(Server.MapPath(_director + sourceImg.FileName)))
                    System.IO.File.Delete(Server.MapPath(_director + sourceImg.FileName));                
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 文件水印
        /// </summary>
        /// <param name="sourceImg"></param>
        public void FontMark(HttpPostedFileBase sourceImg)
        {
            //
        }
    }
}