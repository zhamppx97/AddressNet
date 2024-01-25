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
            result.Count().ShouldBeGreaterThan(100);
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
    }
}