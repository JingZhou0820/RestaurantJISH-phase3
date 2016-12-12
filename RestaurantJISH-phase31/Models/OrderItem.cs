namespace RestaurantJISH_phase31.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItem
    {
        public int OrderItemId { get; set; }

        public int? OrderId { get; set; }

        public string RestaurantName { get; set; }

        public string FoodName { get; set; }

        public double? Price { get; set; }

        public int? quantity { get; set; }

        public virtual order order { get; set; }
    }
}
