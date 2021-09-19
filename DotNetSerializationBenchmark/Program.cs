using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace DotNetSerializationBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly,
                ManualConfig
                    .Create(DefaultConfig.Instance)
                    .With(ConfigOptions.JoinSummary)
                    .With(ConfigOptions.DisableLogFile));
        }
    }
}