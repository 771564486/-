using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EF;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Messaging;

namespace DAO
{
   public class BaseDao<T> where T: class
    {
        public static MyDbContext CreateContext()
        {
            MyDbContext db = CallContext.GetData("s") as MyDbContext;
            if (db == null)
            {
                db = new MyDbContext();
                CallContext.SetData("s", db);
            }
            return db;
        }
        public void FenLi(T t)
        {
            //1 创建ObjectDbContext对象
            MyDbContext db = CreateContext();
            var ObjContext = ((IObjectContextAdapter)db).ObjectContext;

            //2 创建新的 ObjectSet< TEntity > 实例
            var objSet = ObjContext.CreateObjectSet<T>();
            //3 为特定对象创建实体键，如果实体键已存在，则返回该键。
            var objKey = ObjContext.CreateEntityKey(objSet.EntitySet.Name, t);
            //4 返回具有指定实体键的对象。
            object objT;
            var ext = ObjContext.TryGetObjectByKey(objKey, out objT);
            //5 从对象上下文移除对象。
            if (ext)
            {

                ObjContext.Detach(objT);
            }
        }    
       public int Insertbase(T t)
       {
            MyDbContext md = CreateContext();
            FenLi(t);
            md.Set<T>().Add(t);
           return md.SaveChanges();
       }
       public int Updatebase(T t)
       {
            MyDbContext md = CreateContext();
            FenLi(t);
            md.Set<T>().Attach(t);
           md.Entry<T>(t).State = EntityState.Modified;
           return md.SaveChanges();
       }
       public int Deletebase(T t)
       {
            MyDbContext md = CreateContext();
            FenLi(t);
            md.Set<T>().Attach(t);
           md.Entry<T>(t).State = EntityState.Deleted;
           return md.SaveChanges();
       }
       public List<T> SelectAllbase()
       {
            MyDbContext md = CreateContext();
            md.Database.Log = (sql) =>
            {
                Console.WriteLine(sql);
            };
            return md.Set<T>().AsNoTracking().Select(e=>e).ToList<T>();
       }
       //public List<T> SelectOnebase(Expression<Func<T, bool>> where)
       //{
       //    return md.Set<T>().AsNoTracking().Select(e => e).Where(where).ToList<T>();
       //}
       //public List<T> SelectFenyebase<K>(Expression<Func<T, K>> order, Expression<Func<T, bool>> where, int PageIndex, int PageSize, out int rows)
       //{
       //     var Result= md.Set<T>().Select(e => e).AsNoTracking().OrderBy(order);
       //     rows = Result.Count();
       //     return Result.Select(e => e).Where(where).Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList<T>();
       //}

    }
}
