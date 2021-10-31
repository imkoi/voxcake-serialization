using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    /// <summary>
    /// Default serializer, it always located inside SerializationController
    /// </summary>
    public class IntArraySerializer : Serializer<int[]>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override void Serialize(int[] variable, ref SerializationStream stream)
        {
            var length = variable.Length;
            stream.WriteInt(length);
            
            for (var i = 0; i < length; i++)
            {
                stream.WriteInt(variable[i]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int[] Deserialize(ref SerializationStream stream)
        {
            var length = stream.ReadInt();
            var array = new int[length];
            
            for (var i = 0; i < length; i++)
            {
                var element = stream.ReadInt();

                array[i] = element;
            }
            
            return array;
        }
    }
}