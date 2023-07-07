namespace ASP.NET___Encriptacao.Application.Interfaces
{
    public interface IEncryptationService
    {
        public byte[] Encrypt(byte[] data, byte[] key);
        public byte[] Decrypt(byte[] encryptedData, byte[] key);
        public byte[] GenerateRandomKey();
    }
}