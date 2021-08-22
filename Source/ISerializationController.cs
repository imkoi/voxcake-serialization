using System;
using System.Collections.Generic;

namespace VoxCake.Serialization
{
    public interface ISerializationController
    {
        void AddSerializer<TType>(Serializer<TType> serializer);
        void RemoveTypeSerializer<TType>();
        void RemoveTypeSerializer(Type variableType);
        Serializer<TType> GetTypeSerializer<TType>();

        T Deserialize<T>(byte[] buffer, ref int index);
        object Deserialize(Type variableType, byte[] buffer, ref int index);
        
        void Serialize<T>(T variable, List<byte> buffer);
        void Serialize(Type variableType, object variable, List<byte> buffer);
    }
}