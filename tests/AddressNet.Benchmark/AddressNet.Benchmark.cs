using AddressNet.Models.TH;
using AddressNet.Services.TH;
using BenchmarkDotNet.Attributes;

namespace AddressNet.Benchmark
{
    [MemoryDiagnoser]
    [MediumRunJob]
    public class AddressNetServiceBenchmark
    {

        [Benchmark]
        public List<AddressThModel> GetAllAddress() => AddressTH.GetAllAddress().ToList();
    }
}
