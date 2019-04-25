using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace WhatsNew.Model.Translation
{
    public class TranslationStateManager : IEntityStateListener
    {
        public void StateChanged(InternalEntityEntry entry, EntityState oldState, bool fromQuery)
        {
        }

        public void StateChanging(InternalEntityEntry entry, EntityState newState)
        {
            var entity = entry.Entity as ITranslatable;

            if (entity != null)
            {
                if (entry.EntityState == EntityState.Detached && newState == EntityState.Unchanged)
                {
                    var props = entry.EntityType.GetProperties().Where(p => p.Name.StartsWith("Name_")).ToList();

                    foreach (var prop in props)
                    {
                        entity.Translation.Set(prop.Name.Split('_')[0], entry.GetCurrentValue(prop), prop.Name.Split('_')[1]);
                    }
                }

                if (entry.EntityState == EntityState.Detached && newState == EntityState.Added)
                {
                    foreach (var item in entity.Translation.GetItems())
                    {
                        var prop = entry.EntityType.FindProperty($"{item.Property}_{item.Language}");
                        entry.SetCurrentValue(prop, item.Value);
                    }
                }
            }
        }
    }
}