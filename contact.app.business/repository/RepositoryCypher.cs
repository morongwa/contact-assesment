using System;
using System.Security.Cryptography;

namespace contact.app.business.repository
{
    public static class RepositoryCypher
    {

        public static string Encrypt(string sTextToEncrypt)
        {
            if (string.IsNullOrEmpty(sTextToEncrypt)) return sTextToEncrypt;

            using (var sha = SHA256.Create())
            {
                var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sTextToEncrypt));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}

