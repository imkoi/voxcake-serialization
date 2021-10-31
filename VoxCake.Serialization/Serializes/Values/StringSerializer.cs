using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class StringSerializer : Serializer<string>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(string variable, ref SerializationStream stream)
        {
            stream.WriteString(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string Deserialize(ref SerializationStream stream)
        {
            return stream.ReadString();
        }
    }
}