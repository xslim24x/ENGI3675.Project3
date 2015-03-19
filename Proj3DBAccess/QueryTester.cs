using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Proj3DBAccess
{
    /// <summary>
    /// Set of functions to run queries against a table and determine
    /// the time it takes to complete
    /// </summary>
    public class QueryTester
    {

        /// <summary>
        /// This function will use a select all query to determine the number of rows in a table
        /// </summary>
        /// <param name="timeticker">A reference will be used to pass on the Time the query took</param>
        /// <param name="tablename">Table name of which the query will be performed on</param>
        /// <returns>Will return the amount of rows which in the table</returns>
        public static int selectAllRows(ref TimeSpan timeticker, string tablename){

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;" +
                   "IntegratedSecurity=True;Database=Assignment3;");
            
            conn.Open();
            NpgsqlCommand MyQuery = conn.CreateCommand();
            MyQuery.CommandText = "SELECT * from " + tablename + ";";

            int rowcount = 0;
            timeticker = DateTime.Now.TimeOfDay;
            NpgsqlDataReader reader = MyQuery.ExecuteReader();
            while (reader.Read())
            {
                rowcount++;
            }
            timeticker = DateTime.Now.TimeOfDay - timeticker;
            reader.Close();
            conn.Close();
            
            return rowcount;
        }

        /// <summary>
        /// This function injects a WHERE clause after the table name to select entries that represent
        /// Livestock by an amount under 1000 in Asia
        /// The selectall function is called using these conditions to pass back:
        /// the total row count
        /// modify the reference time it took to complete
        /// </summary>
        /// <param name="timeticker">This passes on the time reference to the selectall function</param>
        /// <param name="tablename">Table name of which the query will be performed on</param>
        /// <returns>
        /// Will return the amount of rows which in the table which have the following conditions:
        /// Continent is Asia
        /// amount is less than 1000
        /// Sector is Livestock
        /// </returns>
        public static int selectRowsWhereX(ref TimeSpan timeticker, string tablename){
            tablename+=" WHERE continent = 'Asia' AND amount < 1000 AND sector='Livestock'";
            return selectAllRows(ref timeticker,tablename);
        }

        /// <summary>
        /// This function determines the query plan of the 'select/where'
        /// determined by the selectrowswhere function
        /// </summary>
        /// <param name="tablename">Table name to place in query</param>
        /// <returns>will return the query plan which is the method the database plans to execute the query</returns>
        public static string queryPlan(string tablename){

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;" +
                   "IntegratedSecurity=True;Database=Assignment3;");
            
            conn.Open();
            NpgsqlCommand MyQuery = conn.CreateCommand();
            MyQuery.CommandText = "EXPLAIN SELECT * from " + tablename +  " WHERE continent = 'Asia' AND amount < 1000 AND sector='Livestock';";
            NpgsqlDataReader reader = MyQuery.ExecuteReader();

            string plan = "";
            while (reader.Read())
            {
                plan += (string)reader["QUERY PLAN"];
            }
            
            reader.Close();
            conn.Close();
            
            return plan;
        }

    }
}
