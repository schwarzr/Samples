using System;

namespace GlobalAzure.CustomSchema.Database.Extendable
{
    public interface IAdditionalDataEntityMapping
    {
        Type Target { get; }

        Type Entity { get; }
    }
}
