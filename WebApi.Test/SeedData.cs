using WebApi.DataAccessLayer;
using WebApi.DataAccessLayer.Entities;

namespace WebApi.IntegrationTest
{
    public class SeedData
    {
        public static void PopulateTestData(GroupManagementDbContext dbContext)
        {
            dbContext.Groups.Add(new GroupEntity() { Id = 1, Name = "Group 1"});
            dbContext.Groups.Add(new GroupEntity() { Id = 2, Name = "Group 2" });
            dbContext.SaveChanges();
        }
    }
}
