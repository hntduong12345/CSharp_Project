namespace NET1711_231_ASM2_SE171581_ThaiDuong_JWT.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }

        public Account(Guid id, string userName, string password, string email, string phoneNumber, string role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Role = role;
        }

        public Account()
        {
            
        }
    }
}
