using System;
using NUnit.Framework;

namespace VoxCake.Serialization.Tests.Example
{
    [TestFixture(Category = "Example")]
    public class NetworkPacketUsageExample
    {
        [Test]
        [TestCase(4324234, (byte)23, (ulong)42345)]
        public void SendPacket(int protocolHash, byte packetId, ulong senderId)
        {
            var packet = new Packet();
            var timestamp = new DateTime().ToBinary();
            
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(16); // Setup initial capacity to avoid heap allocations
                
                stream.WriteInt32(protocolHash);
                stream.WriteByte(packetId);
                stream.WriteUInt64(senderId);
                stream.WriteInt64(timestamp);

                var sendBuffer = stream.ToArray();
                
                // For client: cause (37  bytes + array object alloc size) heap allocation
                // For network: send only 21 bytes + network protocol header
                
                packet = ReadPacket(sendBuffer);
            });
            
            Assert.True(packet.protocolHash == protocolHash);
            Assert.True(packet.packetId == packetId);
            Assert.True(packet.senderId == senderId);
            Assert.True(packet.timestamp == timestamp);
        }
        
        public Packet ReadPacket(byte[] receivedBuffer)
        {
            var output = new Packet();
            
            Assert.DoesNotThrow(() =>
            {
                var stream = SerializationStream.Create(receivedBuffer);

                var protocolHash = stream.ReadInt32();
                var packetId = stream.ReadByte();
                var senderId = stream.ReadUInt64();
                var timestamp = stream.ReadInt64();
                
                // there will be no heap allocations at all :)

                output = new Packet
                {
                    protocolHash = protocolHash,
                    packetId = packetId,
                    senderId = senderId,
                    timestamp = timestamp
                };
            });

            return output;
        }
    }
    
    public static class SerializationStreamCustomType
    {
        public static void WriteMyType(this ref SerializationStream stream, CustomType customType)
        {
            stream.WriteByte(customType.age);
            stream.WriteInt16(customType.money);
            stream.WriteInt64(customType.passion);
        }
        
        public static CustomType ReadMyType(this ref SerializationStream stream, CustomType customType)
        {
            return new CustomType
            {
                age = stream.ReadByte(),
                money = stream.ReadInt16(),
                passion = stream.ReadInt64()
            };
        }
    }
    
    public struct Packet
    {
        public int protocolHash;
        public byte packetId;
        public ulong senderId;
        public long timestamp;
    }
    
    public struct CustomType
    {
        public byte age;
        public short money;
        public long passion;
    }
}