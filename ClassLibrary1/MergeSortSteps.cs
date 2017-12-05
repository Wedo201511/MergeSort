using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1
{
    [Binding]
    public class MergeSortSteps
    {
        private SortProcessor sortProcessor = new SortProcessor();
        private SortProcessorWithRecursion sortProcessorWithRecursion = new SortProcessorWithRecursion();
        [Given(@"The array contains (.*) elements")]
        public void GivenTheArrayContainsElements(int arrayLength)
        {
            sortProcessor.GenerateOriginalArray(arrayLength);
        }

        [Then(@"Sort the array with  (.*) threads")]
        public void ThenSortTheArrayWithThreads(int threadCount)
        {
            sortProcessor.SortWithMultyThreads(threadCount);
        }

        [Then(@"Validate the result array is ascending")]
        public void ThenValidateTheResultArrayIsAscending()
        {
            var isAscending = sortProcessor.VerifyIsAscending();
            Assert.IsTrue(isAscending);
        }


        [Given(@"Generate a array which contains (.*) elements")]
        public void GivenGenerateAArrayWhichContainsElements(int arrayLength)
        {
            sortProcessorWithRecursion.GenerateOriginalArray(arrayLength);
        }

        [Then(@"Sort the array with recursion")]
        public void ThenSortTheArrayWithRecursion()
        {
             sortProcessorWithRecursion.SortWithRecursion().Wait();
        }

        [Then(@"Validate the recursion result array is ascending")]
        public void ThenValidateTheRecursionResultArrayIsAscending()
        {
            var isAscending = sortProcessorWithRecursion.VerifyIsAscending();
            Assert.IsTrue(isAscending);
        }

    }
}
