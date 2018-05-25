using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static YC.Repository.IRepository _rep;

        static void Main(string[] args)
        {
            //YC.Web.Controllers.HomeController hc = new YC.Web.Controllers.HomeController();
            //hc.Index();

            Console.ReadKey();


        }
        static void Display(List<YC.Models.OpenData> datas)
        {
            datas.ForEach(x =>
            {
                Console.WriteLine(x);
            });
            

        }






        



    }
}
