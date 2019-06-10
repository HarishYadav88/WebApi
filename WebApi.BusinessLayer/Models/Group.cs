using WebApi.DataAccessLayer.Entities;

namespace WebApi.BusinessLayer.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GroupEntity ToEntity()
        {
            return new GroupEntity() { Id = Id, Name = Name };
        }
    }
}
