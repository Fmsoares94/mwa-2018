using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public Customer Get(Guid id)
        {
            return _context
                .Custumers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public Customer GetByUserId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string document)
        {
            return _context
                .Custumers
                .Include(x => x.User)
                .FirstOrDefault(x => x.Document.Number == document);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public bool DocumentExists(string document)
        {
            return _context.Custumers.Any(x => x.Document.Number == document);
        }

        public void Save(Customer customer)
        {
            _context.Custumers.Add(customer);
        }

        GetCustomerCommandResult ICustomerRepository.Get(string username)
        {
            //return _context
            //    .Custumers
            //    .Include(x=>x.User)
            //    .AsNoTracking()
            //    .Select( x => new GetCustomerCommandResult
            //{
            //    Name = x.Name.ToString(),
            //    Document = x.Document.Number,
            //    Active = x.User.Active,
            //    Email = x.Email.Address,
            //    UserName = x.User.Username

            //})
            //    .FirstOrDefault(x => x.UserName == username);

            var query = "SELECT * FROM [GetCustomerInfoView] WHERE [ACTIVE]=1 AND [UserName]=@username";
            using (SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress; database=ModernStore; Integrated Security=True;User id=sa;password=123456"))
            {
                conn.Open();
                return conn
                    .Query<GetCustomerCommandResult>(query,
                    new{username = username})
                    .FirstOrDefault();
            }
        }
    }
}
