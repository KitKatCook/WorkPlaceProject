namespace WorkPlaceProject.Domain.StoryPointer.ValueTypes
{
    public static class FibonacciValueType 
    {
        public static HashSet<ValueType> Values = new HashSet<ValueType>()
        {
            new ValueType(0, 0, "Description"),
            new ValueType(1, 1, "Description"),
            new ValueType(2, 2, "Description"),
            new ValueType(3, 3, "Description"),
            new ValueType(4, 5, "Description"),
            new ValueType(5, 8, "Description"),
            new ValueType(6, 13, "Description"),
            new ValueType(7, 21, "Description"),
        };
    }
}
