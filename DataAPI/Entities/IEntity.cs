using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Provision.Entities
{
    public interface IEntity
    {
        long RecordId { get; set; }
    }
}
