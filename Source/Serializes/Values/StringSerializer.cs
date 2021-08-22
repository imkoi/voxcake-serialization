using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class StringSerializer : Serializer<string>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(string variable, List<byte> buffer) // TODO: Remove heap allocations
        {
            var strBytes = Encoding.ASCII.GetBytes(variable);
            var strLengthBytes = BitConverter.GetBytes(strBytes.Length);
            
            buffer.AddRange(strLengthBytes);
            buffer.AddRange(strBytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string Deserialize(byte[] buffer, ref int index)
        {
            var strLength = BitConverter.ToInt32(buffer, index);
            index += 4;
            var value = Encoding.ASCII.GetString(buffer, index, strLength);
            index += strLength;
            
            return value;
        }
    }
}