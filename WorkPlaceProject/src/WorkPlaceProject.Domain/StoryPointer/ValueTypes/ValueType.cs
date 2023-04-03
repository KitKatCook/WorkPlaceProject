using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkPlaceProject.Domain.StoryPointer.ValueTypes
{
    public class ValueType
    {
        public ValueType(int index, int value, string description)
        {
            Index = index;
            Value = value;
            Description = description;
        }

        public int Index { get; set; }

        public int Value { get; set; }

        public string Description { get; set; }
    }
}
