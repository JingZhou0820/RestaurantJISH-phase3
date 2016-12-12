using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantJISH_phase31.Models;
namespace RestaurantJISH_phase31.Controllers
{
    public class ShoppingCartController : Controller
    {
        private RestaurantContext db = new RestaurantContext();
        // GET: ShoppingCart
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.foodId == id)
                    return i;
            return -1;
        }
        public ActionResult Cart()
        {
            return View("Cart");

        }
        int s = 0;
        public ActionResult orderNow(int id)
        {

            if (Session["Cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.menus.Find(id), 1));
                Session["Cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["Cart"];
                int index = isExisting(id);
                if (index == -1)
                {
                    cart.Add(new Item(db.menus.Find(id), 1));
                }
                else
                {
                    cart[index].quantity++;
                }
            }

            foreach (Item item in (List<Item>)Session["Cart"])
            {
                s = s + item.quantity;
                Session["quantity"] = s;
            }


            return PartialView("_cartnumber");
        }
        public ActionResult Delete(int id)
        {

            if (Session["Cart"] != null)
            {
                foreach (Item item in (List<Item>)Session["Cart"])
                {
                    s = s + item.quantity;
                }
                foreach (Item item in (List<Item>)Session["Cart"])
                {
                    if (item.product.foodId == id)
                    {
                        s = s - item.quantity;
                    }

                }
                Session["quantity"] = s;
                //return PartialView("_cartnumber");

                int index = isExisting(id);
                List<Item> cart = (List<Item>)Session["cart"];
                cart.RemoveAt(index);
                Session["cart"] = cart;

            }
            return View("cart");
        }

    }

}