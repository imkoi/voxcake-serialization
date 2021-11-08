using System;

namespace VoxCake.Serialization.Tests
{
    public class InvalidCapacitySizeException : Exception
    {
        public InvalidCapacitySizeException(int currentCapacity, int expectedCapacity) 
            : base($"ERROR: Current capacity is {currentCapacity}, but expected {expectedCapacity}!")
        {
            
        }
    }
}