using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ByteSerializer : Serializer<byte>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(byte variable, ref SerializationStream stream)
        {
            stream.WriteByte(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override byte Deserialize(ref SerializationStream stream)
        {
            var value = stream.ReadByte();

            return value;
        }
    }
}