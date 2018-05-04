using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YC.Repository
{
    public class StationRepository : IRepository
    {
        public string XmlPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ConnectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(object item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string ID)
        {
            throw new NotImplementedException();
        }

        public List<object> FindFromOpenData()
        {
            throw new NotImplementedException();
        }

        public List<object> FindFromDB()
        {
            throw new NotImplementedException();
        }

        public object Update(object item)
        {
            throw new NotImplementedException();
        }
    }
}
