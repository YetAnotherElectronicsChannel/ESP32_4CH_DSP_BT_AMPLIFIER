
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace dsp_gui
{
	/// <summary>
	/// Description of Encrypt.
	/// </summary>
	public class Encrypt
	{
		public Encrypt()
		{
		}
		#region Settings

        private static int _iterations = 2;
        private static int _keySize = 256;

        private static string _hash     = "SHA1";
        private static string _salt     = "ajsi9djvl492jdla"; // Random
        private static string _vector   = "aslkdjajd9083281"; // Random

        #endregion

        public static string EncryptDo(string value, string password) {
            return EncryptDo<AesManaged>(value, password);
        }
        public static string EncryptDo<T>(string value, string password) 
                where T : SymmetricAlgorithm, new() {
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Encoding.UTF8.GetBytes(value);

            byte[] encrypted;
            using (T cipher = new T()) {
                PasswordDeriveBytes _passwordBytes = 
                    new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes)) {
                    using (MemoryStream to = new MemoryStream()) {
                        using (CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write)) {
                            writer.Write(valueBytes, 0, valueBytes.Length);
                            writer.FlushFinalBlock();
                            encrypted = to.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
            return Convert.ToBase64String(encrypted);
        }

        public static string DecryptDo(string value, string password) {
            return DecryptDo<AesManaged>(value, password);
        }
        public static string DecryptDo<T>(string value, string password) where T : SymmetricAlgorithm, new() {
        	
        	
            byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
            byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
            byte[] valueBytes = Convert.FromBase64String(value);

            byte[] decrypted;
            int decryptedByteCount = 0;
			
            using (T cipher = new T()) {
                PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
                byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

                cipher.Mode = CipherMode.CBC;

                try {
                    using (ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes)) {
                        using (MemoryStream from = new MemoryStream(valueBytes)) {
                            using (CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read)) {
                                decrypted = new byte[valueBytes.Length];
                                decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
                            }
                        }
                    }
                } catch (Exception ex) {
                    return String.Empty;
                }

                cipher.Clear();
            }
            return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
        }
        
        public static string CreateMD5(string input)
		{
		    // Use input string to calculate MD5 hash
		    using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
		    {
		        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
		        byte[] hashBytes = md5.ComputeHash(inputBytes);
		
		        // Convert the byte array to hexadecimal string
		        StringBuilder sb = new StringBuilder();
		        for (int i = 0; i < hashBytes.Length; i++)
		        {
		            sb.Append(hashBytes[i].ToString("X2"));
		        }
		        return sb.ToString();
		    }
		}

	}
}
