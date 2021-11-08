using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
    [TestFixture(Category = "SerializationStream Tests")]
    public class SerializationStreamUInt32Tests
    {
        [Test]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(2141252)]
        [TestCase(-32534534)]
        public void WriteAndRead_Int32(int inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteInt32(inputValue);

                var outputValue = stream.ReadInt32();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 4)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 4);
                }
            });
        }
        
        [Test]
        [TestCase(13, 2)]
        [TestCase(0, 5)]
        [TestCase(542, 3)]
        public void WriteAndRead_Int32_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new int[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = i;
                    
                        stream.WriteInt32(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadInt32();
                        var equalityValue = equalityArray[i];
                    
                        if (byteValue != equalityValue)
                        {
                            throw new InputAndOutputNotEqualException(byteValue, equalityValue);
                        }
                    }
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 4 * length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 4 * length * times);
                }
            });
        }
        
        [Test]
        [TestCase(uint.MinValue)]
        [TestCase(uint.MaxValue)]
        [TestCase((uint)0)]
        [TestCase((uint)32534534)]
        public void WriteAndRead_UInt32(uint inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteUInt32(inputValue);

                var outputValue = stream.ReadUInt32();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 4)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 4);
                }
            });
        }
        
        [Test]
        [TestCase(13, 2)]
        [TestCase(0, 5)]
        [TestCase(542, 3)]
        public void WriteAndRead_UInt32_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new uint[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = (uint)i;
                    
                        stream.WriteUInt32(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadUInt32();
                        var equalityValue = equalityArray[i];
                    
                        if (byteValue != equalityValue)
                        {
                            throw new InputAndOutputNotEqualException(byteValue, equalityValue);
                        }
                    }
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 4 * length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 4 * length * times);
                }
            });
        }
    }
}