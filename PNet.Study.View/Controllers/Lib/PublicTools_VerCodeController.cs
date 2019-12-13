using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Lib
{
    /// <summary>
    /// 验证码（PublicToolsLib）
    /// </summary>
    public class PublicTools_VerCodeController : Controller
    {

        public ActionResult Index()
        {
            string strCode = PublicToolsLib.HelpVCode.VerificationCodeHelper.CreateNumberCodes(4);
            ViewBag.Code = strCode;
            return View();
        }

        #region 验证码
        /// <summary>
        /// 混合验证码
        /// </summary>
        /// <returns></returns>
        public FileContentResult MixVerifyCode()
        {

            string strCode = PublicToolsLib.HelpVCode.VerificationCodeHelper.CreateBlendCode(4);
            MemoryStream memory = PublicToolsLib.HelpVCode.VerificationCodeHelper.CreateImageCode(strCode);
            return File(memory.ToArray(), "image/gif");


            //string code = HelpVCode.VerificationCodeHelper.GetVerifCode(4);
            //var bitmap = VerifyCodeHelper.GetSingleObj().CreateBitmapByImgVerifyCode(code, 100, 32);
            //MemoryStream stream = new MemoryStream();
            //bitmap.Save(stream, ImageFormat.Gif);
            //return File(stream.ToArray(), "image/gif");
        }
        #endregion
    }
}
