using NUnit.Framework;

namespace VoxCake.Serialization.Tests
{
	[TestFixture]
	public class ByteSerializerTests
	{
		[Test]
		[TestCase(0)]
		[TestCase(127)]
		[TestCase(255)]
		public void SerializeTest(byte inputValue)
		{
			var serializer = new ByteSerializer();
			var stream = SerializationStream.Create(0);

			serializer.Serialize(inputValue, ref stream);

			var outputValue = serializer.Deserialize(ref stream);
			
			Assert.True(inputValue == outputValue);
		}
	}
}