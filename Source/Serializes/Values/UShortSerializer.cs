using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class UShortSerializer : Serializer<ushort>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(ushort variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ushort Deserialize(byte[] buffer, ref int index)
        {
            var variable = BitConverter.ToUInt16(buffer, index);
            index += 2;

            return variable;
        }
    }
}