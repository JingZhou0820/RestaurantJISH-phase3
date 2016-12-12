using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantJISH_phase31.Models
{
    public class vieworder
    {
        public order order { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}