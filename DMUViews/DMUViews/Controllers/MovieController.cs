using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DMUViews.Models;

namespace DMUViews.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase ImageVideoFile)
        {
            if (ImageVideoFile!=null)
            {
                string fileName = Path.GetFileName(ImageVideoFile.FileName);
                if(ImageVideoFile.ContentLength< 104857600)
                {
                    ImageVideoFile.SaveAs(Server.MapPath("/VideoFiles/"+fileName));
                    string mainConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlConnection sqlConn = new SqlConnection(mainConn);
                    string sqlquery = "insert into [tblMovies] values @MovieTitle,@ImagePath,@TrailerPath,@DateReleased,@Description,@Genre";
                    SqlCommand sqlComm = new SqlCommand(sqlquery, sqlConn);
                    sqlConn.Open();
                    sqlComm.Parameters.AddWithValue("@TrailerVid", fileName);
                    sqlComm.Parameters.AddWithValue("@ImagePath", "/VideoFiles/" + fileName);
                    sqlComm.Parameters.AddWithValue("@ImagePic", fileName);
                    sqlComm.Parameters.AddWithValue("@ImagePath", "/VideoFiles/" + fileName);
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                    ViewData["Message"] = "Record Saved Successfully !";
                }
            }
            return RedirectToAction("Index");
        }
    }
}