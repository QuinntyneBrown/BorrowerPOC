using Microsoft.Data.Entity;
using System;
using System.Linq.Expressions;

namespace DH.Lending.Borrower.Data.EntityModel
{
    public static class EntityExtensions
    {
        public static void Update<TEntity, TProperty>(this TEntity entity, DbContext context, Expression<Func<TEntity, TProperty>> property, TProperty value)
            where TEntity : class
        {
            var propertyEntry = context.Entry(entity).Property(property);
            propertyEntry.CurrentValue = value;
            propertyEntry.IsModified = true;
        }
    }
}
