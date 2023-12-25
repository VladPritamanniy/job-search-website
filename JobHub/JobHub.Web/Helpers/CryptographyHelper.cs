using System.Security.Cryptography;
using System.Text;

namespace JobHub.Web.Helpers
{
    public static class CryptographyHelper
    {
        private static readonly string EncryptionKey = "Q+DG=M15-21fvbJkTKa=3LVQj42-8+_1";

        public static string Encrypt(string data)
        {
            if (data is null)
            {
                return string.Empty;
            }

            try
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);
                byte[] encryptedBytes = ProtectData(dataBytes);

                return BitConverter.ToString(encryptedBytes).Replace("-", "");
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public static string Decrypt(string data)
        {
            if (data is null)
            {
                return string.Empty;
            }

            try
            {
                byte[] encryptedBytes = StringToByteArray(data);
                byte[] decryptedBytes = UnprotectData(encryptedBytes);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private static byte[] ProtectData(byte[] data)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(data, 0, data.Length);
                        csEncrypt.FlushFinalBlock();
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private static byte[] UnprotectData(byte[] encryptedData)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptionKey);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;

                byte[] iv = new byte[aesAlg.BlockSize / 8];
                Buffer.BlockCopy(encryptedData, 0, iv, 0, iv.Length);
                aesAlg.IV = iv;

                using (ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                using (MemoryStream msDecrypt = new MemoryStream())
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(encryptedData, iv.Length, encryptedData.Length - iv.Length);
                        csDecrypt.FlushFinalBlock();
                    }
                    return msDecrypt.ToArray();
                }
            }
        }

        private static byte[] StringToByteArray(string hex)
        {
            int length = hex.Length / 2;
            byte[] bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
    }
}
