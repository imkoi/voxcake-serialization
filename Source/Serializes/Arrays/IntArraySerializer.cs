using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class IntArraySerializer : Serializer<int[]>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(int[] variable, List<byte> buffer)
        {
            var arrayLength = variable.Length;
            var bytes = BitConverter.GetBytes(arrayLength);
            
            buffer.AddRange(bytes);
            
            foreach (var element in variable)
            {
                bytes = BitConverter.GetBytes(element);
                
                buffer.AddRange(bytes);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int[] Deserialize(byte[] buffer, ref int index)
        {
            var length = BitConverter.ToInt32(buffer, index);
            index += 4;

            var array = new int[length];
            for (var i = 0; i < length; i++)
            {
                var variable = BitConverter.ToInt32(buffer, i + index);

                array[i] = variable;
            }
            
            index += length * 4;

            return array;
        }
    }
}