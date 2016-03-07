using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DH.Lending.Borrower.Business.Model
{
    internal static class EntityExtensions
    {
        public static void SetEntityProperty<TEntity, TValue>(this TEntity target, Expression<Func<TEntity, TValue>> memberLamda, TValue value)
        {
            MemberExpression memberSelectorExpression = memberLamda.Body as MemberExpression;

            PropertyInfo property = memberSelectorExpression?.Member as PropertyInfo;

            property?.SetValue(target, value, null);
        }
    }
}
