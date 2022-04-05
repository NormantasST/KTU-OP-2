using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab02;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Compares CitizenData object with same parameters. Comparison should return 0
        /// </summary>
        [TestMethod]
        public void CompareTo_CitizenDataSame_Returns0()
        {
            CitizenData cData1 = new CitizenData("lastname", "firstname", "address", 0);
            CitizenData cData2 = new CitizenData("lastname", "firstname", "address", 0);
            Assert.AreEqual(cData1.CompareTo(cData2),0);
        }

        /// <summary>
        /// Compares lhs CitizenData object with alphabetically higher parameters. Comparison should return 1
        /// </summary>
        [TestMethod]
        public void CompareTo_CitizenDataSame_Returns1()
        {
            CitizenData cData1 = new CitizenData("a", "a", "a", 0);
            CitizenData cData2 = new CitizenData("b", "b", "b", 0);
            Assert.AreEqual(cData1.CompareTo(cData2), 1);
        }

        /// <summary>
        /// Compares lhs CitizenData object with alphabetically lower parameters. Comparison should return -1
        /// </summary>
        [TestMethod]
        public void CompareTo_CitizenDataSame_ReturnsMinus1()
        {
            CitizenData cData1 = new CitizenData("b", "b", "b", 0);
            CitizenData cData2 = new CitizenData("a", "a", "a", 0);
            Assert.AreEqual(cData1.CompareTo(cData2), -1);
        }

        /// <summary>
        /// Tests CitizenTax and CitizenTaxData object comparison with different parameters
        /// </summary>
        [TestMethod]
        public void Equals_CitizenDataCitizenTaxDataDifferentParameters_False()
        {
            CitizenData cData = new CitizenData("lastname1", "firstname1", "address1", 0);
            CitizenTaxData cTaxData = new CitizenTaxData("lastname0", "firstname0", "address0", "April", "0", 0);
            Assert.IsFalse(cData.Equals(cTaxData));
        }

        /// <summary>
        /// Tests CitizenTax and CitizenTaxData object comparison with same parameters
        /// </summary>
        [TestMethod]
        public void Equals_CitizenDataCitizenTaxDataSameParameters_True()
        {
            CitizenData cData = new CitizenData("lastname", "firstname", "address", 0);
            CitizenTaxData cTaxData = new CitizenTaxData("lastname", "firstname", "address", "April", "0", 0);
            Assert.IsTrue(cData.Equals(cTaxData));
        }

        /// <summary>
        /// Tests 2 Citizen Data Comparison with same parameters. Should Return True.
        /// </summary>
        [TestMethod]
        public void Equals_CitizenDataSameParameters_True()
        {
            CitizenData cData1 = new CitizenData("lastname1", "firstname1", "address1", 0);
            CitizenData cData2 = new CitizenData("lastname1", "firstname1", "address1", 0);

            Assert.IsTrue(cData1.Equals(cData2));
        }

        /// <summary>
        /// Tests 2 Citizen Data Comparison with different Keys. Should Return false.
        /// </summary>
        [TestMethod]
        public void Equals_CitizenDataDifferentParameters_False()
        {
            CitizenData cData1 = new CitizenData("lastname1", "firstname1", "address1", 0);
            CitizenData cData2 = new CitizenData("lastname2", "firstname2", "address2", 0);

            Assert.IsFalse(cData1.Equals(cData2));
        }

        /// <summary>
        /// Tets add function and compares to array
        /// </summary>
        [TestMethod]
        public void Add_LinkedListArrayEquality_True()
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
        public void Sort_LinkedListArrayEquality_True()
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
