using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class UShortSerializer : Serializer<ushort>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(ushort variable, ref SerializationStream stream)
        {
            stream.WriteUShort(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ushort Deserialize(ref SerializationStream stream)
        {
            return stream.ReadUShort();
        }
    }
}