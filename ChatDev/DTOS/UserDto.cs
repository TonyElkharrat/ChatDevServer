namespace ChatDev.DTOS
{
    public class UserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastConnectedOn { get; set; }
        public string Password { get; set; }
    }
}
