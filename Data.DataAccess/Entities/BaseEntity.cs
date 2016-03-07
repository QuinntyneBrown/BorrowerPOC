using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DH.Lending.Borrower.Data.DataAccess.Entities
{
    internal abstract class BaseEntity<TType, TEntity>
        where TEntity : class, new()
    {
        private readonly Dictionary<string, bool> _propertySet = new Dictionary<string, bool>();

        protected BaseEntity(TEntity entity)
        {
            Entity = entity;
        }

        private TEntity _entity;

        internal TEntity Entity
        {
            get { return _entity ?? (_entity = new TEntity()); }
            set { _entity = value; }
        }

        protected void PropertySet([CallerMemberName] string name = "")
        {
            _propertySet[name] = true;
        }

        internal bool PropertyChanged<TProperty>(Expression<Func<TType, TProperty>> expression)
        {
            var member = expression.Body as MemberExpression;
            var propertyInfo = member?.Member as PropertyInfo;

            var wasSet = false;

            if (propertyInfo != null)
                _propertySet.TryGetValue(propertyInfo.Name, out wasSet);

            return wasSet;
        }
    }
}
