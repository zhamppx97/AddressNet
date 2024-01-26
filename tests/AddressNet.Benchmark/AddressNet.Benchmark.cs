using AddressNet.Models.TH;
using AddressNet.Services.TH;
using BenchmarkDotNet.Attributes;

namespace AddressNet.Benchmark
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [MediumRunJob]
    public class AddressNetServiceBenchmark
    {

        [Benchmark]
        public List<AddressThModel> GetAllAddress() => AddressTH.GetAllAddress().ToList();

        [Benchmark]
        public List<AddressThModel> GetByPostalCode() => AddressTH.GetByPostalCode(10110).ToList();

        [Benchmark]
        public List<AddressThModel> GetByWords() => AddressTH.GetByWords("กรุงเทพ").ToList();

        [Benchmark]
        public string[] GetByWordsToStringComplete() => AddressTH.GetByWordsToStringComplete("บ้านไผ่");
    }
}
