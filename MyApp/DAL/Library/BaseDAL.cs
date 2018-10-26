using CommonLib.Library;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static CommonLib.Library.AppSettings;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using static CommonLib.CustomAttributes;

namespace DAL.Library
{
    public class BaseDAL
    {   
        /// <summary>
        /// Method to create connection string 
        /// </summary>
        /// <returns></returns>
        protected async Task<SqlConnection> CreateConnectionAsync()
        {
            SqlConnection conn = new SqlConnection(AppSettings.MainDBConnectionString);
            if (conn.State != ConnectionState.Open)
            {
                await conn.OpenAsync();
            }
            return conn;
        }

        /// <summary>
        /// Method used for dapper parameter for database(Stored procedures, functions etc.)
        /// </summary>
        /// <param name="param"></param>
        /// <param name="request"></param>
        protected void AutoGenerateInputParams(DynamicParameters param, object request)
        {        
            foreach (PropertyInfo prop in request.GetType().GetProperties())
            {
                string name = prop.Name;
                SQLParam atSql = (SQLParam)prop.GetCustomAttribute<SQLParam>();

                if (atSql != null)
                {
                    if (atSql.Usage.HasFlag(SQLParamPlaces.None))
                        continue;

                    if (!atSql.Usage.HasFlag(SQLParamPlaces.Writer))
                        continue;

                    name = string.IsNullOrEmpty(atSql.InputParamName) ? prop.Name : atSql.InputParamName;
                }
                //Console.WriteLine("T = " + prop.PropertyType.ToString() + " - " + (prop.GetValue(request) == null));                
                if (prop.PropertyType.IsEnum)
                {
                    if (prop.GetValue(request) == null)
                        param.Add(name, (int?)prop.GetValue(request));
                    else
                        param.Add(name, (int)prop.GetValue(request));
                }
                else if (prop.PropertyType == typeof(System.Xml.Linq.XElement))
                {
                    param.Add(name, prop.GetValue(request).ToString());
                }
                else if (prop.PropertyType.GetInterfaces().Any(x => x == typeof(System.Collections.Generic.IList<int>)
                                                                 || x == typeof(System.Collections.Generic.IList<long>)
                                                                 || x == typeof(System.Collections.Generic.IList<string>)))
                {
                    if (prop.GetValue(request) != null)
                    {
                        System.Collections.IList lst = (System.Collections.IList)prop.GetValue(request);
                        List<String> arrStr = new List<string>();
                        foreach (object o in lst)
                        {
                            arrStr.Add(o.ToString());
                        }
                        param.Add(name, string.Join(",", arrStr));
                    }
                    else
                    {
                        param.Add(name, null);
                    }
                }
                else if (prop.PropertyType.GetInterfaces().Any(x => x == typeof(System.Collections.IList)))
                {
                    if (prop.GetValue(request) != null)
                    {
                        string json = "{\"ROW\":" + JsonConvert.SerializeObject(prop.GetValue(request)) + "}";
                        XmlDocument node = null;
                        if (!string.IsNullOrWhiteSpace(json))
                        {
                            node = JsonConvert.DeserializeXmlNode(json, "ROOT");
                        }
                        param.Add(name, node.InnerXml);
                    }
                    else
                    {
                        param.Add(name, null);
                    }
                }
                else
                {
                    param.Add(name, prop.GetValue(request));
                }
            }
        }
    }
}
