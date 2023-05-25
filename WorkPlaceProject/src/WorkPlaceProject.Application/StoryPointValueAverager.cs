using WorkPlaceProject.Domain.StoryPointer.ValueTypes;

namespace WorkPlaceProject.Application
{
    public static class StoryPointValueAverager
    {
        private static decimal[] FibonacciNumbers = Array.ConvertAll(FibonacciValueType.Values.Select(x => x.Value).ToArray(), x => (decimal)x);

        public static int Average(int[] storyPointValues)
        {
            decimal average = storyPointValues.Sum() / storyPointValues.Length;

            var nearest = FibonacciNumbers.MinBy(x => Math.Abs((long)x - average));

            if (IsAFibonacciNumber(average))
            {
                return (int)average;
            }

            return 1;
        }

        private static bool IsAFibonacciNumber(decimal number) 
        {
            return FibonacciNumbers.Contains(number);
        }
    }
}
