using Csla;
using Csla.Core;
using Csla.Reflection;
using System;
using System.Linq.Expressions;

namespace DH.Lending.Borrower.Business.Model
{
#pragma warning disable CSLA0001 // Find CSLA Business Objects That are Not Serializable
#pragma warning disable CSLA0003 // Find CSLA Business Objects That do not Have Public No-Arugment Constructors
    public sealed class PropertyInfoRegistration
#pragma warning restore CSLA0003 // Find CSLA Business Objects That do not Have Public No-Arugment Constructors
#pragma warning restore CSLA0001 // Find CSLA Business Objects That are Not Serializable
        : BusinessBase
    {
        private PropertyInfoRegistration()
            : base()
        { }

        public static PropertyInfo<T> Register<TTarget, T>(
            Expression<Func<TTarget, T>> propertyLambdaExpression)
        {
            var property = new PropertyInfo<T>(
                Reflect<TTarget>.GetProperty(propertyLambdaExpression).Name);
            return BusinessBase.RegisterProperty<T>(typeof(TTarget), property);
        }

        public static PropertyInfo<T> Register<TTarget, T>(
            Expression<Func<TTarget, T>> propertyLambdaExpression, RelationshipTypes relationship)
        {
            var property = new PropertyInfo<T>(
                Reflect<TTarget>.GetProperty(propertyLambdaExpression).Name, relationship);
            return BusinessBase.RegisterProperty<T>(typeof(TTarget), property);
        }

        public static PropertyInfo<T> Register<T>(Type targetType, string name)
        {
            var property = new PropertyInfo<T>(name);
            return BusinessBase.RegisterProperty<T>(targetType, property);
        }
    }
}
