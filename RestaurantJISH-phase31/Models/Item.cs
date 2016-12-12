using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestaurantJISH_phase31.Models;
namespace RestaurantJISH_phase31.Models
{


    public class Item
    {
        RestaurantContext db = new RestaurantContext();
        public menu product = new menu();
        public Restaurant restaurant = new Restaurant();
        public int quantity;
        public Item() { }
        public Item(menu product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
            Category category = db.Categories.Where(x => x.CategoryId.Equals(this.product.CategoryId)).FirstOrDefault();
            int restaurantId = category.RestaurantId;
            this.restaurant = db.Restaurants.Where(x => x.RestaurantId.Equals(restaurantId)).FirstOrDefault();
        }
    }
}