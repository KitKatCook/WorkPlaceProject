using WorkPlaceProject.Domain.StoryPointer.ValueTypes;

namespace WorkPlaceProject.Application
{
    public static class StoryPointValueAverager
    {
        public static int Average(List<int> numbers)
        {
            double average = CalculateAverage(numbers);
            return GetClosestFibonacci(average);
        }

        public static double CalculateAverage(List<int> numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }

            return (double)sum / numbers.Count;
        }

        public static int GetClosestFibonacci(double number)
        {
            int a = 0;
            int b = 1;
            while (b < number)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            if (Math.Abs(b - number) < Math.Abs(a - number))
            {
                return b;
            }
            else
            {
                return a;
            }
        }
    }
}
