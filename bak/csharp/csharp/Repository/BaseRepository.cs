﻿using com.sun.org.apache.xml.@internal.resolver.helpers;
using csharp.Estities;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace csharp.Repository
{
    public class BaseRepository

    {
        public static string DBConnection;


        public void ExecCommand(string query)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public static DataTable ExecQuery(string query)
        {
            try
            {
                DataTable table = new DataTable();

                using (SqlConnection connection = new SqlConnection(DBConnection))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter
                        {
                            SelectCommand = command,
                        };
                        adapter.Fill(table);
                    }
                }
                return table;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
