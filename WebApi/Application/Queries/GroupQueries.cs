namespace WebApi.Application.Queries
{
    using Dapper;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System;
    using System.Collections.Generic;
    using WebApi.Application.Queries.Models;

    public class GroupQueries : IGroupQueries
    {
        private string _connectionString = string.Empty;

        public GroupQueries() { }

        public GroupQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<Group> GetGroupAsync(int id)
        {
            using (var connection = new SqlConnection("Server=(local);Database=GroupManagement;Trusted_Connection=True;MultipleActiveResultSets=True"))
            {
                connection.Open();

                var result = await connection.QueryAsync<dynamic>(
                   @"select g.[Id] as groupid, g.[Name] as groupname
                        FROM [Groups] g
                        WHERE g.[Id]=@id"
                        , new { id }
                    );

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapGroupItems(result);
            }
        }

        //public async Task<IEnumerable<OrderSummary>> GetOrdersFromUserAsync(Guid userId)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        return await connection.QueryAsync<OrderSummary>(@"SELECT o.[Id] as ordernumber,o.[OrderDate] as [date],os.[Name] as [status], SUM(oi.units*oi.unitprice) as total
        //             FROM [ordering].[Orders] o
        //             LEFT JOIN[ordering].[orderitems] oi ON  o.Id = oi.orderid 
        //             LEFT JOIN[ordering].[orderstatus] os on o.OrderStatusId = os.Id                     
        //             LEFT JOIN[ordering].[buyers] ob on o.BuyerId = ob.Id
        //             WHERE ob.IdentityGuid = @userId
        //             GROUP BY o.[Id], o.[OrderDate], os.[Name] 
        //             ORDER BY o.[Id]", new { userId });
        //    }
        //}

        //public async Task<IEnumerable<CardType>> GetCardTypesAsync()
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        connection.Open();

        //        return await connection.QueryAsync<CardType>("SELECT * FROM ordering.cardtypes");
        //    }
        //}

        private Group MapGroupItems(dynamic result)
        {
            var group = new Group
            {
                Id = result[0].groupid,
                Name = result[0].groupname
            };

            return group;
        }
    }
}
