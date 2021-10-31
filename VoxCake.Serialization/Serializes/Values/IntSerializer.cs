using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class IntSerializer : Serializer<int>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(int variable, ref SerializationStream stream)
        {
            stream.WriteInt(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int Deserialize(ref SerializationStream stream)
        {
            return stream.ReadInt();
        }
    }
}