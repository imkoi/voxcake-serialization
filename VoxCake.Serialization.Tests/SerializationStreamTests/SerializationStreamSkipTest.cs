using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
    [TestFixture]
    public class SerializationStreamSkipTest
    {
        [Test]
        public void WriteEverythingAndSkip()
        {
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(0);
            
                stream.WriteByte(0);
                stream.WriteDouble(0323);
                stream.WriteFloat(32);
                stream.WriteInt16(32);
                stream.WriteInt32(32);
                stream.WriteInt64(42);
                stream.WriteUInt16(32);
                stream.WriteUInt32(32);
                stream.WriteUInt64(42);
                stream.WriteString("HI ZYABLS!");
            
                stream.SkipByte();
                stream.SkipDouble();
                stream.SkipFloat();
                stream.SkipInt16();
                stream.SkipInt32();
                stream.SkipInt64();
                stream.SkipUInt16();
                stream.SkipUInt32();
                stream.SkipUInt64();
                stream.SkipString();
				
                if (!stream.IsEmpty)
                {
                    throw new StreamIsNotEmptyException();
                }
            });
        }
    }
}