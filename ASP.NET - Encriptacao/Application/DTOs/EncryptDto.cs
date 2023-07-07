using System;

namespace ASP.NET___Encriptacao.Application.DTOs
{
    public class EncryptDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}