using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class LongSerializer : Serializer<long>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(long variable, List<byte> buffer) // TODO: Remove heap allocations
        {
            var longBuffer = BitConverter.GetBytes(variable); 
            
            buffer.AddRange(longBuffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override long Deserialize(byte[] buffer, ref int index)
        {
            var value = BitConverter.ToInt64(buffer, index);
            index += 8;
            
            return value;
        }
    }
}