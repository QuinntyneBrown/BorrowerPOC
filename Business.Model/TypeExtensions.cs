using System;

namespace DH.Lending.Borrower.Business.Model
{
    internal static class TypeExtensions
    {
        public static Type GetConcreteType(this Type source)
        {
            if (source == null || !source.IsInterface || string.IsNullOrWhiteSpace(source.Namespace))
            {
                return source;
            }

            // Example naming.
            // DH.Lending.Borrower.Business.Repository.IBorrower
            // DH.Lending.Borrower.Business.Borrower

            var concreteTypeName = string.Concat(
                source.Namespace.Replace(".Repository", ".Model"),
                ".",
                source.Name.Substring(1),
                ", ",
                source.Assembly.FullName.Replace(".Repository", ".Model"));

            return Type.GetType(concreteTypeName);
        }
    }
}
