using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeltaXMVC.Models
{
    public class Movie
    {
        public string MovieId { get; set; }
        public string MovieName { get; set; }
        public Nullable<short> YearOfRelease { get; set; }
        public string Plot { get; set; }
        public byte[] Poster { get; set; }
        public string ProducerID { get; set; }
    }
}