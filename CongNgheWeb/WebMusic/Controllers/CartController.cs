using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class CartController : Controller
    {

        MusicEntities db = new MusicEntities();

        // GET: Cart

        public List<Cart> GetCart()
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart == null)
            {
                //If cart is not exist, we will create new cart(giohang)
                lstCart = new List<Cart>();
                Session["Cart"] = lstCart;
                Session["TotalMoney"] = 0;
            }
            return lstCart;
        }

        [HttpPost]
        public ActionResult Add(PostTrackRemix product)
        {

            List<Cart> lstGioHang = GetCart();
            List<string> returnString = new List<string>();

            Cart temp = lstGioHang.Find(x => (x.id == product.id) && (x.type == product.type));
            USER user = Session["User"] as USER;
            USER_TRACKLIST temp1 = db.USER_TRACKLIST.Where(p => p.ID_USER == user.ID && p.ID_PROD == product.id && p.TYPE == product.type).FirstOrDefault();
            if (temp == null && temp1 == null)
            {
                double totalDebtNearDay = Convert.ToDouble(Session["totalDebtNearDay"].ToString()) + Convert.ToDouble(Session["TotalMoney"].ToString());
                Byte saleValue = Convert.ToByte(Session["sale"].ToString());

                temp = new Cart();
                if (product.type == 1)
                {
                    TRACK tempTrack = db.TRACKs.Where(x => x.ID == product.id).FirstOrDefault();
                    if (tempTrack != null)
                    {
                        temp.id = tempTrack.ID;
                        temp.type = 1;
                        temp.name = tempTrack.NAME;
                        temp.fullName = tempTrack.FULL_NAME;

                        temp.sale = saleValue;
                        if (tempTrack.COST != null)
                        {
                            temp.cost = (double)tempTrack.COST;
                            temp.cost = temp.cost * (100 - temp.sale) / 100;
                        }

                    }
                    temp.artist = db.TRACK_ARTIST.Where(p => p.ID_TRACK == product.id).Select(p => p.NAME_ARTIST).ToList();
                    temp.label = db.TRACK_ARTIST.Where(p => p.ID_TRACK == product.id).Select(p => p.NAME_LABEL).ToList();
                }
                else if (product.type == 2)
                {
                    REMIX tempTrack = db.REMIXes.Where(x => x.ID == product.id).FirstOrDefault();
                    if (tempTrack != null)
                    {
                        temp.id = tempTrack.ID;
                        temp.type = 2;
                        temp.name = tempTrack.NAME;
                        temp.sale = saleValue;
                        if (tempTrack.COST != null)
                        {
                            temp.cost = (double)tempTrack.COST;
                            temp.cost = temp.cost * (100 - temp.sale) / 100;
                        }
                    }
                    temp.artist = db.REMIX_ARTIST.Where(p => p.ID_REMIX == product.id).Select(p => p.NAME_ARTIST).ToList();
                    temp.label = db.REMIX_ARTIST.Where(p => p.ID_REMIX == product.id).Select(p => p.NAME_LABEL).ToList();
                }
                lstGioHang.Add(temp);
                Session["Cart"] = lstGioHang;
                double TotalMoney = Convert.ToDouble(Session["TotalMoney"].ToString()) + temp.cost;
                Session["TotalMoney"] = TotalMoney;
                TotalMoney = Math.Round(TotalMoney, 2);
                returnString.Add(TotalMoney.ToString());

                totalDebtNearDay += temp.cost;
                List<SALE> sale = (List<SALE>)Session["ListSale"];
                //tinh toan chi so giam gia
                foreach (var item in sale)
                {
                    if (totalDebtNearDay >= item.CONDITION.Value)
                    {
                        saleValue = (byte)item.SALE_INDEX;
                    }
                }
                Session["sale"] = saleValue;

                returnString.Add(saleValue.ToString());
                return Json(returnString, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult userCart()
        {

            if (Session["User"] == null)
            {
                ViewBag.UserName = null;
                return PartialView();
            }

            List<Cart> lstCart = new List<Cart>();
            lstCart = GetCart();
            USER user = Session["User"] as USER;
            double totalDebt = Convert.ToDouble(Session["TotalMoney"].ToString());

            totalDebt = Math.Round(totalDebt, 2);
            ViewBag.TotalDebt = totalDebt;
            ViewBag.UserName = user.FIRSTNAME + " " + user.LASTNAME;
            return PartialView();
        }

        public JsonResult CartDetail()
        {
            if (Session["Cart"] == null)
            {
                return Json(null);
            }
            var lstGioHang = GetCart();
            StringBuilder sb = new StringBuilder();
            if (lstGioHang.Count > 0)
            {
                sb.Append("<div class='container'>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col-sm-12'>");
                sb.Append("<h1 id='detail-username' >vu hoang ha</h1>");
                sb.Append("<br/>");
                sb.Append("<div class='row'>");
                sb.Append("<div class='col-sm-4 header'>Name</div>");
                sb.Append("<div class='col-sm-3 header'>Artist</div>");
                sb.Append("<div class='col-sm-3 header'>Label</div>");
                sb.Append("<div class='col-sm-1 header'>Cost</div>");
                sb.Append("<div class='col-sm-1 header'>Delete</div>");
                sb.Append("</div>");

                int count = 0;
                foreach (var item in lstGioHang)
                {
                    sb.Append("<div class='row' count=" + count + " >");
                    sb.Append("<div class='col-sm-4 cart-row cart-name'>");
                    sb.Append("<a href='#' >" + item.name + "</a>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-3 cart-row cart-artist'>");

                    for (int i = 0; i < item.artist.Count; i++)
                    {
                        sb.Append("<a href='#'>" + item.artist[i] + "</a>");
                        if (i != item.artist.Count - 1)
                        {
                            sb.Append("<span> ft </span>");
                        }
                    }
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-3 cart-row cart-label'>");
                    for (int i = 0; i < item.label.Count; i++)
                    {
                        sb.Append("<a href='#'>" + item.label[i] + "</a>");
                        if (i != item.label.Count - 1)
                        {
                            sb.Append("<span> ft </span>");
                        }
                    }
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-1 cart-row cart-cost'>$" + Math.Round(item.cost, 2) + "</div>");
                    sb.Append("<div class='col-sm-1 cart-row cart-delete'>");
                    sb.Append("<a href='#' onclick='cartDelete_fun(" + item.id + "," + item.type + "," + count.ToString() + ")' > Delete </a>");
                    sb.Append("</div>");
                    sb.Append("</div>");

                    count++;
                }

                sb.Append("<div class='row'>");
                sb.Append("<div class='col-sm-1 col-sm-offset-10' id='TotalMoney'>$" + Math.Round(Convert.ToDouble(Session["TotalMoney"].ToString()), 2) + "</div>");
                sb.Append("<div class='col-sm-1' id='Buy-now' onclick='BuyNow_fun()' style='cursor: pointer;'>Buy Now");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                sb.Append("<div class='col-sm-12' id='content-wrap' style='display: none;'>");
                sb.Append("<div class='col-sm-6 col-sm-offset-4' id='CommitBuy'>");
                sb.Append("<input type='text' placeholder='Email' class='form-element' id='cart-pay-email' />");
                sb.Append("<input type='password' placeholder='Password' class='form-element' id='cart-pay-password' />");
                sb.Append("<input type='text' placeholder='Cart Number' class='form-element' id='cart-pay-series' />");
                sb.Append("<input type='password' placeholder='Cart Password' class='form-element' id='cart-pay-pass' />");
                sb.Append("<div class='login-form-button-group'>");
                sb.Append("<button id='button-cart-pay' onclick='CommitPay()' class='button-me'>Pay</button>");
                sb.Append("</div>");
                sb.Append("</div>");
                sb.Append("</div>");

                sb.Append("</div>");
                sb.Append("</div>");

                return Json(sb.ToString());
            }

            return Json("");
        }


        public JsonResult CartBuy(Pay pay)
        {
            List<Cart> lstCart = Session["Cart"] as List<Cart>;
            if (lstCart.Count == 0)
            {
                return Json("0");
            }
            USER tempUser = db.USERs.FirstOrDefault(p => p.EMAIL == pay.email && p.PASSWORD == pay.password);
            CARD tempCard = db.CARDs.FirstOrDefault(p => p.NUMBER == pay.cardNumber && p.PASSWORD == pay.passwordCard);
            if (tempUser != null && tempCard != null)
            {
                byte countPro = (byte)lstCart.Count;
                var tempHis = db.HISTORY_USER.Where(p => p.ID_USER == tempUser.ID).ToList();
                HISTORY_USER lastHist = new HISTORY_USER();

                if (tempHis.Count > 0)
                {
                    lastHist = tempHis.Where(p => p.RANK == 1).FirstOrDefault();
                    foreach (var item in tempHis)
                    {
                        item.RANK += countPro;
                    }
                    db.SaveChanges();
                }

                byte j = 1;
                for (int i = lstCart.Count - 1; i >= 0; i--)
                {
                    //ADD TO HISTORY USER
                    HISTORY_USER temp = new HISTORY_USER();
                    temp.ID_USER = tempUser.ID;
                    temp.TIME = DateTime.Now;
                    temp.ID_TRACK = lstCart[i].id;
                    temp.TYPE = (byte)lstCart[i].type;
                    temp.COST = lstCart[i].cost;
                    temp.RANK = j;
                    j++;
                    if (i != 0)
                    {
                        temp.DISTANCE_NEAR = 0;
                    }
                    else
                    {
                        if (lastHist.ID_USER > 0)
                        {
                            temp.DISTANCE_NEAR = Convert.ToInt16((DateTime.Now - lastHist.TIME).TotalDays - 1);
                        }
                        else
                        {
                            temp.DISTANCE_NEAR = Int16.MaxValue;
                        }
                    }
                    db.HISTORY_USER.Add(temp);
                    db.SaveChanges();

                    //ADD TO TRACKLIST USER
                    USER_TRACKLIST tempTracklist = new USER_TRACKLIST();
                    tempTracklist.ID_USER = tempUser.ID;
                    tempTracklist.ID_PROD = lstCart[i].id;
                    tempTracklist.NAME = lstCart[i].fullName;
                    tempTracklist.TYPE = (byte)lstCart[i].type;
                    db.USER_TRACKLIST.Add(tempTracklist);
                    db.SaveChanges();

                    //ADD TO STATISTIC BUY
                    if (lstCart[i].type == 1)
                    {
                        var statisticTrack = db.STATISTIC_TRACK.FirstOrDefault(p => p.ID == lstCart[i].id);
                        statisticTrack.BUY_MONTH++;
                        statisticTrack.BUY_ALL++;
                        db.SaveChanges();
                    }else if (lstCart[i].type == 2)
                    {
                        var statisticRemix = db.STATISTIC_REMIX.FirstOrDefault(p => p.ID == lstCart[i].id);
                        statisticRemix.BUY_MONTH++;
                        statisticRemix.BUY_ALL++;
                        db.SaveChanges();
                    }
                }

                Session["Cart"] = null;
                Session["TotalMoney"] = 0;
                return Json("1");

            }
            return Json("0");
        }

        public ActionResult CartDelete(int id, int type)
        {
            List<Cart> lstGioHang = GetCart();
            Cart delete = lstGioHang.Find(p => p.id == id && p.type == type);
            if (delete != null)
            {
                lstGioHang.Remove(delete);
                Session["Cart"] = lstGioHang;
                double totalMoney = Convert.ToDouble(Session["TotalMoney"].ToString()) - delete.cost;
                Session["TotalMoney"] = totalMoney;
                double totalDebtNearDay = Convert.ToDouble(Session["totalDebtNearDay"].ToString()) - delete.cost;

                totalDebtNearDay += totalMoney;
                totalMoney = Math.Round(totalMoney, 2);
                List<SALE> sale = (List<SALE>)Session["ListSale"];
                byte saleValue = 0;
                //tinh toan chi so giam gia
                foreach (var item in sale)
                {
                    if (totalDebtNearDay >= item.CONDITION.Value)
                    {
                        saleValue = (byte)item.SALE_INDEX;
                    }
                }
                Session["sale"] = saleValue;

                var temp = new { totalMoney = totalMoney, sale = saleValue };

                return Json(temp, JsonRequestBehavior.AllowGet);
            }

            return Json("");
        }
    }
}