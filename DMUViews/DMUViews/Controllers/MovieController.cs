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
        private ApplicationDbContext _entities = new ApplicationDbContext();

        // GET: Movie
        public ActionResult AddMovies()
        {
            return View(_entities.Movies.ToList());
        }
        [HttpPost]
        public ActionResult AddMovies(HttpPostedFileBase ImageVideoFile)
        {
            if (ImageVideoFile != null)
            {
                string fileName = Path.GetFileName(ImageVideoFile.FileName);
                if (ImageVideoFile.ContentLength < 104857600)
                {
                    ImageVideoFile.SaveAs(Server.MapPath("/ImageVideoFile/" + fileName));
                    string mainConn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    SqlConnection sqlConn = new SqlConnection(mainConn);
                    SqlCommand sqlComm = new SqlCommand("Sproc_AddMovie", sqlConn);
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlConn.Open();
                    sqlComm.Parameters.AddWithValue("@MovieTitle", fileName);
                    sqlComm.Parameters.AddWithValue("@GenreName", fileName);
                    sqlComm.Parameters.AddWithValue("@Description", fileName);
                    sqlComm.Parameters.AddWithValue("@DateReleased", Convert.ToDateTime(fileName));
                    sqlComm.Parameters.AddWithValue("@ImagePath", "/ImageVideoFiles/" + fileName);
                    sqlComm.Parameters.AddWithValue("@TrailerPath", "/ImageVideoFiles/" + fileName);
                    fileName = Path.Combine(Server.MapPath("~/ImageVideoFiles/"), fileName);
                    sqlComm.ExecuteNonQuery();
                    sqlConn.Close();
                    ViewData["Message"] = "Record Saved Successfully !";
                }
            }
            return RedirectToAction("Index");
        }
    }
}