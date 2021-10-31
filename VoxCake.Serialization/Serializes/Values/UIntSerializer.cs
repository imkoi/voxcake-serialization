using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class UIntSerializer : Serializer<uint>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(uint variable, ref SerializationStream stream)
        {
            stream.WriteUInt(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override uint Deserialize(ref SerializationStream stream)
        {
            return stream.ReadUInt();
        }
    }
}