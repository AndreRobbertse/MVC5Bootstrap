using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Bootstrap.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Created { get; set; }
    }
}