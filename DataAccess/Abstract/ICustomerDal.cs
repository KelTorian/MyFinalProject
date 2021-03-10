using Entities.Concrete;
using Test.DataAccess;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
