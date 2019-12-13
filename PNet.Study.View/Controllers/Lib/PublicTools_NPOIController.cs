using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNet.Study.View.Controllers.Lib
{
    /// <summary>
    ///  NPOI导入导出（PublicToolsLib）
    /// </summary>
    public class PublicTools_NPOIController : Controller
    {
        DataTable dt = new DataTable();
        public PublicTools_NPOIController()
        {

            #region 构建DataTable数据源
            for (int i = 0; i < 4; i++)
            {
                DataColumn dc = new DataColumn("column" + i.ToString());
                dt.Columns.Add(dc);
            }

            for (int i = 0; i < 10; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    dr[j] = $"我是{i}行{j}列";
                }
                dt.Rows.Add(dr);
            }
            #endregion
        }

        // GET: Excel
        public ActionResult Index()
        {
            if (Session["dt"] != null)
                return View(Session["dt"] as DataTable);
            return View(dt);
        }

        #region NPOI Code View
        public ActionResult CoreCode()
        {
            return View();
        }
        #endregion

        #region NPOI Export Excel

        //导出-浏览器下载方式
        public void NpoiExportByResponse()
        {
            System.IO.MemoryStream ms = GetExportExcelMemoryStream(dt);

            //导出的文件名
            string strFileName = "Download_" + System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "");

            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", strFileName));
            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            ms.Close();
            ms.Dispose();
        }

        //导出-文件流方式
        public FileResult NpoiExportByFileResult()
        {

            System.IO.MemoryStream ms = GetExportExcelMemoryStream(dt);

            //导出的文件名
            string strFileName = "Download_" + System.DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "");

            return File(ms, "application/vnd.ms-excel", $"{strFileName}.xls");
        }

        //获取将DataTable的数据写入的内存流
        public System.IO.MemoryStream GetExportExcelMemoryStream(DataTable dt)
        {
            //自定义导出的列(Key为自定义列名，Value为数据表的列名)
            Dictionary<string, string> keys = new Dictionary<string, string>();
            keys.Add("列名1", "column0");
            keys.Add("列名2", "column1");
            keys.Add("列名3", "column2");
            keys.Add("列名4", "column3");

            //调用封装导出方法
            System.IO.MemoryStream ms = PublicToolsLib.HelpExcel.NpoiExcelHelper.ExportExcel(dt, keys);

            //返回内存流
            return ms;
        }

        #endregion

        #region NPOI  Excel Import DataTable

        //上传文件
        public ActionResult NpoiImportUploadExcel(HttpPostedFileBase inputFile)
        {
            if (inputFile == null)
            {
                return null;
            }

            //服务器上存放要上传的文件的目录存不存，不存在则创建
            if (!Directory.Exists(Server.MapPath("/resource/")))
            {
                Directory.CreateDirectory(Server.MapPath("/resource/"));
            }
            //拼接文件路径
            string filePath = Server.MapPath("/resource/" + inputFile.FileName);
            //上传文件
            inputFile.SaveAs(filePath);

            ReadUploadExcelToDataTable(filePath);

            return Redirect("/Excel/Index");
        }

        //读取excel文件内容存放到DataTable中
        public void ReadUploadExcelToDataTable(string strFilePath)
        {
            DataTable _dt = PublicToolsLib.HelpExcel.NpoiExcelHelper.ImportExcel(strFilePath);

            Session["dt"] = _dt;

        }

        #endregion
    }
}
