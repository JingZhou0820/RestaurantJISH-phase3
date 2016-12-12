using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantJISH_phase31.Models
{ //create new class that handel the category list,restaurant name, and menu list
    public class menuDetailmodel
    {


        public List<Category> navBarList { get; set; }
        public string restuarantName { get; set; }
        public PagedList.IPagedList<joinModel> detailMenu { get; set; }
        public Restaurant restuarantInformation { get; set; }

    }
}