using System;
using NUnit.Framework;

namespace VoxCake.Serialization.Tests
{
	[TestFixture]
	public class SerializationStreamTests
	{
		[Test]
		[TestCase(0)]
		[TestCase(127)]
		[TestCase(255)]
		public void WriteAndReadByte(byte inputValue)
		{
			var stream = SerializationStream.Create(0);

			stream.WriteByte(inputValue);

			var outputValue = stream.ReadByte();
			
			Assert.True(inputValue == outputValue);
		}
	
		[Test]
		[TestCase(new byte[] {})]
		[TestCase(new byte[] {0})]
		[TestCase(new byte[] {123, 32, 41, 9, 0, 255})]
		public void WriteAndReadBytes(byte[] inputValue)
		{
			var inputLength = inputValue.Length;
			var stream = SerializationStream.Create(0);

			stream.WriteBytes(inputValue);

			var outputValue = stream.ReadBytes(inputLength);
			
			Assert.DoesNotThrow(() =>
			{
				var shouldThrowException = false;
				var outputLength = outputValue.Length;

				if (inputLength == outputLength)
				{
					for (var i = 0; i < inputLength; i++)
					{
						if (inputValue[i] != outputValue[i])
						{
							shouldThrowException = true;
							
							break;
						}
					}
				}

				if (shouldThrowException)
				{
					throw new Exception("Value are not the same");
				}
			});
		}
		
		[Test]
		[TestCase('s')]
		[TestCase('!')]
		[TestCase('ц')]
		public void WriteAndReadChar(char inputValue)
		{
			var stream = SerializationStream.Create(0);

			stream.WriteChar(inputValue);

			var outputValue = stream.ReadChar();
			
			Assert.DoesNotThrow(() =>
			{
				if (inputValue != outputValue)
				{
					throw new Exception($"inputValue[{inputValue}] are not equal to outputValue[{outputValue}]");
				}
			});
		}
	}
}