using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class UIntSerializer : Serializer<uint>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(uint variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override uint Deserialize(byte[] buffer, ref int index)
        {
            var variable = BitConverter.ToUInt32(buffer, index);
            index += 4;

            return variable;
        }
    }
}