using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace DotNetSerializationBenchmark
{
    [MemoryDiagnoser]
    public class NewtonsoftSmallObject : Serializer<SmallObject, string>
    {
        [Benchmark]
        public override string Serialize()
        {
            return JsonConvert.SerializeObject(GetCachedInstance());
        }

        [Benchmark]
        public override SmallObject Deserialize()
        {
            return JsonConvert.DeserializeObject<SmallObject>(GetCachedSerializedInstance());
        }
    }
}