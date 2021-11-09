using System;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteByte(byte value)
        {
            TryResize(1);

            UnsafeWriteByte(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteBytes(byte[] value)
        {
            var length = 0;
            
            if (value != null)
            {
                length = value.Length;
            }
            
            if (length > 0)
            {
                TryResize(length);
            
                UnsafeWriteBytes(value, length);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UnsafeWriteByte(byte value)
        {
            _buffer[_count++] = value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UnsafeWriteBytes(byte[] value, int length)
        {
            Array.Copy(value, 0, _buffer, _count, length);
            
            _count += length;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte ReadByte()
        {
            return _buffer[_readIndex++];
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkipByte()
        {
            _readIndex++;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ReadBytes(int length)
        {
            var array = new byte[length];

            if (length > 0)
            {
                Array.Copy(_buffer, _readIndex, array, 0, length);

                _readIndex += length;
            }

            return array;
        }
        
        public void SkipBytes(int length)
        {
            _readIndex += length;
        }
    }
}