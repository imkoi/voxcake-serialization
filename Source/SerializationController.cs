using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public class SerializationController : ISerializationController
    {
        private readonly Dictionary<Type, ISerializer> _serializers;

        public SerializationController()
        {
            _serializers = new Dictionary<Type, ISerializer>();
            
            AddSerializer(new ByteSerializer());
            AddSerializer(new CharSerializer());
            AddSerializer(new UShortSerializer());
            AddSerializer(new ShortSerializer());
            AddSerializer(new UIntSerializer());
            AddSerializer(new IntSerializer());
            AddSerializer(new ULongSerializer());
            AddSerializer(new LongSerializer());
            AddSerializer(new FloatSerializer());
            AddSerializer(new DoubleSerializer());
            
            AddSerializer(new StringSerializer());
            AddSerializer(new ByteArraySerializer());
            AddSerializer(new IntArraySerializer());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddSerializer<TType>(Serializer<TType> serializer)
        {
            var variableType = typeof(TType);

            if (!_serializers.ContainsKey(variableType))
            {
                _serializers.Add(variableType, serializer);
            }
            else
            {
                throw new Exception($"Serializator already contains serializer for {variableType.Name} type!");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveTypeSerializer<TVariable>()
        {
            var variableType = typeof(TVariable);

            RemoveTypeSerializer(variableType);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveTypeSerializer(Type variableType)
        {
            if (_serializers.ContainsKey(variableType))
            {
                _serializers.Remove(variableType);
            }
            else
            {
                throw new Exception($"Serializator does not contains serializer for {variableType.Name} type!");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Serializer<TType> GetTypeSerializer<TType>()
        {
            var variableType = typeof(TType);

            if (_serializers.ContainsKey(variableType))
            {
                return (Serializer<TType>) _serializers[variableType];
            }
            
            throw new Exception($"Serializator does not contains serializer for {variableType.Name} type!");
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T Deserialize<T>(byte[] buffer, ref int index)
        {
            var variableType = typeof(T);

            return (T) Deserialize(variableType, buffer, ref index);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object Deserialize(Type variableType, byte[] buffer, ref int index)
        {
            var serializer = _serializers[variableType];
            
            return serializer.Deserialize(buffer, ref index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Serialize<T>(T variable, List<byte> buffer)
        {
            var variableType = variable.GetType();
            
            Serialize(variableType, variable, buffer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Serialize(Type variableType, object variable, List<byte> buffer)
        {
            var serializer = _serializers[variableType];
            
            serializer.Serialize(variable, buffer);
        }
    }
}