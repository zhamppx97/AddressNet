using AddressNet.Models.TH;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace AddressNet.Services.TH
{
    public static class AddressTH
    {
        private const string DataPath = "AddressNet.Services.TH.address.json";
        private static readonly IEnumerable<AddressThModel> _DataModel;

        static AddressTH()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream(DataPath);
            _DataModel = stream != null ? JsonSerializer.Deserialize<IEnumerable<AddressThModel>>(new StreamReader(stream).ReadToEnd()) : throw new Exception();
        }

        /// <summary>
        /// Get all address.
        /// </summary>
        /// <returns>All address.</returns>
        public static IEnumerable<AddressThModel> GetAllAddress() => _DataModel;

        /// <summary>
        /// Get address by postal code.
        /// </summary>
        /// <param name="PostalCode">Postal code.</param>
        /// <returns>Address by postal code.</returns>
        public static IEnumerable<AddressThModel> GetByPostalCode(int postalCode) => _DataModel.Where(a => a.PostalCode == postalCode);
    }
}
