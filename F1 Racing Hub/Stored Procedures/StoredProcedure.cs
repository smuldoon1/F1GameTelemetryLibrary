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
        public static SqlDataReader CallProcedure(string procedureName, params (string key, object value)[] parameters)
        {
            using SqlDataReader reader = ExecuteCommand(procedureName, parameters).ExecuteReader();
            return reader;
        }

        static SqlCommand ExecuteCommand(string procedureName, params (string key, object value)[] parameters)
        {
            using var connection = new SqlConnection("");
            using var command = new SqlCommand(procedureName, connection)
            {
                CommandType = CommandType.StoredProcedure,
            };
            foreach (var parameter in parameters)
            {
                command.Parameters.AddWithValue(parameter.key, parameter.value);
            }
            connection.Open();
            command.ExecuteNonQuery();
            return command;
        }
    }
}
