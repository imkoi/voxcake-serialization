using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
    [TestFixture(Category = "SerializationStream Tests")]
    public class SerializationStreamByteTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(127)]
        [TestCase(255)]
        public void WriteAndRead_Byte(byte inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteByte(inputValue);

                var outputValue = stream.ReadByte();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }

                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 1);
                }
            });
        }
        
        [Test]
        [TestCase(0, 2)]
        [TestCase(127, 0)]
        [TestCase(255, 3)]
        public void WriteAndRead_Byte_ManyTimes(int length, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new byte[length];

                for(var j = 0; j < times; j++)
                {
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = (byte)i;
                    
                        stream.WriteByte(byteValue);
                        equalityArray[i] = byteValue;
                    }
                
                    for (var i = 0; i < length; i++)
                    {
                        var byteValue = stream.ReadByte();
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

                if (stream.Capacity != length * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, length * times);
                }
            });
        }
        
        [Test]
        [TestCase(new byte[] { })]
        [TestCase(new byte[] {0})]
        [TestCase(new byte[] {123, 32, 41, 9, 0, 255})]
        public void WriteAndRead_Bytes(byte[] inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var inputLength = inputValue.Length;
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteBytes(inputValue);

                var outputValue = stream.ReadBytes(inputLength);
                
                var isInputNotEqualToOutput = false;
                var outputLength = outputValue.Length;

                if (inputLength == outputLength)
                {
                    for (var i = 0; i < inputLength; i++)
                    {
                        if (inputValue[i] != outputValue[i])
                        {
                            isInputNotEqualToOutput = true;

                            break;
                        }
                    }
                }

                if (isInputNotEqualToOutput)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }
                
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != inputLength && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, inputLength);
                }
            });
        }
        
        [Test]
        [TestCase(new byte[] { }, 0)]
        [TestCase(new byte[] {0}, 2)]
        [TestCase(new byte[] {123, 32, 41, 9, 0, 255}, 5)]
        public void WriteAndRead_Bytes_ManyTimes(byte[] inputValue, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var inputLength = inputValue.Length;
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                for (var j = 0; j < times; j++)
                {
                    for (var k = 0; k < times; k++)
                    {
                        stream.WriteBytes(inputValue);
                    }
                    
                    for (var k = 0; k < times; k++)
                    {
                        var outputValue = stream.ReadBytes(inputLength);
                        var outputLength = outputValue.Length;
                        var isInputNotEqualToOutput = false;

                        if (inputLength == outputLength)
                        {
                            for (var i = 0; i < inputLength; i++)
                            {
                                if (inputValue[i] != outputValue[i])
                                {
                                    isInputNotEqualToOutput = true;

                                    break;
                                }
                            }
                        }
                        
                        if (isInputNotEqualToOutput)
                        {
                            throw new InputAndOutputNotEqualException(inputValue, outputValue);
                        }
                    }
                }
                
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != inputLength * times * times && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, inputLength * times * times);
                }
            });
        }
    }
}