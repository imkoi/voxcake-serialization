using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInt32(int value)
        {
            TryResize(4);
            
            _buffer[_count++] = (byte)((value >> 24) & 255);
            _buffer[_count++] = (byte)((value >> 16) & 255);
            _buffer[_count++] = (byte)((value >> 8) & 255);
            _buffer[_count++] = (byte)(value & 255);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteUInt32(uint value)
        {
            TryResize(4);
            
            _buffer[_count++] = (byte)((value >> 24) & 255);
            _buffer[_count++] = (byte)((value >> 16) & 255);
            _buffer[_count++] = (byte)((value >> 8) & 255);
            _buffer[_count++] = (byte)(value & 255);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ReadInt32()
        {
            return (_buffer[_readIndex++] << 24) | (_buffer[_readIndex++] << 16) | (_buffer[_readIndex++] << 8) | _buffer[_readIndex++];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint ReadUInt32()
        {
            return (uint)((_buffer[_readIndex++] << 24) | (_buffer[_readIndex++] << 16) | (_buffer[_readIndex++] << 8) | _buffer[_readIndex++]);
        }
    }
}