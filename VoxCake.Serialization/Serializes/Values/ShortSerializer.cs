using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class ShortSerializer : Serializer<short>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(short variable, ref SerializationStream stream)
        {
            stream.WriteShort(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override short Deserialize(ref SerializationStream stream)
        {
            return stream.ReadShort();
        }
    }
}