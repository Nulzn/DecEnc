namespace EncryptService {
    internal static class Encrypt {
        public static string EncryptString(string stringToEncrypt, string key) {
            System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
            cspp.KeyContainerName = key;
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            byte[] bytes = rsa.Encrypt(System.Text.UTF8Encoding.UTF8.GetBytes(stringToEncrypt), true);
            return BitConverter.ToString(bytes);
        }

        public static string DecryptString(string stringToDecrypt, string key) {
            System.Security.Cryptography.CspParameters cspp = new System.Security.Cryptography.CspParameters();
            cspp.KeyContainerName = key;
            System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;
            string[] decryptArray = stringToDecrypt.Split(new string[] { "-" }, StringSplitOptions.None);
            byte[] decryptByteArray = Array.ConvertAll<string, byte>(decryptArray, (s => Convert.ToByte(byte.Parse(s, System.Globalization.NumberStyles.HexNumber))));
            byte[] bytes = rsa.Decrypt(decryptByteArray, true);
            return System.Text.UTF8Encoding.UTF8.GetString(bytes);
        }
    }
}