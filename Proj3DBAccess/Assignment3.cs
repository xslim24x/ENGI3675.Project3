namespace Proj3DBAccess
{
    using System;
    using System.Web;
    using Npgsql;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class Assignment3
    {
      /// <summary>
      /// Purpose of the select_all function is to get the total number of rows for tables:hpds, and hpds_indexed.
      /// the function also gets the time that it took to execute the query 
      /// </summary>
      /// <param name="hpds_row"></param>
      /// <param name="hpds_execute_t"></param>
      /// <param name="hpds_indexed_row"></param>
      /// <param name="hpds_indexed_execute_t"></param>
      
       public static void select_all(out int hpds_row, out TimeSpan hpds_time, 
       out int hpds_indexed_row, out TimeSpan hpds_indexed_time)       
    {
            hpds_row = 0;
            hpds_indexed_row = 0;
            hpds_time = new TimeSpan();
            hpds_indexed_time = new TimeSpan();
     
            TimeSpan time_s = new TimeSpan();
            TimeSpan time_f = new TimeSpan();

           NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;" +
                   "IntegratedSecurity=True;Database=Assignment3;");

            conn.Open();

            NpgsqlCommand Command_1 = conn.CreateCommand();

            Command_1.CommandText = "SELECT * from hpds";
            NpgsqlDataReader reader1 = Command_1.ExecuteReader();
            
            time_s = DateTime.Now.TimeOfDay;
            
            while (reader1.Read())
            {
                hpds_row++;
            }
           
            time_f = DateTime.Now.TimeOfDay;
            hpds_time = time_f - time_s;

            reader1.Close();
            conn.Close();
            conn.Open();

            NpgsqlCommand Command_2 = conn.CreateCommand();
            Command_2.CommandText = "Explain SELECT * from hpds_indexed ;";
            NpgsqlDataReader reader2 = Command_2.ExecuteReader();
            time_s = DateTime.Now.TimeOfDay;

            while (reader1.Read())
            {
                hpds_indexed_row++;
            }

            time_f = DateTime.Now.TimeOfDay;
            hpds_indexed_time = time_f - time_s;
        }

        /// <summary>
        /// Puporse of the select_where function is to get the total number of rows for tables"hpds, and hpds_indexed", 
        /// with the new sql query that has a where clause.
        /// The function also gets the time that it took to execute the query.
        /// </summary>
        /// <param name="hpds_row_w"></param>
        /// <param name="hpds_execute_t_w"></param>
        /// <param name="hpds_indexed_row_w"></param>
        /// <param name="hpds_indexed_execute_t_w"></param>
       public static void select_where(out int hpds_row_w, out TimeSpan hpds_time_w,
       out int hpds_indexed_row_w, out TimeSpan hpds_indexed_time_w)
       {
           hpds_row_w = 0;
           hpds_indexed_row_w = 0;
           hpds_time_w = new TimeSpan();
           hpds_indexed_time_w = new TimeSpan();

           TimeSpan time_s = new TimeSpan();
           TimeSpan time_f = new TimeSpan();

           NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;" +
                   "IntegratedSecurity=True;Database=assignment3;");

           conn.Open();

           NpgsqlCommand Command_1 = conn.CreateCommand();
           Command_1.CommandText = "SELECT * from hpds where continent = 'Asia' AND amount < 1000 AND sector='Livestock';";
           NpgsqlDataReader reader1 = Command_1.ExecuteReader();

           time_s = DateTime.Now.TimeOfDay;

           while (reader1.Read())
           {
               hpds_row_w++;
           }

           time_f = DateTime.Now.TimeOfDay;
           hpds_time_w = time_f - time_s;
           
           reader1.Close();
           conn.Close();
           conn.Open();

           NpgsqlCommand Command_2 = conn.CreateCommand();
           Command_2.CommandText = "Explain SELECT * from hpds_indexed where continent = 'Asia' AND amount < 1000 AND sector='Livestock';";
           NpgsqlDataReader reader2 = Command_2.ExecuteReader();

           time_s = DateTime.Now.TimeOfDay;

           while (reader2.Read())
           {
               hpds_indexed_row_w++;
           }

           time_f = DateTime.Now.TimeOfDay;
           hpds_indexed_time_w = time_f - time_s;
       }
        /// <summary>
        /// This query_plan function simply returns the query plan for both of the sql quries with the where clause
        /// one for the hpds, and one for hpds_indexed
        /// </summary>
        /// <returns></returns>
        public static void query_plan(out string plan, out string plan2)
       {   
            plan = "";
            plan2 = "";
            List<string> plan_x = new List<string>();
            List<string> plan_x2 = new List<string>();

            NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;" +
               "IntegratedSecurity=True;Database=Assignment3;");

            conn.Open();

            NpgsqlCommand Command_1 = conn.CreateCommand();

            Command_1.CommandText = "Explain SELECT * from hpds where continent = 'Asia' AND amount < 1000 AND sector='Livestock';";
            NpgsqlDataReader reader1 = Command_1.ExecuteReader();

            while (reader1.Read())
            {
                plan += (string)reader1["QUERY PLAN"];

            }

            reader1.Close();
            conn.Close();
            conn.Open();

            NpgsqlCommand Command_2 = conn.CreateCommand();
            Command_2.CommandText = "Explain SELECT * from hpds_indexed where continent = 'Asia' AND amount < 1000 AND sector='Livestock';";
            NpgsqlDataReader reader2 = Command_2.ExecuteReader();

            while (reader2.Read())
            {
                plan2 += (string)reader1["QUERY PLAN"];
            }
        }
     }
}

