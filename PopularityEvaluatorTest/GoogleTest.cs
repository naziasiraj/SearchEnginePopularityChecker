using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEnginePopularityChecker;

namespace PopularityEvaluatorTest
{
    [TestClass]
    public class GoogleTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception_When_Keyword_Is_Null()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            google.Search(null, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception_When_Keyword_Is_Empty()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            google.Search(string.Empty, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Throw_Exception_When_Search_Count_Is_Zero()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            google.Search("conveyancing software", 0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Thow_Exception_When_Search_Count_Is_Less_Than_One()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            google.Search("conveyancing software", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Thow_Exception_When_Keyword_Is_Null_And_Search_Count_Is_Less_Than_One()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            google.Search(null, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Thow_Exception_When_Keyword_Is_Empty_And_Search_Count_Is_Less_Than_One()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            google.Search(string.Empty, -1);
        }

    [TestMethod]
        public void Search_Gets_Correct_No_Of_Records_For_Valid_Input()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            List<SearchResult> result = google.Search("conveyancing software", 50);

            // Assert
            Assert.AreEqual(50, result.Count);
        }

        [TestMethod]
        public void Search_Gets_Number_Of_Records_Equal_To_Search_Count()
        {
            //Arrange
            ISearchEngine google = new Google();

            //Act
            List<SearchResult> result = google.Search("conveyancing software", 101);

            // Assert
            Assert.AreEqual(100, result.Count);
        }
    }
}
