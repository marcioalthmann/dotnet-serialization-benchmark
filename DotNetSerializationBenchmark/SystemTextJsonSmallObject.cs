using System.Text.Json;
using BenchmarkDotNet.Attributes;

namespace DotNetSerializationBenchmark
{
    [MemoryDiagnoser]
    public class SystemTextJsonSmallObject : Serializer<SmallObject, string>
    {
        [Benchmark]
        public override string Serialize()
        {
            return JsonSerializer.Serialize(GetCachedInstance());
        }

        [Benchmark]
        public override SmallObject Deserialize()
        {
            return JsonSerializer.Deserialize<SmallObject>(GetCachedSerializedInstance());
        }
    }
}