using BenchmarkDotNet.Attributes;
using MessagePack;

namespace DotNetSerializationBenchmark
{
    [MemoryDiagnoser()]
    public class MessagePackSmallObject : Serializer<SmallObject, byte[]>
    {
        [Benchmark]
        public override byte[] Serialize()
        {
            return MessagePackSerializer.Serialize(GetCachedInstance());
        }

        [Benchmark]
        public override SmallObject Deserialize()
        {
            return MessagePackSerializer.Deserialize<SmallObject>(GetCachedSerializedInstance());
        }
    }
}