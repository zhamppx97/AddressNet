using AddressNet.Services.TH;
using Shouldly;

namespace AddressNet.Tests
{
    public class AddressNetServiceTests
    {
        [Fact]
        public void GetAllAddress_Should_Return_List()
        {
            var result = AddressTH.GetAllAddress().ToList();
            result.ShouldNotBeEmpty();
            result.Count().ShouldBeGreaterThan(500);
        }

        [Fact]
        public void GetByPostalCode_Should_Return_Corrected_Address()
        {
            var result = AddressTH.GetByPostalCode(10100).ToList();
            result.ShouldNotBeEmpty();
            result.ShouldContain(a => a.SubDistrict.Equals("วัดเทพศิรินทร์"));
            // wrong case
            result = AddressTH.GetByPostalCode(99999).ToList();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void GetByWords_Should_Return_Corrected_Address()
        {
            var result = AddressTH.GetByWords("กรุงเทพ").ToList();
            result.ShouldNotBeEmpty();
            result.ShouldContain(a => a.Province.Contains("กรุงเทพ"));
            // wrong case
            result = AddressTH.GetByWords("ทดสอบ").ToList();
            result.ShouldBeEmpty();
        }

        [Fact]
        public void GetByWordsToStringComplete_Should_Return_Corrected_Address()
        {
            var result = AddressTH.GetByWordsToStringComplete("บ้านไผ่");
            result.ShouldNotBeEmpty();
            result[0].ShouldContain("บ้านไผ่");
        }
    }
}