using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class FloatSerializer : Serializer<float>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(float variable, ref SerializationStream stream)
        {
            stream.WriteFloat(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override float Deserialize(ref SerializationStream stream)
        {
            return stream.ReadFloat();
        }
    }
}