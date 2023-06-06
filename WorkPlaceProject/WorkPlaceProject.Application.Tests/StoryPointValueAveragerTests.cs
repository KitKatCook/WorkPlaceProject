namespace WorkPlaceProject.Application.Tests
{
    internal class StoryPointValueAveragerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 2 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 3 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 5 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 8 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 13 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 21 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 1, 1, 2, 1 }, 1)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 1, 5 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 1, 8 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 1, 13 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 1, 21 }, 5)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 1 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 2 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 3 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 5 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 8 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 13 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 2, 21 }, 5)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 1 }, 2)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 2 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 3 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 5 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 8 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 13 }, 5)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 3, 21 }, 5)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 5, 1 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 5, 2 }, 3)]
        [TestCase(new int[] { 1, 1, 1, 8, 2, 5, 3 }, 3)]
        [TestCase(new int[] { 1, 1, 2, 3, 8, 1, 5 }, 3)]
        [TestCase(new int[] { 1, 1, 2, 3, 8, 1, 8 }, 3)]
        [TestCase(new int[] { 1, 1, 2, 3, 8, 1, 13 }, 5)]
        [TestCase(new int[] { 1, 1, 2, 3, 8, 1, 21 }, 5)]
        [TestCase(new int[] { 1, 1, 2, 3, 8, 2, 1 }, 3)]
        [TestCase(new int[] { 1, 1, 2, 3, 8, 2, 2 }, 3)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 2, 8 }, 8)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 2, 13 }, 8)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 2, 21 }, 8)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 3, 1 }, 5)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 3, 2 }, 5)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 3, 3 }, 5)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 3, 5 }, 5)]
        [TestCase(new int[] { 1, 1, 5, 21, 8, 3, 8 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 1, 2 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 1, 3 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 1, 5 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 1, 8 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 1, 13 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 1, 21 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 1 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 2 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 3 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 5 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 8 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 13 }, 8)]
        [TestCase(new int[] { 1, 5, 3, 13, 21, 2, 21 }, 8)]
        public void Test(int[] values, int expectedResult)
        {
            int result = StoryPointValueAverager.Average(values.ToList());
                
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
