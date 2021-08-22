using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class IntSerializer : Serializer<int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(int variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int Deserialize(byte[] buffer, ref int index)
        {
            var value = BitConverter.ToInt32(buffer, index);
            index += 4;

            return value;
        }
    }
}