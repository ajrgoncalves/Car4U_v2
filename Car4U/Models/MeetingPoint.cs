﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Car4U.Models
{
    public class MeetingPoint
    {
        public string ID { get; set; }
        //Mudar o nome de Place.
        public string Place { get; set; }
        //ver maneiras de ligar duas colunas a esta 
        //public virtual ICollection<Reservation> IdReservations { get; set; }
    }
}