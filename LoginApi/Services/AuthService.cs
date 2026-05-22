using LoginApi.DTOs;
using LoginApi.Models;
using LoginApi.Repositories;

namespace LoginApi.Services
{
    public class AuthService
    {
        private readonly UserRepository _repository;
        private readonly TokenService _tokenService;

        public AuthService(UserRepository repository, TokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public string? Register(RegisterDto dto)
        {
            if (_repository.Exists(dto.Username))
                return null;

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _repository.Add(user);
            return _tokenService.GenerateToken(user);
        }

        public string? Login(LoginDto dto)
        {
            var user = _repository.GetByUsername(dto.Username);
            if (user == null) return null;

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return _tokenService.GenerateToken(user);
        }
    }
}