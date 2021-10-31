namespace VoxCake.Serialization
{
    internal interface ISerializer
    {
        void Serialize(object variable, ref SerializationStream stream);
        object Deserialize(ref SerializationStream stream);
    }
}