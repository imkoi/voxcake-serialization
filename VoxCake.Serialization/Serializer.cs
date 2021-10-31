namespace VoxCake.Serialization
{
    public abstract class Serializer<TType> : ISerializer
    {
        public abstract void Serialize(TType variable, ref SerializationStream stream);
        public abstract TType Deserialize(ref SerializationStream stream);
        
        void ISerializer.Serialize(object variable, ref SerializationStream stream)
        {
            Serialize((TType)variable, ref stream);
        }

        object ISerializer.Deserialize(ref SerializationStream stream)
        {
            return Deserialize(ref stream);
        }
    }
}