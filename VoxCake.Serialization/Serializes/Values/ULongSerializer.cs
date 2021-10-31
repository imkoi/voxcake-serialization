using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ULongSerializer : Serializer<ulong>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(ulong variable, ref SerializationStream stream)
        {
            stream.WriteULong(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override ulong Deserialize(ref SerializationStream stream)
        {
            return stream.ReadULong();
        }
    }
}