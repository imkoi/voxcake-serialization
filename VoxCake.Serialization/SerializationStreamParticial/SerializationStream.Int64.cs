using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInt64(long value)
        {
            TryResize(8);
            
            _buffer[_count++] = (byte)((value >> 56) & 255);
            _buffer[_count++] = (byte)((value >> 48) & 255);
            _buffer[_count++] = (byte)((value >> 40) & 255);
            _buffer[_count++] = (byte)((value >> 32) & 255);
            _buffer[_count++] = (byte)((value >> 24) & 255);
            _buffer[_count++] = (byte)((value >> 16) & 255);
            _buffer[_count++] = (byte)((value >> 8) & 255);
            _buffer[_count++] = (byte)(value & 255);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteUInt64(ulong value)
        {
            TryResize(8);
            
            _buffer[_count++] = (byte)((value >> 56) & 255);
            _buffer[_count++] = (byte)((value >> 48) & 255);
            _buffer[_count++] = (byte)((value >> 40) & 255);
            _buffer[_count++] = (byte)((value >> 32) & 255);
            _buffer[_count++] = (byte)((value >> 24) & 255);
            _buffer[_count++] = (byte)((value >> 16) & 255);
            _buffer[_count++] = (byte)((value >> 8) & 255);
            _buffer[_count++] = (byte)(value & 255);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ReadInt64()
        {
            var num = _buffer[_readIndex++] << 24 | _buffer[_readIndex++] << 16 | _buffer[_readIndex++] << 8 | _buffer[_readIndex++];
            
            return (uint) (_buffer[_readIndex++] << 24 | _buffer[_readIndex++] << 16 | _buffer[_readIndex++] << 8) | _buffer[_readIndex++] | (long) num << 32;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong ReadUInt64()
        {
            var num = _buffer[_readIndex++] << 24 | _buffer[_readIndex++] << 16 | _buffer[_readIndex++] << 8 | _buffer[_readIndex++];
            
            return (ulong)((uint) (_buffer[_readIndex++] << 24 | _buffer[_readIndex++] << 16 | _buffer[_readIndex++] << 8) | _buffer[_readIndex++] | (long) num << 32);
        }
    }
}