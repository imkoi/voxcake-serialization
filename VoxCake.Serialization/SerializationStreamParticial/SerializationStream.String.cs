using System.Runtime.CompilerServices;
using System.Text;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteString(string value)
        {
            var stringLength = 0;

            if (value != null)
            {
                stringLength = value.Length;
            }
            
            TryResize(Encoding.UTF8.GetMaxByteCount(stringLength) + 4);

            if (stringLength > 0)
            {
                var bytesCount =  Encoding.UTF8.GetBytes(value, 0, stringLength,
                    _buffer, _count + 4);
                
                UnsafeWriteInt32(bytesCount);
                _count += bytesCount;
            }
            else
            {
                UnsafeWriteInt32(stringLength);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ReadString()
        {
            var stringLength = ReadInt32();

            if (stringLength > 0)
            {
                var stringValue = Encoding.UTF8.GetString(_buffer, _readIndex, stringLength);
                
                _readIndex += stringLength;

                return stringValue;
            }
            
            return string.Empty;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SkipString()
        {
            var stringLength = ReadInt32();
            
            _readIndex += stringLength;
        }
    }
}