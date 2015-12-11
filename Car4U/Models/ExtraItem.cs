using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car4U.Models
{
    public class ExtraItem
    {
        public string ID { get; set; }
        public virtual ICollection<Reservation> IdReservations { get; set; }
        public virtual ExtraModel IdModel { get; set; }
    }
}