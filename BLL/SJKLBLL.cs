using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAO;

namespace BLL
{
    public class SJKLBLL : ISJKLBLL
    {
        SJKLDAO ss = IocContainer.IocCreate.CreateDAO<SJKLDAO>("containerTwo", "SJKLBLL");
        public int Delete(SJKLModel t)
        {
            return ss.Delete(t);
        }

        public int Insert(SJKLModel t)
        {
            return ss.Insert(t);
        }

        public List<SJKLModel> select(SJKLModel uu)
        {
            return ss.select(uu);
        }

        public List<SJKLModel> SelectAll()
        {
            return ss.SelectAll();
        }

        public int Update(SJKLModel t)
        {
            return ss.Update(t);
        }
        public List<SJKLModel> select2(SJKLModel uu) {
            return ss.select2(uu);
        }
    }
}
