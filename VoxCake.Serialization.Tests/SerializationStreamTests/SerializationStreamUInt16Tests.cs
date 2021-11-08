using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
    [TestFixture(Category = "SerializationStream Tests")]
    public class SerializationStreamUInt16Tests
    {
        [Test]
        [TestCase(short.MinValue)]
        [TestCase(short.MaxValue)]
        [TestCase(2141)]
        [TestCase(-32534)]
        public void WriteAndRead_Int16(short inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteInt16(inputValue);

                var outputValue = stream.ReadInt16();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 2)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 2);
                }
            });
        }
        
        [Test]
        [TestCase(13, 2)]
        [TestCase(0, 5)]
        [TestCase(542, 3)]
        public void WriteAndRead_Int16_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new short[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = (short)i;
                    
                        stream.WriteInt16(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadInt16();
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

                if (stream.Capacity != 2 * length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 2 * length * times);
                }
            });
        }
        
        [Test]
        [TestCase(ushort.MinValue)]
        [TestCase(ushort.MaxValue)]
        [TestCase((ushort)32)]
        [TestCase((ushort)32511)]
        public void WriteAndRead_UInt16(ushort inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteUInt16(inputValue);

                var outputValue = stream.ReadUInt16();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 2)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 2);
                }
            });
        }
        
        [Test]
        [TestCase(13, 2)]
        [TestCase(0, 5)]
        [TestCase(542, 3)]
        public void WriteAndRead_UInt16_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new ushort[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = (ushort)i;
                    
                        stream.WriteUInt16(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadUInt16();
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

                if (stream.Capacity != 2 * length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 2 * length * times);
                }
            });
        }
    }
}