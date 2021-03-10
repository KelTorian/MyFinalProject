using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Test.DataAccess;

namespace DataAccess.Abstract
{
    public interface IOrderDal:IEntityRepository<Order>
    {
    }
}
