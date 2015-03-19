namespace Proj3UnitTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Proj3DBAccess;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int total_row1, total_row2;
            
            int hpds_row_test;
            TimeSpan hpds_time_t;
            int hpds_indexed_row_test;
            TimeSpan hpds_indexed_time_t;

            int hpds_row_test_w;
            TimeSpan hpds_time_t_w;
            int hpds_indexed_row_test_w;
            TimeSpan hpds_indexed_time_t_w;

            string plan_hpds_test;
            string plan_hpds_indexed_test;
            
            Assignment3.select_all (out hpds_row_test, out hpds_time_t, 
                out hpds_indexed_row_test,out hpds_indexed_time_t);

            Assignment3.select_where(out hpds_row_test_w, out hpds_time_t_w, 
                out hpds_indexed_row_test_w, out hpds_indexed_time_t_w);

            Assignment3.query_plan(out plan_hpds_test, out plan_hpds_indexed_test);
            
            total_row1 = hpds_row_test + hpds_indexed_row_test;
            Assert.AreEqual(0,hpds_row_test);
            Console.WriteLine("Database has no contents to test");
            Assert.IsFalse(hpds_indexed_row_test == 0);
            Console.WriteLine("Database has no contents to test");
            System.Diagnostics.Debug.WriteLine("Total rows or select all query:", total_row1);
            System.Diagnostics.Debug.WriteLine("Total time to execute hpds select all query", hpds_time_t);
            System.Diagnostics.Debug.WriteLine("Total tie to execute hpds_indexed select all query", hpds_indexed_time_t);

            total_row2 = hpds_row_test_w + hpds_indexed_row_test_w;
            Assert.IsFalse(hpds_row_test_w == 0);
            Console.WriteLine("Database has no contents to test");
            Assert.IsFalse(hpds_indexed_row_test_w == 0);
            Console.WriteLine("Database has no contents to test");
            System.Diagnostics.Debug.WriteLine("Total rows or select query with where clause:", total_row2);
            System.Diagnostics.Debug.WriteLine("Total time to execute hpds with where claue", hpds_time_t_w);
            System.Diagnostics.Debug.WriteLine("Total tie to execute hpds_indexed select with where clause", hpds_indexed_time_t_w);

            Assert.IsFalse(hpds_time_t_w > hpds_indexed_time_t_w);


        }
    }
}
