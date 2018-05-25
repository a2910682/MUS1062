using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace YC.Repository
{
    public class OpenDataRepository : IRepository
    {
        public string XmlPath
        {
            get
            {
                return YC.Shared.Utils.GetDataPath() + @"opendata.xml";
            }
            set => throw new NotImplementedException();
        }
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + YC.Shared.Utils.GetDataPath() + @"OpenData.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }
            set => throw new NotImplementedException();
        }
        private string getValue(XElement node, string propertyName)
        {
            return node.Element(propertyName)?.Value.Trim();

        }
        public void Create(object item)
        {
            var newItem = item as YC.Models.OpenData;
            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData(ID, 資料集名稱, 服務分類, 資料集描述, DisplaySqe,下載連結)
            VALUES              ('{0}',N'{1}',N'{2}',N'{3}','{4}',N'{5}')
            ", newItem.ID, newItem.資料集名稱, newItem.服務分類, newItem.資料集描述, newItem.ID,newItem.下載連結);

            command.ExecuteNonQuery();


            connection.Close();
        }

        public List<Object> FindFromOpenData()
        {
            List<YC.Models.OpenData> nodeList = new List<YC.Models.OpenData>();



            var xml = XElement.Load(XmlPath);
            var nodes = xml.Descendants("node").ToList();

            nodeList = nodes
                .Where(x => !x.IsEmpty).ToList()
                .Select(node =>
                {
                    YC.Models.OpenData item = new YC.Models.OpenData();
                    item.ID = getValue(node, "id");
                    item.資料集名稱 = getValue(node, "資料集名稱");
                    item.服務分類 = getValue(node, "服務分類");
                    item.資料集描述 = getValue(node, "資料集描述");
                    item.下載連結 = getValue(node, "下載連結");
                    return item;

                }).ToList();
            return nodeList.OfType<Object>().ToList();
        }

        public List<object> FindFromDB()
        {
            List<YC.Models.OpenData> result = new List<Models.OpenData>();
            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
SELECT  *
  FROM [dbo].[OpenData]
");

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var item = new YC.Models.OpenData();

                item.ID = reader["ID"].ToString();
                item.服務分類 = reader["服務分類"].ToString();
                item.資料集名稱 = reader["資料集名稱"].ToString();
                item.資料集描述 = reader["資料集描述"].ToString();
                item.DisplaySqe = int.Parse(reader["DisplaySqe"].ToString());
                item.下載連結 = reader["下載連結"].ToString();
                result.Add(item);
            }
            connection.Close();
            return result.OfType<Object>().ToList();

        }

        public object Update(object item)
        {
            var updateItem = item as YC.Models.OpenData;
            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
UPDATE [OpenData]
   SET 
      [資料集名稱] = N'{0}'
      ,[服務分類] = N'{1}'
      ,[資料集描述] = N'{2}'
      ,[DisplaySqe] = N'{3}'
      ,[下載連結] = N'{5}'
 WHERE ID=N'{4}'
            ", updateItem.服務分類, updateItem.資料集名稱, updateItem.資料集描述, updateItem.DisplaySqe, updateItem.ID,updateItem.下載連結);

            command.ExecuteNonQuery();

            
            connection.Close();
            return item;
        }

        public void Delete(string ID)
        {
            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
DELETE FROM [OpenData]
 WHERE ID=N'{0}'
            ", ID);

            command.ExecuteNonQuery();


            connection.Close();
        }
    }
}
