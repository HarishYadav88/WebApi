using WebApi.DataAccessLayer.Entities;

namespace WebApi.BusinessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserEntity ToEntity()
        {
            return new UserEntity() { Id = Id, FirstName = FirstName, LastName = LastName, Username = Username};
        }
    }
}
