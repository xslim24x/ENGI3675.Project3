namespace Proj3UnitTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using Proj3DBAccess;
    using System.Diagnostics;

    [TestClass]
    public class Project3Test
    {
        /// <summary>
        /// This test ensures the tables have the same amount of rows and aren't empty
        /// The amount of rows of both tables are printed to the debug console
        /// </summary>
        [TestMethod]
        public void SelectAllTest()
        {
            TimeSpan hpds_time = new TimeSpan();
            TimeSpan hpds_indexed_time = new TimeSpan();
            int hpds_rows = QueryTester.selectAllRows(ref hpds_time, "hpds");
            int hpds_indexed_rows = QueryTester.selectAllRows(ref hpds_indexed_time, "hpds_indexed");

            //ensure tables aren't empty
            Assert.AreNotEqual(0, hpds_rows, "Something went wrong, table hpds was read to be empty");
            Assert.AreNotEqual(0, hpds_indexed_rows, "Something went wrong, table hpds_indexed was read to be empty");

            //both tables contain the same amount of data
            Assert.AreEqual(hpds_rows, hpds_indexed_rows, "Tables have different amount of entries");

            Debug.Print("Rows in hpds:\t{0}\nQuery Time:\t{1}ms\n",hpds_rows,hpds_time.Milliseconds);
            Debug.Print("Rows in hpds_indexed:\t{0}\nQuery Time:\t{1}ms\n", hpds_indexed_rows,hpds_indexed_time.Milliseconds);
        }

        /// <summary>
        /// This test ensures the tables have the same amount of rows and aren't empty
        /// The amount of rows of both where'd queries 
        /// are printed to the debug console
        /// </summary>
        [TestMethod]
        public void SelectWhereTest()
        {
            TimeSpan hpds_time = new TimeSpan();
            TimeSpan hpds_indexed_time = new TimeSpan();
            int hpds_rows = QueryTester.selectRowsWhereX(ref hpds_time, "hpds");
            int hpds_indexed_rows = QueryTester.selectRowsWhereX(ref hpds_indexed_time, "hpds_indexed");

            //ensure tables aren't empty
            Assert.AreNotEqual(0, hpds_rows, "Something went wrong, table hpds was read to be empty");
            Assert.AreNotEqual(0, hpds_indexed_rows, "Something went wrong, table hpds_indexed was read to be empty");

            //both tables contain the same amount of data
            Assert.AreEqual(hpds_rows, hpds_indexed_rows, "Tables have different amount of entries");

            Debug.Print("Rows in hpds:\t{0}\nQuery Time:\t{1}ms\n", hpds_rows, hpds_time.Milliseconds);
            Debug.Print("Rows in hpds_indexed:\t{0}\nQuery Time:\t{1}ms\n", hpds_indexed_rows, hpds_indexed_time.Milliseconds);
        }


        /// <summary>
        /// This test verifies that the indexed table is quicker during the where'd query
        /// A time comparison is sent to the debug console
        /// </summary>
        [TestMethod]
        public void IndexIsFaster()
        {
            TimeSpan hpds_time = new TimeSpan();
            TimeSpan hpds_indexed_time = new TimeSpan();
            int hpds_rows = QueryTester.selectRowsWhereX(ref hpds_time, "hpds");
            int hpds_indexed_rows = QueryTester.selectRowsWhereX(ref hpds_indexed_time, "hpds_indexed");

            Assert.IsTrue(hpds_indexed_time < hpds_time, "Indexed table is slower than non-indexed table");
            Debug.Print("Query time for indexed table was {2}ms faster\n\nTime for hpds:\t{0}ms\nTime for hpds_indexed:\t{1}ms\n", hpds_time.Milliseconds, hpds_indexed_time.Milliseconds, hpds_time.Milliseconds - hpds_indexed_time.Milliseconds);

        }

        /// <summary>
        /// This takes the raw query plan and returns a formatted string with
        /// the setup cost: xx.xxx
        /// Total cost: xx.xxx
        /// </summary>
        /// <param name="plan">the raw query plan as returned by the EXPLAIN SELECT</param>
        /// <returns>setup cost and total cost of the expected plan</returns>
        public string PlanParser(string plan)
        {
            plan = plan.Remove(0, (plan.IndexOf("cost=") + 5));
            plan = plan.Remove(plan.IndexOf("rows"), (plan.Length - plan.IndexOf("rows")));
            plan = plan.Insert(0, "Setup Cost:\t");
            plan = plan.Replace("..", "\nTotal Cost:\t");
            return plan;
        }

        /// <summary>
        /// This test calls the query plan and ensures the unindexed table uses a
        /// sequential scan while the indexed table doesnt.
        /// </summary>
        [TestMethod]
        public void CorrectQueryPlan()
        {
            string plan1 = QueryTester.queryPlan("hpds");
            string plan2 = QueryTester.queryPlan("hpds_indexed");
            
            Assert.IsTrue(plan1.Contains("Seq Scan"),"Non-indexed table is not performing a sequential scan");
            Assert.IsFalse(plan2.Contains("Seq Scan"), "Indexed table is performing a sequential scan");
            
            Debug.Print("hpds\n{0}\n",PlanParser(plan1));
            Debug.Print("hpds_indexed\n{0}\n",PlanParser(plan2));
        }


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
