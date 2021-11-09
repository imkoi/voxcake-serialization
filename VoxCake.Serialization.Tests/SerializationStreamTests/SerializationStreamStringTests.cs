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
		
		[Test]
		[TestCase("", 2)]
		[TestCase("Hello World", 4)]
		[TestCase("Проверка энкодинга :) NA?U?O", 11)]
		public void WriteAndRead_String_ManyTimes(string inputValue, int times)
		{
			Assert.DoesNotThrow(() =>
			{
				var stream = SerializationStream.Create(0, SerializationStream.ResizeMethodType.Count);
				var equalityArray = new string[times];

				for (var i = 0; i < times; i++)
				{
					stream.WriteString(inputValue);
					equalityArray[i] = inputValue;
				}

				for (var i = 0; i < times; i++)
				{
					var outputValue = stream.ReadString();

					if (outputValue != equalityArray[i])
					{
						throw new InputAndOutputNotEqualException(inputValue, outputValue);
					}
				}
				
				if (!stream.IsEmpty)
				{
					throw new StreamIsNotEmptyException();
				}
			});
		}
	}
}