using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
    [TestFixture(Category = "SerializationStream Tests")]
    public class SerializationStreamFloatingPointTests
    {
        [Test]
        [TestCase(float.MinValue)]
        [TestCase(float.MaxValue)]
        [TestCase(0.00132f)]
        [TestCase(52835732f)]
        public void WriteAndRead_Float(float inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteFloat(inputValue);

                var outputValue = stream.ReadFloat();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }
                
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 4 && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 4);
                }
            });
        }
        
        [Test]
        [TestCase(0.1f, 2)]
        [TestCase(127.321f, 23)]
        [TestCase(255.0426f, 3)]
        public void WriteAndRead_Float_ManyTimes(float step, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new float[times];

                for (var i = 0; i < times; i++)
                {
                    var value = i + step;
                    
                    stream.WriteFloat(value);
                    equalityArray[i] = value;
                }
                
                for (var i = 0; i < times; i++)
                {
                    var byteValue = stream.ReadFloat();
                    var equalityValue = equalityArray[i];
                    
                    if (byteValue != equalityValue)
                    {
                        throw new InputAndOutputNotEqualException(byteValue, equalityValue);
                    }
                }
                
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 4 * equalityArray.Length && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 4 * equalityArray.Length);
                }
            });
        }
        
        [Test]
        [TestCase(float.MinValue)]
        [TestCase(float.MaxValue)]
        [TestCase(0.001322113d)]
        [TestCase(52835732.0312d)]
        public void WriteAndRead_Double(double inputValue)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

                stream.WriteDouble(inputValue);

                var outputValue = stream.ReadDouble();

                if (inputValue != outputValue)
                {
                    throw new InputAndOutputNotEqualException(inputValue, outputValue);
                }
                
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 8 && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 8);
                }
            });
        }
        
        [Test]
        [TestCase(0.00000321d, 2)]
        [TestCase(127.321d, 23)]
        [TestCase(255.0426d, 3)]
        public void WriteAndRead_Double_ManyTimes(double step, int times)
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
                var equalityArray = new double[times];

                for (var i = 0; i < times; i++)
                {
                    var value = i + step;
                    
                    stream.WriteDouble(value);
                    equalityArray[i] = value;
                }
                
                for (var i = 0; i < times; i++)
                {
                    var byteValue = stream.ReadDouble();
                    var equalityValue = equalityArray[i];
                    
                    if (byteValue != equalityValue)
                    {
                        throw new InputAndOutputNotEqualException(byteValue, equalityValue);
                    }
                }
                
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }

                if (stream.Capacity != 8 * equalityArray.Length && stream.Capacity != 1)
                {
                    throw new InvalidCapacitySizeException(stream.Capacity, 8 * equalityArray.Length);
                }
            });
        }
    }
}