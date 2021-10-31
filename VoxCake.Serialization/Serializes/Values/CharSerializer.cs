using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class CharSerializer : Serializer<char>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(char variable, ref SerializationStream stream)
        {
            stream.WriteChar(variable);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override char Deserialize(ref SerializationStream stream)
        {
            return stream.ReadChar();
        }
    }
}