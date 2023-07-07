using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ASP.NET___Encriptacao.Application.DTOs;
using ASP.NET___Encriptacao.Application.Interfaces;
using ASP.NET___Encriptacao.Configuration.Environments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASP.NET___Encriptacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncryptController
    {
        private IOptions<EncryptConfig> _config;

        private IEncryptationService _encryptationService;

        public EncryptController(IEncryptationService encryptationService, IOptions<EncryptConfig> config)
        {
            _encryptationService = encryptationService;
            _config = config;
        }
        
        [HttpPost]
        public async Task<byte[]> EncryptData([FromBody] EncryptDto encryptDto)
        {
            encryptDto.ExpirationDate = DateTime.Now.Date.AddDays(20);
            var byteJson = JsonSerializer.SerializeToUtf8Bytes(encryptDto);
            var encryptedData = _encryptationService.Encrypt(byteJson, Encoding.UTF8.GetBytes(_config.Value.SecretKey));
            return encryptedData;
        }
        
        [HttpPost("Decrypt")]
        public async Task<string> DecryptData([FromBody] DecryptDto decryptDto)
        {
            var decryptedData = _encryptationService.Decrypt(decryptDto.Data,
                Encoding.UTF8.GetBytes(decryptDto.SecretKey));
            return Encoding.Default.GetString(decryptedData);
        }
    }
}