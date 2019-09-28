using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RLZYGL.Controllers
{
    public class SJKBController : Controller
    {
        // GET: SJKB
        ISJKBBLL ss = IocContainer.IocCreate.CreateBLL<ISJKBBLL>("containerTwo", "SJKBBLL");
        public ActionResult Index()
        {
            List<SJKBModel> li = ss.SelectAll();
            List<SelectListItem> li2 = new List<SelectListItem>();
            foreach(SJKBModel item in li)
            {
                SelectListItem uu = new SelectListItem()
                {
                    Text = item.SJKBname,
                    Value = item.SJKBid.ToString()
                };
                li2.Add(uu);
            }
            return View(li2);
        }
    }
}