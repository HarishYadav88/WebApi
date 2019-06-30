namespace WebApi.Application.Queries
{
    using System.Threading.Tasks;
    using WebApi.Application.Queries.Models;

    public interface IGroupQueries
    {
        Task<Group> GetGroupAsync(int id);

        //Task<IEnumerable<OrderSummary>> GetOrdersFromUserAsync(Guid userId);

        //Task<IEnumerable<CardType>> GetCardTypesAsync();
    }
}
