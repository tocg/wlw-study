using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Lib
{
    public class PublicToolsController : Controller
    {
        // GET: PublicTools
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoreCode()
        {
            var path = Server.MapPath("~/content/resource/PublicToolsLib.zip");

            if (!System.IO.File.Exists(path))
            {
                Response.Write("<script>alert('文件不存在，请与管理员联系')</script>");
                return View("Index");
            }
            return File(path, "application/x-zip-compressed", "PublicToolsLib.zip");
        }
    }
}