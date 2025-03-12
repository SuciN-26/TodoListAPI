using TodoListAPI.Data;
using TodoListAPI.DTOs;
using TodoListAPI.Model;

namespace TodoListAPI.Service
{
    public interface IUserService
    {
        Task<DataResponse<AppUser>> RegisterUser(CreateUserDto input);

        Task<TokenResponse> LoginUser(LoginUserDto input);
    }
}
