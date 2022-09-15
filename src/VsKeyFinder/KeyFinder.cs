using Microsoft.Win32;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace VsKeyFinder
{
    internal class KeyFinder
    {
        internal string FindKey(Product product)
        {
            var encryptedKey = Registry.GetValue($"HKEY_CLASSES_ROOT\\Licenses\\{product.Guid}\\{product.Code}", "", null);

            if (encryptedKey == null)
                return "";

            try
            {
                var data = ProtectedData.Unprotect((byte[])encryptedKey, null, DataProtectionScope.CurrentUser);
                var UnicodeString = new UnicodeEncoding().GetString(data);
                var key = "";
                foreach (var sub in UnicodeString.Split('\0'))
                {
                    var result = Regex.Match(sub, @"\w{5}-\w{5}-\w{5}-\w{5}-\w{5}");
                    if (result.Success)
                    {
                        key = $"{result.Value}";
                    }
                }
                return key;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
