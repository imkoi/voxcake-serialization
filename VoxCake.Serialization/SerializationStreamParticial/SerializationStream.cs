using System;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
	public partial struct SerializationStream
	{
		public enum ResizeMethodType
		{
			DoubleOfCount = 0,
			Count = 1,
		}

		public int Capacity => _capacity;
		public bool IsEmpty => _readIndex == _count;
		
		private byte[] _buffer;
		private int _capacity;
		private int _count;
		private int _resizeMethodValue;
		
		private int _readIndex;

		private SerializationStream(int capacity, ResizeMethodType resizeMethod)
		{
			_buffer = new byte[capacity];
			_capacity = capacity;
			_count = 0;
			_resizeMethodValue = (int)resizeMethod;

			_readIndex = 0;
		}

		private SerializationStream(byte[] buffer, int length, ResizeMethodType resizeMethod)
		{
			_buffer = buffer;
			_capacity = length;
			_count = length;
			_resizeMethodValue = (int)resizeMethod;

			_readIndex = 0;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SerializationStream Create(int capacity, ResizeMethodType resizeMethod = ResizeMethodType.DoubleOfCount)
		{
			if (capacity < 1)
			{
				capacity = 1;
			}
			
			return new SerializationStream(capacity, resizeMethod);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SerializationStream Create(byte[] buffer, ResizeMethodType resizeMethod = ResizeMethodType.DoubleOfCount)
		{
			return new SerializationStream(buffer, buffer.Length, resizeMethod);
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryResize(int length)
		{
			var currentCount = _count;
			var enlargedCount = currentCount + length;
			var shouldResize = enlargedCount > _capacity;

			if (shouldResize)
			{
				var multiplyValue = _resizeMethodValue == 0 ? 2 : 1;
				var enlargedBufferLength = enlargedCount * multiplyValue;
				var enlargedBuffer = new byte[enlargedBufferLength];
				
				Array.Copy(_buffer, enlargedBuffer, currentCount);

				_buffer = enlargedBuffer;
				_capacity = enlargedBufferLength;
			}

			return shouldResize;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte[] ToArray()
		{
			var output = new byte[_count];
			
			Array.Copy(_buffer, output, _count);

			return output;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear()
		{
			_count = 0;
			_readIndex = 0;
		}
	}
}