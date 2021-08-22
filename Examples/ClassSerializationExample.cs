using System.Collections.Generic;

namespace VoxCake.Serialization
{
    internal class ClassSerializationExample
    {
        public void Main()
        {
            var serializationController = new SerializationController();
            var stringSerializer = serializationController.GetTypeSerializer<string>();
            var intSerializer = serializationController.GetTypeSerializer<int>();
            var personSerializer = new PersonSerializator(stringSerializer, intSerializer);
            
            serializationController.AddSerializer(personSerializer);

            var serializablePersonBuffer = new List<byte>(); 
            
            serializationController.Serialize(new Person
            {
                Name = "Artem",
                Surname = "Svirid",
                Age = 20,
            }, serializablePersonBuffer);

            var index = 0;
            
            var person = serializationController.Deserialize<Person>(serializablePersonBuffer.ToArray(), ref index);
        }
    }

    internal class Person
    {
        public string Name;
        public string Surname;
        public int Age;
    }

    internal class PersonSerializator : Serializer<Person>
    {
        private readonly Serializer<string> _stringSerializer;
        private readonly Serializer<int> _intSerializer;

        public PersonSerializator(Serializer<string> stringSerializer, Serializer<int> intSerializer)
        {
            _stringSerializer = stringSerializer;
            _intSerializer = intSerializer;
        }

        public override void Serialize(Person variable, List<byte> buffer)
        {
            _stringSerializer.Serialize(variable.Name, buffer);
            _stringSerializer.Serialize(variable.Surname, buffer);
            _intSerializer.Serialize(variable.Age, buffer);
        }

        public override Person Deserialize(byte[] buffer, ref int index)
        {
            var name = _stringSerializer.Deserialize(buffer, ref index);
            var surname = _stringSerializer.Deserialize(buffer, ref index);
            var age = _intSerializer.Deserialize(buffer, ref index);

            return new Person
            {
                Name = name,
                Surname = surname,
                Age = age
            };
        }
    }
}