using Dos.Common;
using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winning.Rims.WeChat.Core
{
    public class SqlManager
    {
        /// <summary>
        /// 获取Datatable从Common库
        /// </summary>
        /// <param name="commandsql"></param>
        /// <returns></returns>
        public  DataTable GetCommonDataTable(string commandsql)
        {
            string dbstyle = ConfigHelper.GetAppSettings("CommonDbType");
            string connectstring = ConfigHelper.GetConnectionString("CommonDb");
            return GetDataTable(dbstyle, connectstring, commandsql);
        }
        /// <summary>
        /// 获取Datatable从Rims库
        /// </summary>
        /// <param name="commandsql"></param>
        /// <returns></returns>
        public  DataTable GetRimsDataTable(string commandsql)
        {
            string dbstyle = ConfigHelper.GetAppSettings("RimsDbType");
            string connectstring = ConfigHelper.GetConnectionString("RimsDb");
            return GetDataTable(dbstyle, connectstring, commandsql);
        }
        /// <summary>
        /// 获取Datatable从His库
        /// </summary>
        /// <param name="commandsql"></param>
        /// <returns></returns>
        public  DataTable GetHisDataTable(string commandsql)
        {
            string dbstyle = ConfigHelper.GetAppSettings("HisDbType");
            string connectstring = ConfigHelper.GetConnectionString("HisDb");
            return GetDataTable(dbstyle, connectstring, commandsql);
        }
        /// <summary>
        /// 获取Datatable从Common库
        /// </summary>
        /// <param name="commandsql"></param>
        /// <returns></returns>
        public  DataTable GetCommonDataTablebyProc<T>(string procname, T data)
        {
            string dbstyle = ConfigHelper.GetAppSettings("CommonDbType");
            string connectstring = ConfigHelper.GetConnectionString("CommonDb");
            System.Data.Common.DbParameter[] parameters = DataParserManager.ToDbParameters<T>(data, GetDbTyle(dbstyle));
            return GetDataTableByProc(dbstyle, connectstring, procname, parameters);
        }
        /// <summary>
        /// 获取Datatable从Rims库
        /// </summary>
        /// <param name="commandsql"></param>
        /// <returns></returns>
        public  DataTable GetRimsDataTablebyProc<T>(string procname, T data)
        {
            string dbstyle = ConfigHelper.GetAppSettings("RimsDbType");
            string connectstring = ConfigHelper.GetConnectionString("RimsDb");
            System.Data.Common.DbParameter[] parameters = DataParserManager.ToDbParameters<T>(data, GetDbTyle(dbstyle));
            return GetDataTableByProc(dbstyle, connectstring, procname, parameters);
        }
        /// <summary>
        /// 获取Datatable从His库
        /// </summary>
        /// <param name="commandsql"></param>
        /// <returns></returns>
        public  DataTable GetHisDataTablebyProc<T>(string procname, T data)
        {
            string dbstyle = ConfigHelper.GetAppSettings("HisDbType");
            string connectstring = ConfigHelper.GetConnectionString("HisDb");
            System.Data.Common.DbParameter[] parameters = DataParserManager.ToDbParameters<T>(data, GetDbTyle(dbstyle));
            return GetDataTableByProc(dbstyle, connectstring, procname, parameters);
        }
      
        public  DataTable GetDataTableByProc(string dbstyle, string connectstring, string procname, System.Data.Common.DbParameter[] parameters)
        {
            var db = new DbSession(GetDbTyle(dbstyle), connectstring);
            db.RegisterSqlLogger(LogHandler);
            DataTable dt = db.FromProc(procname).AddParameter(parameters).ToDataTable();
            db.UnregisterSqlLogger(LogHandler);
            return dt;
        }
        public  void LogHandler(string logMsg)
        {
            LogManager.Info(logMsg);
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="dbstyle">0:sqlsever 1:Access 2:sqlserver9 3:Oracle 4:sqllite 5:mysql</param>
        /// <param name="connectstring">数据库链接字符串</param>
        /// <param name="commandsql">执行sql脚本</param>
        /// <returns></returns>
        public  DataTable GetDataTable(string dbstyle, string connectstring, string commandsql)
        {
            DataSet ds = GetDataSet(dbstyle, connectstring, commandsql);
            DataTable dt = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        /// <summary>
        /// 获取DataSet
        /// </summary>
        /// <param name="dbstyle">0:sqlsever 1:Access 2:sqlserver9 3:Oracle 4:sqllite 5:mysql</param>
        /// <param name="connectstring">数据库链接字符串</param>
        /// <param name="commandsql">执行sql脚本</param>
        /// <returns></returns>
        public  DataSet GetDataSet(string dbstyle, string connectstring, string commandsql)
        {
            var db = new DbSession(GetDbTyle(dbstyle), connectstring);
            return db.FromSql(commandsql).ToDataSet();
        }
        public  DatabaseType GetDbTyle(string dbstyle)
        {
            DatabaseType dbt = DatabaseType.SqlServer;
            if (dbstyle == "1")
            {
                dbt = DatabaseType.MsAccess;
            }
            else if (dbstyle == "2")
            {
                dbt = DatabaseType.SqlServer9;
            }
            else if (dbstyle == "3")
            {
                dbt = DatabaseType.Oracle;
            }
            else if (dbstyle == "4")
            {
                dbt = DatabaseType.Sqlite3;
            }
            else if (dbstyle == "5")
            {
                dbt = DatabaseType.MySql;
            }
            return dbt;
        }
        public  int ExecuteNoneQuery(string dbstyle, string connectstring, string commandsql)
        {
            var db = new DbSession(GetDbTyle(dbstyle), connectstring);
            return db.FromSql(commandsql).ExecuteNonQuery();
        }
    }
}
