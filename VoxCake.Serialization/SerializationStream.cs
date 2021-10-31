using System;

namespace VoxCake.Serialization
{
	public struct SerializationStream
	{
		private byte[] _buffer;
		private int _capacity;
		private int _count;
		
		private int _readIndex;

		private SerializationStream(int capacity)
		{
			_buffer = new byte[capacity];
			_capacity = capacity;
			_count = 0;

			_readIndex = 0;
		}

		private SerializationStream(byte[] buffer, int length)
		{
			_buffer = buffer;
			_capacity = length;
			_count = length;

			_readIndex = 0;
		}
		
		public static SerializationStream Create(int capacity)
		{
			if (capacity < 1)
			{
				capacity = 1;
			}
			
			return new SerializationStream(capacity);
		}

		public static SerializationStream Create(byte[] buffer)
		{
			return new SerializationStream(buffer, buffer.Length);
		}

		public void WriteByte(byte value)
		{
			_buffer[_count++] = value;
		}

		public void WriteBytes(byte[] value)
		{
			var length = value.Length;
			
			/*
			Array.Copy(value, _buffer, _count, value.Length);
			_count += length;
			*/
		}

		public void WriteChar(char value)
		{
			_buffer[_count++] = (byte)value;
		}
		
		public void WriteShort(short value)
		{
			/*
			_buffer[_writeIndex++] = (byte)(value & 0b_00000000_11111111);
			_buffer[_writeIndex++] = (byte)(value & 0b_11111111_00000000);
			*/
		}
		
		public void WriteUShort(ushort value)
		{
			/*
			_buffer[_writeIndex++] = (byte)(value & 0b_00000000_11111111);
			_buffer[_writeIndex++] = (byte)(value & 0b_11111111_00000000);
			*/
		}
		
		public void WriteInt(int value)
		{
			
		}

		public void WriteUInt(uint value)
		{
			
		}

		public void WriteLong(long value)
		{
			
		}

		public void WriteULong(ulong value)
		{
			
		}

		public void WriteFloat(float value)
		{
			
		}

		public void WriteDouble(double value)
		{
			
		}

		public void WriteString(string value)
		{
			var stringLength = value.Length;

			if (stringLength > 255)
			{
				throw new SerializationException("String is too big to be serialized! limit is 255 characters!");
			}
			
			WriteByte((byte)stringLength);
			
			for (var i = 0; i < stringLength; i++)
			{
				WriteByte((byte)value[i]); 
			}
		}

		public byte ReadByte()
		{
			return _buffer[_readIndex++];
		}

		public byte[] ReadBytes(int length)
		{
			var array = new byte[length];
			
			/*
			Array.Copy(value, _buffer, _count, value.Length);
			_count += length;*/

			return array;
		}
		
		public char ReadChar()
		{
			return (char)_buffer[_readIndex++];
		}

		public string ReadString()
		{
			/*
			var stringLength = _buffer[_readIndex++];
			BitConverter.GetBytes()
			for(var )*/
			
			return null;
		}

		public short ReadShort()
		{
			return default;
		}

		public ushort ReadUShort()
		{
			return default;
		}

		public long ReadLong()
		{
			return default;
		}

		public ushort ReadULong()
		{
			return default;
		}

		public int ReadInt()
		{
			return default;
		}

		public uint ReadUInt()
		{
			return default;
		}
		
		public float ReadFloat()
		{
			return default;
		}

		public double ReadDouble()
		{
			return default;
		}
	}
}