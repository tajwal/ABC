using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OthripleS.Models
{
    public class IAuditable
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
        Guid CreatedBy { get; set; }
        Guid UpdatedBy { get; set; }
    }
}
