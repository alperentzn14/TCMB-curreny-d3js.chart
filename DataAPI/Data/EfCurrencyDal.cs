using Provision.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provision.Data
{
    public class EfCurrencyDal : EFEntityRepositoryBase<Currency, DatabaseContext>, ICurrencyDal
    {
    }
}
