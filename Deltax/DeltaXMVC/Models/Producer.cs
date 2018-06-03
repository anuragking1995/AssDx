using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeltaXMVC.Models
{
    public class Producer
    {
        public string ProducerName { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Bio { get; set; }
    }
}