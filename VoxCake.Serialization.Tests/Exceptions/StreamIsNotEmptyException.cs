using System;

namespace VoxCake.Serialization.Tests
{
    public class StreamIsNotEmptyException : Exception
    {
        public StreamIsNotEmptyException() 
            : base($"ERROR: Stream is not empty!")
        {
            
        }
    }
}