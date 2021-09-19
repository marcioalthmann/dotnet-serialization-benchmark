namespace DotNetSerializationBenchmark
{
    public abstract class Serializer<ObjectType, SerializedObjectType> where ObjectType : class, new()
    {
        private readonly ObjectType _objectInstance;
        private readonly SerializedObjectType _serializedObjectInstance;

        protected Serializer()
        {
            _objectInstance = new ObjectType();
            _serializedObjectInstance = CacheSerializedInstance();
        }

        public abstract SerializedObjectType Serialize();

        public abstract ObjectType Deserialize();

        private SerializedObjectType CacheSerializedInstance()
        {
            return Serialize();
        }

        protected ObjectType GetCachedInstance()
        {
            return _objectInstance;
        }

        protected SerializedObjectType GetCachedSerializedInstance()
        {
            return _serializedObjectInstance;
        }
    }
}