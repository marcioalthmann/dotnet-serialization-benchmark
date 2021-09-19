using System.IO;
using BenchmarkDotNet.Attributes;
using ProtoBuf;

namespace DotNetSerializationBenchmark
{
    [MemoryDiagnoser()]
    public class ProtobufSmallObject : Serializer<SmallObject, byte[]>
    {
        [Benchmark]
        public override byte[] Serialize()
        {
            using (var memoryStream = new MemoryStream())
            {
                Serializer.Serialize(memoryStream, GetCachedInstance());
                return memoryStream.ToArray();
            }
        }

        [Benchmark]
        public override SmallObject Deserialize()
        {
            using (var memoryStream = new MemoryStream(GetCachedSerializedInstance()))
            {
                return Serializer.Deserialize<SmallObject>(memoryStream);
            }
        }
    }
}