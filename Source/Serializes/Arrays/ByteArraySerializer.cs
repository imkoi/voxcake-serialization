using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ByteArraySerializer : Serializer<byte[]>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(byte[] variable, List<byte> buffer)
        {
            var arrayLength = variable.Length;
            var bytes = BitConverter.GetBytes(arrayLength);
            
            buffer.AddRange(bytes);
            
            foreach (var element in variable)
            {
                buffer.Add(element);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override byte[] Deserialize(byte[] buffer, ref int index)
        {
            var length = BitConverter.ToInt32(buffer, index);
            index += 4;

            var array = new byte[length];
            for (var i = 0; i < length; i++)
            {
                array[i] = buffer[i + index];
            }

            return array;
        }
    }
}