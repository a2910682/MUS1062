using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YC.Repository
{
    public interface IRepository
    {
        string XmlPath { get; set; }
        string ConnectionString { get; set; }
        List<Object> FindFromOpenData();
        void Create(Object item);
        List<Object> FindFromDB();
        Object Update(Object item);
        void Delete(string ID);
    }
}
