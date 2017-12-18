namespace Presentation.DTOs.UserModel
{
    public class GetUserModel
    {
        public System.Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
