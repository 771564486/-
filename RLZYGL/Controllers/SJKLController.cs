using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RLZYGL.Controllers
{
    public class SJKLController : Controller
    {
        // GET: SJKL
        ISJKLBLL ss = IocContainer.IocCreate.CreateBLL<ISJKLBLL>("containerTwo", "SJKLBLL");
        public ActionResult Index(SJKLModel uu)
        {
            List<SJKLModel> li = ss.select(uu);
            return View("Index",li);
        }

        public ActionResult up(int Bid,string [] xuan)
        {
            SJKLModel uu = new SJKLModel()
            {
                Bid = Bid
            };
            List<SJKLModel> li = ss.select(uu);
            if (xuan != null)
            {
                
                foreach (SJKLModel item in li)
                {
                    foreach (string il in xuan)
                    {
                        if (item.SJKLname == il)
                        {
                            item.xuan = true;
                            ss.Update(item);
                            break;
                        }
                        else
                        {
                            item.xuan = false;
                            ss.Update(item);
                        }
                       
                    }
                }
            }
            else
            {
                foreach (SJKLModel item in li)
                {
                    item.xuan = false;
                    ss.Update(item);
                }
             }
        
                return Content("<script>location.href='/SJKB/Index';</script>");
          }
            //SJKLModel sj = new SJKLModel() { SJKLid=uu.SJKLid};
            //List<SJKLModel> list = ss.select2(sj);
            //list[0].xuan = uu.xuan;
            //if (ss.Update(list[0]) > 0)
            //{
            //    return Content("<script>alert('变更成功');location.href='/SJKB/Index';</script>");
            //}
            //else
            //{
            //    return Content("<script>alert('变更失败');location.href='/SJKB/Index';</script>");
            //}
    }
}