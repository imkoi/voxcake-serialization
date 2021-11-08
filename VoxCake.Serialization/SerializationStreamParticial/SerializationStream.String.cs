using System.Runtime.CompilerServices;
using System.Text;

namespace VoxCake.Serialization
{
    public partial struct SerializationStream
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteString(string value)
        {
            var stringLength = value.Length;
            
            TryResize(Encoding.UTF8.GetMaxByteCount(stringLength) + 4);

            var bytesCount =  Encoding.UTF8.GetBytes(value, 0, stringLength,
                _buffer, _count + 4);

            WriteInt32(bytesCount);
            _count += bytesCount;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ReadString()
        {
            var stringLength = ReadInt32();

            var stringValue = Encoding.UTF8.GetString(_buffer, _readIndex, stringLength);

            _readIndex += stringLength;

            return stringValue;
        }
    }
}