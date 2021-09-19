using System;
using MessagePack;
using ProtoBuf;

namespace DotNetSerializationBenchmark
{
    [ProtoContract]
    [MessagePackObject()]
    public class SmallObject
    {
        [ProtoMember(1)] [Key(0)] public int IntegerProperty { get; set; }

        [ProtoMember(2)] [Key(1)] public string StringProperty { get; set; }

        public SmallObject()
        {
            IntegerProperty = Environment.TickCount;
            StringProperty = Guid.NewGuid().ToString();
        }
    }
}