using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using TodoListAPI.Data;
using TodoListAPI.DTOs;
using TodoListAPI.Model;
using TodoListAPI.Repositories;

namespace TodoListAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;
             
        public UserService(IUserRepository userRepo, JwtService jwtService) { 
            _userRepository = userRepo;
            _jwtService = jwtService;
        }

        public async Task<TokenResponse> LoginUser(LoginUserDto input)
        {
            var data = await _userRepository.GetUserByUsername(input.Username);

            if(data == null || !BCrypt.Net.BCrypt.Verify(input.Password, data.Password))
            {
                return new TokenResponse()
                {
                    Code = (int)HttpStatusCode.Unauthorized,
                    Message = "Invalid Credential"
                };
            }

            var token = _jwtService.GenerateToken(data.Username, data.Id);

            return new TokenResponse() { 
                Code = (int)HttpStatusCode.OK,
                Message = "Berhasil Login",
                Token = token
            };
        }

        public async Task<DataResponse<AppUser>> RegisterUser(CreateUserDto input)
        {
            if (await _userRepository.GetUsername(input.Username))
            {
                return new DataResponse<AppUser>()
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Message = "Username sudah terdaftar di database"
                };
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(input.Password);
            var user = new AppUser { Username = input.Username, Password = hashedPassword, Email = input.Email};

            await _userRepository.AddAsync(user);
            return new DataResponse<AppUser>()
            {
                Code = (int)HttpStatusCode.OK,
                Message = "User telah berhasil didaftarkan"
            };
        }
    }
}
