using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using ASP.NET___Encriptacao.Application.Interfaces;

namespace ASP.NET___Encriptacao.Application.Services
{
    public class EncryptationService : IEncryptationService
    {

        // Função para criptografar dados usando AES
        public byte[] Encrypt(byte[] data, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.CBC;

                byte[] iv = aes.IV;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                using (MemoryStream ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }
                    return ms.ToArray();
                }
            }
        }
        
        // Função para descriptografar dados usando AES
        public byte[] Decrypt(byte[] encryptedData, byte[] key)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = key;
                    aes.Mode = CipherMode.CBC;

                    byte[] iv = new byte[aes.IV.Length];
                    Buffer.BlockCopy(encryptedData, 0, iv, 0, iv.Length);

                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(encryptedData, iv.Length, encryptedData.Length - iv.Length);
                            cs.FlushFinalBlock();
                        }

                        return ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        // Função para gerar uma chave aleatória para criptografia simétrica
        public byte[] GenerateRandomKey()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

    }
}