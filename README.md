# VoxCake.Serialization
VoxCake.Serialization - framework for lightweight binary serialization.
This implementation trying to allocate low amount of garbage in heap - it should increase perfromance of your application.
```csharp
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
```

## Getting Started
1. Get latest [release](https://github.com/imkoi/voxcake-serialization/releases/tag/1.0) or built it yourself from source.
2. Add reference to assembly in your project.
3. Use it!

## Usage example
You can see example of usage [inside voxcake-serialization/VoxCake.Serialization.Tests/Example/](https://github.com/imkoi/voxcake-serialization/blob/main/VoxCake.Serialization.Tests/Example/UsageExample.cs)
