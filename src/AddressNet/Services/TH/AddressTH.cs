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

        /// <summary>
        /// Get address by contained words.
        /// </summary>
        /// <param name="Words">Words.</param>
        /// <returns>Address by contained words.</returns>
        public static IEnumerable<AddressThModel> GetByWords(string words) => _DataModel.Where(a => a.SubDistrict.Contains(words) || a.District.Contains(words) || a.Province.Contains(words));

        /// <summary>
        /// Get string array of address by contained words to string complete.
        /// </summary>
        /// <param name="Words">Words.</param>
        /// <returns>String array  by contained words to string complete.</returns>
        public static string[] GetByWordsToStringComplete(string words)
        {
            string[] res = new string[] { };
            IEnumerable<AddressThModel> data = _DataModel.Where(a => a.SubDistrict.Contains(words) || a.District.Contains(words) || a.Province.Contains(words));
            foreach (var item in data)
            {
                res = res.Append($"ตำบล {item.SubDistrict}, อำเภอ {item.District}, จังหวัด {item.Province}, รหัสไปรษณีย์ {item.PostalCode}").ToArray();
            }
            return res;
        }
    }
}
