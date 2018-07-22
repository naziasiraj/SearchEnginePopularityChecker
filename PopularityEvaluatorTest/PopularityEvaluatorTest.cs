using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEnginePopularityChecker;

namespace PopularityEvaluatorTest
{
    [TestClass]
    public class PopularityEvaluatorTest
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception_When_Search_Engine_Is_Null()
        {
            //Act
            PopularityEvaluator evaluator = new PopularityEvaluator(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception_When_Keyword_Is_Empty()
        {
            //Arrange
            PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine());

            //Act
            List<int> result = evaluator.EvaluatePopularity("", "www.smokeball.com.au", 100);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception_When_URL_Is_Empty()
        {
            {
                //Arrange
                PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine());

                //Act
                List<int> result = evaluator.EvaluatePopularity("conveyancing software", "", 100);

            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Throw_Exception_When_Keyword_And_URL_Are_Empty()
        {
            {
                //Arrange
                PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine());

                //Act
                List<int> result = evaluator.EvaluatePopularity("", "", 100);

            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Throw_Exception_When_searchCount_Is_LessThan_Zero()
        {
            {
                //Arrange
                PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine());

                //Act
                List<int> result = evaluator.EvaluatePopularity("conveyancing software", "www.smokeball.com.au", -1);

            }

        }


        [TestMethod]
        public void Return_Zero_When_Search_Response_Is_Empty()
        {
            //Arrange
            PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine());

            //Act
            List<int> result = evaluator.EvaluatePopularity("conveyancing software", "www.smokeball.com.au", 100);

            // Assert
            CollectionAssert.AreEqual(new List<int>() { 0 }, result);
        }

        [TestMethod]
        public void Return_Correct_Response_When_URL_Not_Found()
        {
            //Arrange
            PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine_URLNotFound());

            //Act
            List<int> result = evaluator.EvaluatePopularity("conveyancing software", "www.smokeball.com.au", 100);

            // Assert
            CollectionAssert.AreEqual(new List<int>() { 0 }, result);
        }

        [TestMethod]
        public void Return_Correct_Response_When_URL_Found_Once()
        {
            //Arrange
            PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine_URLFoundOnce());

            //Act
            List<int> result = evaluator.EvaluatePopularity("conveyancing software", "www.smokeball.com.au", 100);

            // Assert
            CollectionAssert.AreEqual(new List<int>() { 2 }, result);
        }

        [TestMethod]
        public void Return_Correct_Response_When_URL_Found_More_Than_Once()
        {
            //Arrange
            PopularityEvaluator evaluator = new PopularityEvaluator(new MockSearchEngine_URLFoundMoreThanOnce());

            //Act
            List<int> result = evaluator.EvaluatePopularity("conveyancing software", "www.smokeball.com.au", 100);

            // Assert
            CollectionAssert.AreEqual(new List<int>() { 1, 3 }, result);
        }

    }
}
