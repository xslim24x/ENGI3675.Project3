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
            TimeSpan hpds_time_t = new TimeSpan();
            int hpds_indexed_row_test;
            TimeSpan hpds_indexed_time_t = new TimeSpan();
            
            Assignment3.select_all (out hpds_row_test, out hpds_time_t, out hpds_indexed_row_test,
            out hpds_indexed_time_t);

            total_row1 = hpds_row_test + hpds_indexed_row_test;
           
            Assert.IsFalse(hpds_row_test == 0);
            Console.WriteLine("Database has no contents to test");
            Assert.IsFalse(hpds_indexed_row_test == 0);
            Console.WriteLine("Database has no contents to test");
            System.Diagnostics.Debug.WriteLine(total_row1);


           
        }
    }
}
