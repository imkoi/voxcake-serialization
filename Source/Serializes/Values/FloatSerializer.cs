using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class FloatSerializer : Serializer<float>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(float variable, List<byte> buffer) // TODO: Remove heap allocations
        {
            var floatBuffer = BitConverter.GetBytes(variable);
            
            buffer.AddRange(floatBuffer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override float Deserialize(byte[] buffer, ref int index)
        {
            var value = BitConverter.ToSingle(buffer, index);
            index += 4;

            return value;
        }
    }
}