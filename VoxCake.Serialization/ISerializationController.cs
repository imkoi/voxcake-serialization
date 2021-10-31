using System;

namespace VoxCake.Serialization
{
    public interface ISerializationController
    {
        void AddSerializer<TType>(Serializer<TType> serializer);
        void RemoveTypeSerializer<TType>();
        void RemoveTypeSerializer(Type variableType);
        Serializer<TType> GetTypeSerializer<TType>();

        T Deserialize<T>(ref SerializationStream stream);
        object Deserialize(Type variableType, ref SerializationStream stream);
        
        void Serialize<T>(T variable, ref SerializationStream stream);
        void Serialize(Type variableType, object variable, ref SerializationStream stream);
    }
}