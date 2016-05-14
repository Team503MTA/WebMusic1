using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMusic.Models;

namespace WebMusic.Controllers
{
    public class UserController : Controller
    {

        MusicEntities db = new MusicEntities();

        public JsonResult Register(USER us)
        {

            db.USERs.Add(us);
            db.SaveChanges();

            return Json("true");
        }

        public JsonResult Login(UserLogin userTemp)
        {
            USER user = db.USERs.Where(x => x.EMAIL == userTemp.email && x.PASSWORD == userTemp.password).FirstOrDefault();
            if (user != null)
            {

                //read SALES USER
                List<SALE> sale = db.SALEs.OrderBy(p=>p.LEVEL_).ToList();
                Session["ListSale"] = sale;
                Session["sale"] = 0;
                Session["TimeLogin"] = DateTime.Now.Date;
                Session["User"] = user;
                Session["totalDebtNearDay"] = 0;
                Session["TotalMoney"] = 0;

                //read PlayList
                Session["PlayList"] = Session["PlaylistRight"] = db.USER_TRACKLIST.Where(p => p.ID_USER == user.ID).ToList();

                List<HISTORY_USER> hisUser = db.HISTORY_USER.Where(p => p.ID_USER == user.ID).OrderBy(p=>p.RANK).ToList();
                if (hisUser.Count > 0)
                {
                    //set value to temp and set distance_near for item laster is max value int16
                    int temp = 29;
                    temp = temp - Convert.ToInt16((DateTime.Now.Date - hisUser[0].TIME).TotalDays);
                    if (temp < 0)
                    {
                        db.HISTORY_USER.RemoveRange(db.HISTORY_USER.Where(p => p.ID_USER == user.ID));
                        db.SaveChanges();
                        return Json(user.FIRSTNAME + ' ' + user.LASTNAME);
                    }

                    hisUser[hisUser.Count - 1].DISTANCE_NEAR = Int16.MaxValue;
                    //filter all history over 30 day
                    List<HISTORY_USER> lstTemp = new List<HISTORY_USER>();
                    bool check = true;
                    foreach (var item in hisUser)
                    {
                        if ((int)item.DISTANCE_NEAR < temp && check)
                        {
                            temp = temp - (int)item.DISTANCE_NEAR;
                        }else if ((int) item.DISTANCE_NEAR == temp && check)
                        {
                            temp = 0;
                        }
                        else if((int)item.DISTANCE_NEAR > temp && check)
                        {
                            check = false;
                        }
                        else
                        {
                            lstTemp.Add(item);
                        }
                    }
                    db.HISTORY_USER.RemoveRange(lstTemp);
                    db.SaveChanges();

                    //set session history user
                    hisUser.RemoveAll(i => lstTemp.Contains(i));
                    Session["HistoryUser"] = hisUser;
                    Session["surplus"] = temp;

                    //CACULATE SALE
                    double totalDebtNearDay = 0;
                    if (hisUser != null)
                    {
                        foreach (var item in hisUser)
                        {
                            totalDebtNearDay += (double)item.COST;
                        }
                        Session["totalDebtNearDay"] = totalDebtNearDay;
                        foreach (var item in sale)
                        {
                            if (totalDebtNearDay >= item.CONDITION.Value)
                            {
                                Session["sale"] = item.SALE_INDEX;
                            }
                        }
                    }

                }
                return Json(user.FIRSTNAME + ' ' + user.LASTNAME);  //dang nhap thanh cong
            }
            return Json("");  //dang nhap khong thanh cong
        }

        public JsonResult checkEmail(string email)
        {
            var temp = db.USERs.Where(p => p.EMAIL == email).FirstOrDefault();
            if (temp != null)
            {
                return Json("0");
            }
            return Json("1");
        }

        public JsonResult userDetail()
        {
            USER user = Session["User"] as USER;
            return Json("fd");
        }
    }
}