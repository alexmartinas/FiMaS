using Data.Domain.Entities;

namespace Presentation.DTOs.UserModel
{
    public class GetUserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
