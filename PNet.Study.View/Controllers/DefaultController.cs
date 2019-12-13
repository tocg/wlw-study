using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers
{
    public class DefaultController : Controller
    {
        #region 基本视图

        public ActionResult Index()
        {
            if (Session["username"] == null)
               return RedirectToAction("/login");
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }


        public ActionResult Login()
        {
            Session["username"] = "admin";
            Session.Timeout = 60;
            return View();
        }
        public ActionResult Regist()
        {
            return View();
        }
        public ActionResult Logout()
        {
            return View();
        }

        #endregion

        #region Test

        /// <summary>
        /// html转pdf jspdf
        /// </summary>
        /// <returns></returns>
        public ActionResult TestHtmlPdf()
        {
            return View();
        }
        #endregion


        /// <summary>
        /// 读取本地json数据
        /// </summary>
        private void ReadJson()
        {
            using (StreamReader r = new StreamReader( Server.MapPath("~/content/menudata.json")))
            {
                string json = r.ReadToEnd();
                dynamic items = JsonConvert.DeserializeObject<dynamic>(json);
            }
        }
    }
}