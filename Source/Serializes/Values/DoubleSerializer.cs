using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class DoubleSerializer : Serializer<double>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(double variable, List<byte> buffer)
        {
            var bytes = BitConverter.GetBytes(variable);
            
            buffer.AddRange(bytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override double Deserialize(byte[] buffer, ref int index)
        {
            var variable = BitConverter.ToDouble(buffer, index);
            index += 8;

            return variable;
        }
    }
}