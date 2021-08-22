using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ULongSerializer : Serializer<ulong>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(ulong variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ulong Deserialize(byte[] buffer, ref int index)
        {
            var variable = BitConverter.ToUInt64(buffer, index);
            index += 8;

            return variable;
        }
    }
}