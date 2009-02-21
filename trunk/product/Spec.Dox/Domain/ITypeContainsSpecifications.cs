using System;
using Spec.Dox.Utility.Core;

namespace Spec.Dox.Domain {
    public interface ITypeContainsSpecifications : ISpecification<Type> {}

    public class TypeContainsSpecifications : ITypeContainsSpecifications {
        private IMethodIsDecoratedBySpecificationAttribute criteria;

        public TypeContainsSpecifications(IMethodIsDecoratedBySpecificationAttribute criteria) {
            this.criteria = criteria;
        }

        public bool IsSatisfiedBy(Type item) {
            foreach (var method in item.GetMethods()) {
                if (criteria.IsSatisfiedBy(method)) {
                    return true;
                }
            }
            return false;
        }
    }
}