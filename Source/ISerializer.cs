using System.Collections.Generic;

namespace VoxCake.Serialization
{
    internal interface ISerializer
    {
        void Serialize(object variable, List<byte> buffer);
        object Deserialize(byte[] buffer, ref int index);
    }
}