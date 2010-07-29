using System;
using System.Reflection;
using Spec.Dox.Utility.Core;

namespace Spec.Dox.Domain
{
    public interface IMethodIsDecoratedBySpecificationAttribute : ISpecification<MethodInfo> {}

    public class MethodIsDecoratedBySpecificationAttribute : IMethodIsDecoratedBySpecificationAttribute
    {
        readonly string name_of_the_attribute_to_lookup;

        public MethodIsDecoratedBySpecificationAttribute() : this(Environment.GetCommandLineArgs()[2]) {}

        public MethodIsDecoratedBySpecificationAttribute(string nameOfAttributeToLookup)
        {
            name_of_the_attribute_to_lookup = nameOfAttributeToLookup;
        }

        public bool IsSatisfiedBy(MethodInfo item)
        {
            foreach (var attribute in item.GetCustomAttributes(true))
            {
                if (attribute.GetType().Name.Equals(name_of_the_attribute_to_lookup))
                    return true;
            }
            return false;
        }
    }
}