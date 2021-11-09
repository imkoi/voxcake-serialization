using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInt16(short value)
        {
            TryResize(2);
            
            UnsafeWriteInt16(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteUInt16(ushort value)
        {
            TryResize(2);
            
            UnsafeWriteUInt16(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UnsafeWriteInt16(short value)
        {
            _buffer[_count++] = (byte)((value >> 8) & 255);
            _buffer[_count++] = (byte)(value & 255);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UnsafeWriteUInt16(ushort value)
        {
            _buffer[_count++] = (byte)((value >> 8) & 255);
            _buffer[_count++] = (byte)(value & 255);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short ReadInt16()
        {
            return (short)((_buffer[_readIndex++] << 8) | _buffer[_readIndex++]);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort ReadUInt16()
        {
            return (ushort)((_buffer[_readIndex++] << 8) | _buffer[_readIndex++]);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkipInt16()
        {
            _readIndex += 2;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkipUInt16()
        {
            _readIndex += 2;
        }
    }
}