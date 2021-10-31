using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class DoubleSerializer : Serializer<double>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(double variable, ref SerializationStream stream)
        {
            stream.WriteDouble(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override double Deserialize(ref SerializationStream stream)
        {
            return stream.ReadDouble();
        }
    }
}