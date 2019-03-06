using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMUViews.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string ImagePath { get; set; }
        public string TrailerPath { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }
        public System.DateTime DateReleased { get; set; }
          
    }


}