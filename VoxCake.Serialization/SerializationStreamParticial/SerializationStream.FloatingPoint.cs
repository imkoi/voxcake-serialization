using System;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteFloat(float value)
        {
            TryResize(4);
            
            UnsafeWriteFloat(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteDouble(double value)
        {
            TryResize(8);

            UnsafeWriteDouble(value);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UnsafeWriteFloat(float value)
        {
            Array.Copy(BitConverter.GetBytes(value), 0,
                _buffer, _count, 4);
            
            _count += 4;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void UnsafeWriteDouble(double value)
        {
            Array.Copy(BitConverter.GetBytes(value), 0,
                _buffer, _count, 8);
            
            _count += 8;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ReadFloat()
        {
            var output = BitConverter.ToSingle(_buffer, _readIndex);

            _readIndex += 4;
            
            return output;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ReadDouble()
        {
            var output = BitConverter.ToDouble(_buffer, _readIndex);

            _readIndex += 8;
            
            return output;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkipFloat()
        {
            _readIndex += 4;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkipDouble()
        {
            _readIndex += 8;
        }
    }
}