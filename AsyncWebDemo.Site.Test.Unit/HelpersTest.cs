using AsyncWebDemo.Site.Helpers;
using System.Diagnostics;
using System.Text;

namespace AsyncWebDemo.Site.Test.Unit
{
    public class HelpersTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Given_StringHelper_When_StrinHasDuplicates_Then_ReturnsStringWithNoDuplicates()
        {
            //Arrange
            string? inputString = "abcdefgah";
            string? expectedString = "abcdefgh";

            //Act
            string? result = StringHelper.RemoveDuplicateCharactersFromString(inputString);

            //Assert
            Console.WriteLine($"input:{inputString}; expected: {expectedString}; result: {result}");
            Assert.That(result == expectedString);

        }
        
        [Test]
        public void Given_StringHelper_When_StrinHasDuplicateWords_Then_ReturnsStringWithNoDuplicates()
        {
            //Arrange
            string? inputString = "string with string words";
            string? expectedString = "string with words";

            //Act
            string? result = StringHelper.RemoveDuplicateWordsFromString(inputString);

            //Assert
            Console.WriteLine($"input:{inputString}; expected: {expectedString}; result: {result}");
            Assert.That(result == expectedString);

        }
        
        [Test]
        public void Given_ProduceListOfAverageOfEveryDesiredAmountOfUnits_When_ListHas20Prices_Then_Returns5AveragesOfPrices()
        {
            //Arrange
            List<decimal> decimalList = new List<decimal>()          { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
            List<decimal> expectedDecimalList = new List<decimal>()              { 3.0M, 8.0M, 13.0M, 18.0M};
            int window = 5;

            //Act
            List<decimal> result = SlidingWindowHelper.ProduceListOfAverageOfEveryDesiredAmountOfUnits(decimalList, window);

            //Assert
            Console.WriteLine($"input:{LogListGeneric<decimal>(decimalList)}; expected: {LogListGeneric<decimal>(expectedDecimalList)}; result: {LogListGeneric<decimal>(result)}");
            Assert.That(result, Is.EquivalentTo(expectedDecimalList));
            
        }

        [Test]
        public void Given_SlidingWindowHelper_When_ListHas20Days_Then_Returns20DayMovingAverage()
        {
            //Arrange
            List<decimal> decimalList = new List<decimal>()          { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20};
            List<decimal> expectedDecimalList = new List<decimal>()              { 3, 4, 5, 6, 7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18};
            int window = 5;

            //Act
            List<decimal> result = SlidingWindowHelper.ProduceListOfMovingAverage(decimalList, window);

            //Assert
            Console.WriteLine($"input:{LogListGeneric<decimal>(decimalList)}; expected: {LogListGeneric<decimal>(expectedDecimalList)}; result: {LogListGeneric<decimal>(result)}");
            Assert.That(result, Is.EquivalentTo(expectedDecimalList));

        }

        private static string LogListGeneric<T>(List<T> objectList)
            
        {
            StringBuilder logString = new StringBuilder();
            foreach (var item in objectList)
            {
                logString.Append($": {item?.ToString()}");
            }
            return logString.ToString();
        }
    }
}
