using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ShortSerializer : Serializer<short>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(short variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override short Deserialize(byte[] buffer, ref int index)
        {
            var value = BitConverter.ToInt16(buffer, index);
            index += 2;

            return value;
        }
    }
}