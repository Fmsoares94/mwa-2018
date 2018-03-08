using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ModernStoreDataContext _context;

        public ProductRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Product Get(Guid id)
        {
            return _context
                .Products
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetCustomerCommandResult> Get()
        {
            var query = "SELECT [Id], [Title], [Price], [Image] FROM [Products]";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress; database=ModernStore; Integrated Security=True;User id=sa;password=123456"))
            {
                conn.Open();
                return conn
                    .Query<GetCustomerCommandResult>(query);
            }
        }
    }
}
