using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1_Racing_Hub.Stored_Procedures
{
    internal static class StoredProcedure
    {
        public static object CallProcedure(string procedureName, params (string key, object value)[] parameters)
        {
            object returnValue = ExecuteCommand(procedureName, parameters);
            return returnValue;
        }

        static object ExecuteCommand(string procedureName, params (string key, object value)[] parameters)
        {
            using var connection = new SqlConnection("Data Source=localhost;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            using var command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure,
            };
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.key, parameter.value);
            }
            var returnValue = command.Parameters.Add("returnValue", SqlDbType.Variant);
            returnValue.Direction = ParameterDirection.ReturnValue;
            connection.Open();
            command.ExecuteNonQuery();
            return returnValue.Value;
        }
    }
}
