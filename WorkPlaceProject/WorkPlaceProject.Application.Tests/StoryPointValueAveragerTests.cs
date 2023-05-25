namespace WorkPlaceProject.Application.Tests
{
    internal class StoryPointValueAveragerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] { 1 }, 1)]
        [TestCase(new int[] { 1, 2 }, 2)]
        [TestCase(new int[] { 1, 2, 3 }, 2)]
        [TestCase(new int[] { 1, 2, 3, 5 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 5, 8 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 5, 8, 13 }, 3)]
        [TestCase(new int[] { 1, 2, 3, 5, 8, 13, 21 }, 3)]
        public void Test(int[] values, int expectedResult)
        {
            int result = StoryPointValueAverager.Average(values);
                
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
