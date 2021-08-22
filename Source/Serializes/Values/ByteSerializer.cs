using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ByteSerializer : Serializer<byte>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(byte variable, List<byte> buffer) // TODO: Remove heap allocations
        {
            buffer.Add(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override byte Deserialize(byte[] buffer, ref int index)
        {
            var value = buffer[index];
            index++;

            return value;
        }
    }
}