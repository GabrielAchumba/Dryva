namespace Dryva.Security.DTOs
{
    public class UserAccountDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }

    public class RegisterUserDTO : BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class CredentialDTO : BaseDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
