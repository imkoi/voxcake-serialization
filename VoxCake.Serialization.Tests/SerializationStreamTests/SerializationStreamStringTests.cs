using NUnit.Framework;

namespace VoxCake.Serialization.Tests.SerializationStreamTests
{
	[TestFixture(Category = "SerializationStream Tests")]
	public class SerializationStreamStringTests
	{
		[Test]
		[TestCase("")]
		[TestCase("Hello World")]
		[TestCase("Проверка энкодинга :) NA?U?O")]
		public void WriteAndRead_String(string inputValue)
		{
			Assert.DoesNotThrow(() =>
			{
				var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);

				stream.WriteString(inputValue);

				var outputValue = stream.ReadString();
				
				if (!inputValue.Equals(outputValue))
				{
					throw new InputAndOutputNotEqualException(inputValue, outputValue);
				}
				
				if (!stream.IsEmpty)
				{
					throw new StreamIsNotEmptyException();
				}
			});
		}
	}
}