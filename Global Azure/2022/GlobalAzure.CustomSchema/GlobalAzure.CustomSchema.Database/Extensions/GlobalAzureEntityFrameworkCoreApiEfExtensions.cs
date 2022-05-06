﻿using System.Linq;
using System.Text.Json;
using GlobalAzure.CustomSchema.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GlobalAzure.CustomSchema.Database.Extensions
{
    public static class GlobalAzureEntityFrameworkCoreApiEfExtensions
    {
        public static void MapAdditionalProperties<TEntity>(this EntityEntry<TEntity> entry, IExtendableObject target)
            where TEntity : class
        {
            foreach (var item in entry.Metadata.GetProperties().Where(p => p.IsShadowProperty()))
            {
                if (item == entry.Metadata.GetDiscriminatorProperty())
                {
                    continue;
                }

                var value = entry.CurrentValues[item];
                target.AdditionalProperties.Add(item.Name.ToLower(), value);
            }
        }

        public static void UpdateAdditionalProperties<TEntity>(this EntityEntry<TEntity> entry, IExtendableObject target)
           where TEntity : class
        {
            foreach (var item in entry.Metadata.GetProperties().Where(p => p.IsShadowProperty()))
            {
                if (item == entry.Metadata.GetDiscriminatorProperty())
                {
                    continue;
                }

                if (target.AdditionalProperties.TryGetValue(item.Name.ToLower(), out var value))
                {
                    if (value is JsonElement json)
                    {
                        value = System.Text.Json.JsonSerializer.Deserialize(json.GetRawText(), item.ClrType);
                    }

                    entry.CurrentValues[item] = value;
                }
            }
        }
    }
}
