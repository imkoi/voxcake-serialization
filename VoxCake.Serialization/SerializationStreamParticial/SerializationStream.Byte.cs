﻿using System;
using System.Runtime.CompilerServices;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteByte(byte value)
        {
            TryResize(1);
            
            _buffer[_count++] = value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteBytes(byte[] value)
        {
            var length = value.Length;

            if (length != 0)
            {
                TryResize(length);
            
                Array.Copy(value, 0, _buffer, _count, length);
            
                _count += length;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte ReadByte()
        {
            return _buffer[_readIndex++];
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ReadBytes(int length)
        {
            var array = new byte[length];

            if (length != 0)
            {
                Array.Copy(_buffer, _readIndex, array, 0, length);

                _readIndex += length;
            }

            return array;
        }
    }
}