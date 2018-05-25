using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Models
{
    public class OpenData:IEqualityComparer<OpenData>
    {
        public string ID { get; set; }
        public string 資料集名稱 { get; set; }
        public string 服務分類 { get; set; }
        public string 資料集描述 { get; set; }
        public string 下載連結 { get; set; }
        public int DisplaySqe { get; set; }

        public bool Equals(OpenData x, OpenData y)
        {
            return x.ID == y.ID;
        }

        public int GetHashCode(OpenData obj)
        {
            return obj.ID.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("分類:{0},名稱:{1}", this.服務分類, this.資料集名稱, this.資料集描述);
        }
    }
}
