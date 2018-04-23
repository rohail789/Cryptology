using Cryptology.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services.Description;

namespace Cryptology.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private CryptologyDbContext db = new CryptologyDbContext();
        public ActionResult Index()
        { 
            return View(db.Currencies.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();

        }
        [Authorize(Roles = "Admin") ]
        public ActionResult Aik()
        {
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://api.coinmarketcap.com/v1/ticker/");
                JArray jto = JArray.Parse(json);
                dynamic res = from result in jto
                          select result;
                //if (!Directory.Exists(Server.MapPath("~/JsonData")))
                //{
                //    Directory.CreateDirectory(Server.MapPath("~/JsonData"));
                //    System.IO.File.WriteAllText(Server.MapPath("~/JsonData/InstagramData.json"), null);
                //}
                var context1 = new CryptologyDbContext();
                context1.Currencies.RemoveRange(context1.Currencies.Where(c => c.CId.Equals(c.CId)));
                context1.SaveChanges();
                foreach (var data in res)
                {
                    using(var context = new CryptologyDbContext())
                    {
                        var cur = new Currency();
                        cur.Cname = data["name"];
                        cur.Symbol = data["symbol"];
                        cur.Rank = data["rank"];
                        cur.Price_usd = data["price_usd"];
                        cur.Price_btc = data["price_btc"];
                        cur.C24h_volume_usd = data["24h_volume_usd"];
                        cur.Market_cap_usd = data["market_cap_usd"];
                        cur.Available_supply = data["available_supply"];
                        cur.Max_supply = data["max_supply"];
                        cur.Percent_change_7d = data["percent_change_7d"];
                        cur.Last_updated = data["last_updated"];
                        context.Currencies.Add(cur);
                        //var checkva = context.Currencies.Where(c => c.CId == 0);
                        //if(checkva != null)
                        //{
                        //    context.Entry(cur).State = System.Data.Entity.EntityState.Unchanged;
                        //}
                        //else
                        //{
                        //    context.Entry(cur).State = System.Data.Entity.EntityState.Modified;
                        //        //context.Currencies.Add(cur);
                        //}
                        context.SaveChanges();
                        
                    }
                }
                return RedirectToAction("Admin", "Admin");
            }
        }
    }
}