using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspWebApi_Crud.Models
{
    public class ModelClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Designation { get; set; }
        public int? Salary { get; set; }
    }
}