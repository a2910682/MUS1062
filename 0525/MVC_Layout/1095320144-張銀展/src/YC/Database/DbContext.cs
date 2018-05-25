using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Database
{
    public class OpenData_DbContext : System.Data.Entity.DbContext
    {
        static OpenData_DbContext()
        {
            //DbInit dbinit = new DbInit();
            //System.Data.Entity.Database.SetInitializer(dbinit);

        }
        public OpenData_DbContext()
            :base("OpenData")
        {
            


        }
        public System.Data.Entity.IDbSet<YC.Models.OpenData> OpenDatas { get; set; }
    }

    public class DbInit : System.Data.Entity.CreateDatabaseIfNotExists<OpenData_DbContext>
    {



        public override void InitializeDatabase(OpenData_DbContext context)
        {

            base.InitializeDatabase(context);
            var _rep = new YC.Repository.OpenDataRepository();

            _rep.FindFromOpenData()
                .OfType<Models.OpenData>()
                .ToList().ForEach(x =>
            {
                context.OpenDatas.Add(x);
            });
            context.SaveChanges();

        }
    }
}
