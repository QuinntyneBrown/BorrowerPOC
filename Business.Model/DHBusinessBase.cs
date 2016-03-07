using Csla;
using Csla.Core;
using DH.Lending.Borrower.Business.Repository;
using System;
using System.Linq.Expressions;

namespace DH.Lending.Borrower.Business.Model
{
    [Serializable]
    internal abstract class DHBusinessBase<T>
        : BusinessBase<T>, IDHBusinessBase
        where T : DHBusinessBase<T>
    {
        private static readonly Type _StringType = typeof(string);

        protected DHBusinessBase()
            : base()
        {
            DisableIEditableObject = true;
        }

        protected override object ReadProperty(IPropertyInfo propertyInfo)
        {
            if (propertyInfo.Type != _StringType)
                return base.ReadProperty(propertyInfo);

            var temp = base.ReadProperty(propertyInfo) as string;

            return string.IsNullOrEmpty(temp) ? null : temp;
        }

        protected void SetEntityProperty<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> memberSelector, PropertyInfo<TProperty> propertyInfo)
        {
            if (FieldManager.IsFieldDirty(propertyInfo))
            {
                entity.SetEntityProperty(memberSelector, ReadProperty(propertyInfo));
            }
        }

        protected void SetEntityPropertyConvert<TEntity, TValue, TProperty>(TEntity entity, Expression<Func<TEntity, TValue>> memberSelector, PropertyInfo<TProperty> propertyInfo)
        {
            if (FieldManager.IsFieldDirty(propertyInfo))
            {
                entity.SetEntityProperty(memberSelector, ReadPropertyConvert<TProperty, TValue>(propertyInfo));
            }
        }
    }
}
