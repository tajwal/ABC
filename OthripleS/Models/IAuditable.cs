using System;

namespace OtripleS.Web.Api.Models
{
    public class IAuditable
    {
        DateTimeOffset CreatedDate { get; set; }
        DateTimeOffset UpdatedDate { get; set; }
        Guid CreatedBy { get; set; }
        Guid UpdatedBy { get; set; }
    }
}
