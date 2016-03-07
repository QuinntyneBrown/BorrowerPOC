using Csla.Server;
using Microsoft.Practices.Unity;
using System;
using System.Linq;
using System.Reflection;

namespace DH.Lending.Borrower.Business.Model
{
    internal sealed class ObjectActivator
        : IDataPortalActivator
    {
        public ObjectActivator(IUnityContainer container)
        {
            Container = container;
        }

        private IUnityContainer Container { get; }

        public object CreateInstance(Type requestedType)
        {
            return Activator.CreateInstance(requestedType.GetConcreteType());
        }

        public void InitializeInstance(object obj)
        {
            var scopedObject = obj as IDHBusinessScope;

            if (scopedObject != null)
            {
                var scope = Container.CreateChildContainer();
                scopedObject.Scope = scope;

                var properties = scopedObject
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(p => p.GetCustomAttribute<DependencyAttribute>() != null);

                foreach (var property in properties)
                {
                    property.SetValue(scopedObject, scope.Resolve(property.PropertyType));
                }
            }
        }

        public void FinalizeInstance(object obj)
        {
            var scopedObject = obj as IDHBusinessScope;

            if (scopedObject != null)
            {
                scopedObject.Scope.Dispose();

                var properties = scopedObject
                    .GetType()
                    .GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .Where(p => p.GetCustomAttribute<DependencyAttribute>() != null);

                foreach (var property in properties)
                {
                    property.SetValue(scopedObject, null);
                }
            }
        }
    }
}
