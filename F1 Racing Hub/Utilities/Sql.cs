using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace F1_Racing_Hub
{
    public static class Sql
    {
        static readonly string ConnectionString = "Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static T[] ExecuteArray<T>(string sql,  params KeyValuePair<string, object>[] parameters) where T : new()
        {
            using var cmd = new SqlCommand()
            {
                CommandText = sql,
                CommandType = System.Data.CommandType.Text
            };
            foreach (var parameter in parameters)
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;
            var reader = cmd.ExecuteReader();
            List<T> results = new();
            PropertyInfo[] properties = typeof(T).GetProperties();
            while (reader.Read())
            {
                T t = new();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    IEnumerable<PropertyInfo> p = properties.Where(x => x.Name.Equals(reader.GetName(i), StringComparison.OrdinalIgnoreCase));
                    if (p.Any())
                    {
                        var propertyType = p.First().PropertyType;
                        p.First().SetValue(t, Convert.ChangeType(reader.GetValue(i), propertyType));
                    }
                }
                results.Add(t);
            }
            return results.ToArray();
        }

        public static void Execute(string sql, params KeyValuePair<string, object>[] parameters)
        {
            using var cmd = new SqlCommand()
            {
                CommandText = sql,
                CommandType = System.Data.CommandType.Text
            };
            foreach (var parameter in parameters)
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            return;
        }

        public static T ExecuteScalar<T>(string sql, params KeyValuePair<string, object>[] parameters)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand()
            {
                Connection = conn,
                CommandText = sql,
                CommandType = System.Data.CommandType.Text
            };
            foreach (var parameter in parameters)
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            conn.Open();
            return (T)cmd.ExecuteScalar();
        }
    }
}
