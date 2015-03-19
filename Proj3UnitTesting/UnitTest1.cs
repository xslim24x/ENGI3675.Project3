namespace Proj3UnitTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Proj3DBAccess;
    using System.Diagnostics;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
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
            
            Assert.AreEqual(0,hpds_row_test);
            Console.WriteLine("Database has no contents to test");
            Assert.AreEqual(0,hpds_indexed_row_test);
            Console.WriteLine("Database has no contents to test");
            Debug.WriteLine("Total rows or select all query for hpds:", hpds_row_test);
            Debug.WriteLine("Total rows or select all query for hpds_indexed:", hpds_indexed_row_test);
            Debug.WriteLine("Total time to execute hpds select all query", hpds_time_t);
            Debug.WriteLine("Total tie to execute hpds_indexed select all query", hpds_indexed_time_t);

            Assert.AreEqual(0,hpds_row_test_w);
            Console.WriteLine("Database has no contents to test");
            Assert.IsFalse(hpds_indexed_row_test_w == 0);
            Console.WriteLine("Database has no contents to test");
            Debug.WriteLine("Total rows of select query with where clause for hpds:", hpds_row_test_w);
            Debug.WriteLine("Total rows of select query with where clause for hpds:", hpds_indexed_row_test_w);
            Debug.WriteLine("Total time to execute hpds with where claue", hpds_time_t_w);
            Debug.WriteLine("Total tie to execute hpds_indexed select with where clause", hpds_indexed_time_t_w);

            Assert.IsFalse(hpds_time_t_w > hpds_indexed_time_t_w);


        }
    }
}
