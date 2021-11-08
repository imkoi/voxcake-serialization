using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
    [TestFixture(Category = "SerializationStream Tests")]
    public class SerializationStreamUInt64Tests
    {
        [Test]
        [TestCase(long.MinValue)]
        [TestCase(long.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        [TestCase(short.MinValue)]
        [TestCase(short.MaxValue)]
        [TestCase(2141252)]
        [TestCase(-32534534)]
        public void WriteAndRead_Int64(long inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteInt64(inputValue);

                var outputValue = stream.ReadInt64();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 8)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 8);
                }
            });
        }
        
        [Test]
        [TestCase(13, 2)]
        [TestCase(0, 5)]
        [TestCase(542, 3)]
        public void WriteAndRead_Int64_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new long[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = i;
                    
                        stream.WriteInt64(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadInt64();
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

                if (stream.Capacity != 8 * length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 8 * length * times);
                }
            });
        }
        
        [Test]
        [TestCase(ulong.MinValue)]
        [TestCase(ulong.MaxValue)]
        [TestCase((ulong)int.MaxValue)]
        [TestCase((ulong)uint.MaxValue)]
        [TestCase((ulong)short.MaxValue)]
        [TestCase((ulong)ushort.MaxValue)]
        [TestCase((ulong)32534534)]
        public void WriteAndRead_UInt64(ulong inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteUInt64(inputValue);

                var outputValue = stream.ReadUInt64();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 8)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 8);
                }
            });
        }
        
        [Test]
        [TestCase(13, 2)]
        [TestCase(0, 5)]
        [TestCase(542, 3)]
        public void WriteAndRead_UInt64_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new ulong[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = (uint)i;
                    
                        stream.WriteUInt64(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadUInt64();
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

                if (stream.Capacity != 8 * length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 8 * length * times);
                }
            });
        }
    }
}