using System.Collections.Generic;

namespace VoxCake.Serialization
{
    public abstract class Serializer<TType> : ISerializer //TODO: Remove boxing
    {
        public abstract void Serialize(TType variable, List<byte> buffer);
        public abstract TType Deserialize(byte[] buffer, ref int index);
        
        void ISerializer.Serialize(object variable, List<byte> buffer)
        {
            Serialize((TType)variable, buffer);
        }

        object ISerializer.Deserialize(byte[] buffer, ref int index)
        {
            return Deserialize(buffer, ref index);
        }
    }
}