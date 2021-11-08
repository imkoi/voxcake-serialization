using System;

namespace VoxCake.Serialization.Tests
{
    public class InputAndOutputNotEqualException : Exception
    {
        public InputAndOutputNotEqualException(object inputValue, object outputValue) 
            : base($"ERROR: InputValue {inputValue} not equal to outputValue {outputValue}!")
        {
            
        }
    }
}