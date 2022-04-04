using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Tets add function and compares to array
        /// </summary>
        [TestMethod]
        public void Test_Add()
        {
            TaxData[] testArray;
            LinkedList<TaxData> list;
            CreateTestData(10, out list, out testArray);

            int index = 0;
            foreach (TaxData taxData in list)
            {
                Assert.IsTrue(taxData.Equals(testArray[index]));
                index++;
            }
        }

        /// <summary>
        /// Tests LinkedList Sort() function and compares to array funcction
        /// </summary>
        [TestMethod]
        public void Test_Sort()
        {
            TaxData[] testArray;
            LinkedList<TaxData> list;
            CreateTestData(10, out list, out testArray);

            list.Sort();
            testArray = SortArray(testArray);
            int index = 0;
            foreach (TaxData taxData in list)
            {
                Assert.IsTrue(taxData.Equals(testArray[index]));
                index++;
            }
        }

        /// <summary>
        /// Sorts TaxData[] object to compare to LinkedList object
        /// </summary>
        /// <param name="array">Unsorted object</param>
        /// <returns>sorted array</returns>
        public TaxData[] SortArray(TaxData[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if(array[j].CompareTo(array[j+1]) > 0)
                    {
                        // SWAP
                        TaxData temp = array[j];
                        array[j] = array[j+1];
                        array[j+1] = temp;
                    }
                }
            }
            return array;
        }

        /// <summary>
        /// Creates test data with the same objects to compare while doing testsgggg
        /// </summary>
        /// <param name="size">amount of elements</param>
        /// <param name="linkedList">OUT Lab03 implementation of linked list</param>
        /// <param name="taxData">OUT Array</param>
        public void CreateTestData(int size, out LinkedList<TaxData> linkedList, out TaxData[] taxData)
        {
            linkedList = new LinkedList<TaxData>();
            taxData = new TaxData[size];
            for (int i = 0; i < size; i++)
            {
                Random rng = new Random();
                TaxData temp = new TaxData(rng.Next(100).ToString(), i.ToString(), (double)i/10);
                linkedList.Add(temp);
                taxData[i] = temp;
            }
        }

    }
}
