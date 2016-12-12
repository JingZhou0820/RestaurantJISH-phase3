using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantJISH_phase31.Models
{
    //join 2 table for category and menu
    public class joinModel

    {
        public Category category { get; set; }
        public menu menu { get; set; }
    }
}