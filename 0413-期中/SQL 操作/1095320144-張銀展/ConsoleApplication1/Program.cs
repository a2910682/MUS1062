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
            var t = YC.Shared.Utils.GetDataPath();

            
            //組員1
            _rep = new YC.Repository.OpenDataRepository();

            var datas = _rep.FindFromOpenData().OfType<YC.Models.OpenData>().ToList();



            Console.WriteLine(string.Format("新增{0}筆OpenData:開始", datas.Count));
            datas.ForEach(x =>
            {
                _rep.Create(x);
            });
            Console.WriteLine(string.Format("新增OpenData:結束"));

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
