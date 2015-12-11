using Car4U.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car4U.CarModels
{
    public class CarModel
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public virtual Brand brand { get; set; }

        
    }
}