using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestaurantJISH_phase31.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantJISH_phase31.Models;
namespace RestaurantJISH_phase31.Controllers
{
    public class IndividualController : Controller
    {
        // GET: Individual
        [Authorize]
        public ActionResult checkout()
        {




            return View();
        }
        public ActionResult order(string RecieverName, string address, string phonenumber, string PostCode)
        {

            var userID = User.Identity.GetUserId();
            using (RestaurantContext db = new RestaurantContext())
            {
                order order = new order();
                order.userId = userID;
                order.Name = Request.QueryString["RecieverName"];
                order.Phone = Request.QueryString["phonenumber"];
                order.PostalCode = Request.QueryString["PostCode"];
                order.OrderDate = DateTime.Now;
                order.Address = Request.QueryString["address"];
                db.orders.Add(order);
                db.SaveChanges();
                int orderid = db.orders.Max(x => x.OrderId);
                foreach (Item item in (List<Item>)Session["Cart"])
                {
                    OrderItem neworderitem = new OrderItem();
                    neworderitem.OrderId = orderid;
                    neworderitem.FoodName = item.product.foodName;
                    neworderitem.RestaurantName = item.restaurant.Name;
                    neworderitem.Price = Convert.ToDouble(item.product.price);
                    neworderitem.quantity = Convert.ToInt32(item.quantity);
                    db.OrderItems.Add(neworderitem);
                    db.SaveChanges();
                }
                Session["cart"] = null;
                Session["quantity"] = null;
                ViewBag.orderinfo = "paid sucessfully!!!";

                return View("order");
            }
        }
        public ActionResult vieworders()
        {

            var userID = User.Identity.GetUserId();
            RestaurantContext db = new RestaurantContext();

            var model = from x in db.orders
                        join b in db.OrderItems on x.OrderId equals b.OrderId
                        where x.userId == userID
                        select new vieworder
                        {
                            order = x,
                            OrderItem = b
                        };


            return View(model);
        }
        public ActionResult detail(int? ordernumber)
        {
            var userID = User.Identity.GetUserId();
            RestaurantContext db = new RestaurantContext();

            var model = from x in db.orders
                        join b in db.OrderItems on x.OrderId equals b.OrderId
                        where x.userId == userID && b.OrderId == ordernumber
                        select new vieworder
                        {
                            order = x,
                            OrderItem = b
                        };

            ViewBag.orderId = ordernumber;
            return View(model);
        }
    }
}
