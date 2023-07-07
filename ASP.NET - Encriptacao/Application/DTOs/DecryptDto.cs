namespace ASP.NET___Encriptacao.Application.DTOs
{
    public class DecryptDto
    {
        public byte[] Data { get; set; }
        public string SecretKey { get; set; }
    }
}