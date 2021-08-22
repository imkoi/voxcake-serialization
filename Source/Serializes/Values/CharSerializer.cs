using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class CharSerializer : Serializer<char>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(char variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override char Deserialize(byte[] buffer, ref int index)
        {
            var value = BitConverter.ToChar(buffer, index);
            index += 1;

            return value;
        }
    }
}