using BenchmarkDotNet.Attributes;
using MessagePack;

namespace DotNetSerializationBenchmark
{
    [MemoryDiagnoser()]
    public class MessagePackLZ4SmallObject : Serializer<SmallObject, byte[]>
    {
        private readonly MessagePackSerializerOptions options = MessagePackSerializerOptions.Standard
                                                                                            .WithCompression(MessagePackCompression.Lz4BlockArray);
        
        [Benchmark]
        public override byte[] Serialize()
        {
            return MessagePackSerializer.Serialize(GetCachedInstance(), options);
        }

        [Benchmark]
        public override SmallObject Deserialize()
        {
            return MessagePackSerializer.Deserialize<SmallObject>(GetCachedSerializedInstance(), options);
        }
    }
}
