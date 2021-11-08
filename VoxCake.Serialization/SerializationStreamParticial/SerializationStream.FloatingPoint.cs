using System;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        /// <summary>
        /// Current implementation of WriteFloat method allocate 4 bytes in heap by using BitConverter.GetBytes
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteFloat(float value)
        {
            TryResize(4);

            var bytes = BitConverter.GetBytes(value);
            
            Array.Copy(bytes, 0,
                _buffer, _count, 4);
            
            _count += 4;
        }
        
        /// <summary>
        /// Current implementation of WriteDouble method allocate 8 bytes in heap by using BitConverter.GetBytes
        /// </summary>
        /// <param name="value"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteDouble(double value)
        {
            TryResize(8);
            
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
    }
}