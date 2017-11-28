using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.OData.Builder;

namespace AdventureWorksOrder.OData
{
    public static class ODataExtensions
    {
        public static EntityTypeConfiguration<TEntity> CamelCase<TEntity>(this EntityTypeConfiguration<TEntity> config)
            where TEntity : class
        {
            foreach (var item in config.Properties)
            {
                item.Name = item.Name.Substring(0, 1).ToLower() + item.Name.Substring(1);
            }

            return config;
        }
    }
}