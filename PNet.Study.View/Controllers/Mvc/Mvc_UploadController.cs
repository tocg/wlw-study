using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Mvc
{
    /// <summary>
    /// MVC 文件上传下载
    /// </summary>
    public class Mvc_UploadController : Controller
    {
        // GET: Mvc_Upload
        public ActionResult Index()
        {
            return View();
        }

        #region 多线程下载

        /// <summary>
        /// 多线程下载
        /// </summary>
        /// <returns></returns>
        public ActionResult MultiDownload()
        {
            return View();
        }

        [HttpPost]
        public void MultiDownload(string httpUrl, int threadNumber=5)
        {
            //string httpUrl = @"http://172.28.98.96/fdimsservice/2.rar";
            string saveUrl = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//" + System.IO.Path.GetFileName(httpUrl);            
            Helper.MultiThreadDownload md = new Helper.MultiThreadDownload(threadNumber, httpUrl, saveUrl);
            md.Start();
        }
        #endregion
    }
}