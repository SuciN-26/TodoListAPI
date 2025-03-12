namespace TodoListAPI.DTOs
{
    public class LoginUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class CreateUserDto : LoginUserDto
    {
        public string Email { get; set; }
        
    }
}
