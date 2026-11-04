using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Helper
{
    /// <summary>
    /// 封装加密方法
    /// </summary>
    public static class EncryptionHelper
    {
        #region MD5

        /// <summary>
        /// MD5 加密（不可逆，用于校验）
        /// </summary>
        public static string MD5(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes).ToLower();
        }

        #endregion

        #region 密码哈希（加盐）

        /// <summary>
        /// 密码哈希（加盐，不可逆）
        /// </summary>
        /// <param name="password">明文密码</param>
        /// <param name="salt">输出盐值</param>
        /// <returns>哈希后的密码</returns>
        public static string HashPassword(string password, out string salt)
        {
            // 生成随机盐
            salt = Convert.ToBase64String(RandomNumberGenerator.GetBytes(16));

            // 用 PBKDF2 哈希
            using var pbkdf2 = new Rfc2898DeriveBytes(password,
                Encoding.UTF8.GetBytes(salt),
                100000,
                HashAlgorithmName.SHA256);

            return Convert.ToBase64String(pbkdf2.GetBytes(32));
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        public static bool VerifyPassword(string password, string hash, string salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password,
                Encoding.UTF8.GetBytes(salt),
                100000,
                HashAlgorithmName.SHA256);

            return Convert.ToBase64String(pbkdf2.GetBytes(32)) == hash;
        }

        #endregion

        #region AES 对称加密（可逆）

        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="plainText">明文</param>
        /// <param name="key">密钥（32位）</param>
        /// <returns>加密后的 Base64 字符串</returns>
        public static string AESEncrypt(string plainText, string key)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));
            aes.IV = RandomNumberGenerator.GetBytes(16);

            using var encryptor = aes.CreateEncryptor();
            var bytes = encryptor.TransformFinalBlock(
                Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);

            // 把 IV 和加密结果拼在一起
            return Convert.ToBase64String(aes.IV.Concat(bytes).ToArray());
        }

        /// <summary>
        /// AES 解密
        /// </summary>
        public static string AESDecrypt(string cipherText, string key)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key.PadRight(32).Substring(0, 32));

            var full = Convert.FromBase64String(cipherText);
            aes.IV = full[..16];  // 前16字节是IV

            using var decryptor = aes.CreateDecryptor();
            var bytes = decryptor.TransformFinalBlock(full, 16, full.Length - 16);

            return Encoding.UTF8.GetString(bytes);
        }

        #endregion

        #region 简单对称加密（带盐）

        /// <summary>
        /// 简单加密（带盐，可逆）
        /// </summary>
        public static string SimpleEncrypt(string input, string salt)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var key = md5.ComputeHash(Encoding.UTF8.GetBytes(salt));

            var result = new StringBuilder();
            var inputBytes = Encoding.UTF8.GetBytes(input);

            for (int i = 0; i < inputBytes.Length; i++)
            {
                result.Append((char)(inputBytes[i] ^ key[i % key.Length]));
            }

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(result.ToString()));
        }

        /// <summary>
        /// 简单解密（带盐）
        /// </summary>
        public static string SimpleDecrypt(string cipherText, string salt)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var key = md5.ComputeHash(Encoding.UTF8.GetBytes(salt));

            var input = Encoding.UTF8.GetString(Convert.FromBase64String(cipherText));
            var inputBytes = Encoding.UTF8.GetBytes(input);

            var result = new StringBuilder();
            for (int i = 0; i < inputBytes.Length; i++)
            {
                result.Append((char)(inputBytes[i] ^ key[i % key.Length]));
            }

            return result.ToString();
        }

        #endregion

    }
}
