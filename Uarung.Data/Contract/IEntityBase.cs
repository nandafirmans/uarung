using System;

namespace Uarung.Data.Contract
{
    public interface IEntityBase
    {
        string Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime UpdatedDate { get; set; }
    }
}