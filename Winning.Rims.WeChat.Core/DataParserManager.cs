using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Core
{

    /// <summary>
    /// 数据转换
    /// </summary>
    public class DataParserManager
    {
        /// <summary>
        /// 实体转成json
        /// </summary>
        /// <param name="obj">待转实体</param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            return Dos.Common.JSON.ToJSON(obj);
        }
        /// <summary>
        /// json转成实体
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToObject(string obj)
        {
            return Dos.Common.JSON.ToObject(obj);
        }
        /// <summary>
        /// 按类型将json转成实体
        /// </summary>
        /// <typeparam name="T">待转类型</typeparam>
        /// <param name="obj">待转obj</param>
        /// <returns></returns>
        public static T ToObject<T>(string obj)
        {
            return Dos.Common.JSON.ToObject<T>(obj);
        }
        /// <summary>
        /// 按类型将data转成DbParamterc参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="dbtype"></param>
        /// <returns></returns>
        public static DbParameter[] ToDbParameters<T>(T data, DatabaseType dbtype)
        {
            if (data == null)
                return null;
            PropertyInfo[] properties = data.GetType().GetProperties();
            if (properties == null || properties.Length <= 0)
                return null;
            List<DbParameter> parameters = new List<DbParameter>();
            foreach (PropertyInfo info in properties)
            {
                string name = info.Name;
                object value = info.GetValue(data, null);
                Type propertyType = info.PropertyType;
                switch (dbtype)
                {
                    case DatabaseType.SqlServer:
                        parameters.Add(new SqlParameter(name, value));
                        break;
                    case DatabaseType.MsAccess:
                        break;
                    case DatabaseType.SqlServer9:
                        break;
                    case DatabaseType.Oracle:
                        break;
                    case DatabaseType.Sqlite3:
                        break;
                    case DatabaseType.MySql:
                        break;
                    default:
                        break;
                }               
            }
            return parameters.ToArray();
        }
    }
}
