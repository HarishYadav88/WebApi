using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using WebApi.BusinessLayer.Interfaces;
using WebApi.Controllers;
using Xunit;

namespace WebApi.Test
{
    public class GroupTest
    {
        [Fact]
        public async Task Test1()
        {
            var mockLogger = new Mock<ILogger<GroupController>>();
            //ILogger<GroupController> logger = mockLogger.Object;

            var mockService = new Mock<IGroupService>();
            mockService.Setup(p => p.GetByIdAsync(1, new System.Threading.CancellationToken(false)));
            GroupController groupController = new GroupController(mockService.Object, mockLogger.Object);
            var result = await groupController.GetGroup(1, new System.Threading.CancellationToken(false));
            Assert.Equal("", "");
        }
    }
}