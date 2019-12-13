using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Lib
{
    public class PublicTools_ZipController : Controller
    {
        public ActionResult Index()
        {
            //ZipUnCompressFile();
            return View();
        }

        public ActionResult ZipDetailCode()
        {
            return View();
        }

        //压缩单个文件
        public void ZipCompressFile()
        {
            PublicToolsLib.HelpZip.SharpZipHelper.CompressFile(@"C:\Users\lenovo\Desktop\dd.xls", @"C:\Users\lenovo\Desktop\dd.zip");
        }

        //压缩整个目录
        public void ZipCompressDiectory()
        {
            PublicToolsLib.HelpZip.SharpZipHelper.CompressDirectory(@"C:\Users\lenovo\Desktop\1704A",
                @"C:\Users\lenovo\Desktop", null, false);
        }

        //解压文件
        public void ZipUnCompressFile()
        {
            PublicToolsLib.HelpZip.SharpZipHelper.UnCompressFile(@"C:\Users\lenovo\Desktop\1704A.zip",
                @"C:\Users\lenovo\Desktop\1705", "");
        }
    }
}
