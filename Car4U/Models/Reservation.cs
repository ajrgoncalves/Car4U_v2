using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car4U.Models
{
    public class Reservation
    {
        public string ID { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double FinalPrice { get; set; }
        public virtual MeetingPoint MPDelivery { get; set; }
        public virtual MeetingPoint MPReturn { get; set; }
        public virtual ICollection<ExtraItem> Extras { get; set; }
        public virtual MomentDelivery MomentDelivery { get; set; }
        public virtual MomentReturn MomentReturn { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser user { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}