using DH.Lending.Borrower.Data.DataAccess.Entities;
using DH.Lending.Borrower.Data.EntityModel;
using Microsoft.Data.Entity;
using System;
using System.Linq.Expressions;

namespace DH.Lending.Borrower.Data.DataAccess
{
    internal static class EntityExtensions
    {
        public static void UpdateChanged<TDbEntity, TEntity, TProperty>(this TDbEntity dbEntity, TEntity entity, DbContext context, Expression<Func<TDbEntity, TProperty>> dbExpression, Expression<Func<TEntity, TProperty>> entityExpression)
            where TDbEntity : class, new()
            where TEntity : BaseEntity<TEntity, TDbEntity>
        {
            if (entity.PropertyChanged(entityExpression))
                dbEntity.Update(context, dbExpression, entityExpression.Compile()(entity));
        }
    }
}
