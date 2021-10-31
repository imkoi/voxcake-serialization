using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class LongSerializer : Serializer<long>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(long variable, ref SerializationStream stream)
        {
            stream.WriteLong(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override long Deserialize(ref SerializationStream stream)
        {
            return stream.ReadLong();
        }
    }
}