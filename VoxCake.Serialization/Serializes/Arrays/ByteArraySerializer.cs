using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ByteArraySerializer : Serializer<byte[]>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(byte[] variable, ref SerializationStream stream)
        {
            stream.WriteInt(variable.Length);
            stream.WriteBytes(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override byte[] Deserialize(ref SerializationStream stream)
        {
            var length = stream.ReadInt();
            return stream.ReadBytes(length);
        }
    }
}