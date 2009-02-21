using System.Reflection;
using MbUnit.Framework;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;
using Spec.Dox.Utility.Core;

namespace Spec.Dox.Domain {
    public class MethodDecoratedBySpecificationAttributeSpecs {}

    [Concern(typeof (MethodIsDecoratedBySpecificationAttribute))]
    public class when_checking_if_a_method_is_decorated_with_an_attribute_that_it_is_decorated_with :
        context_spec<ISpecification<MethodInfo>> {
        private bool result;
        private MethodInfo methodToInspect;

        protected override ISpecification<MethodInfo> UnderTheseConditions() {
            methodToInspect = GetType().GetMethod("should_return_true");
            return new MethodIsDecoratedBySpecificationAttribute("TestAttribute");
        }

        protected override void BecauseOf() {
            result = sut.IsSatisfiedBy(methodToInspect);
        }

        [Test]
        public void should_return_true() {
            result.should_be_equal_to(true);
        }
        }

    [Concern(typeof (MethodIsDecoratedBySpecificationAttribute))]
    public class when_checking_if_a_method_is_decorated_with_an_attribute_that_it_is_not :
        context_spec<ISpecification<MethodInfo>> {
        private bool result;
        private MethodInfo methodToInspect;

        protected override ISpecification<MethodInfo> UnderTheseConditions() {
            methodToInspect = GetType().GetMethod("should_return_false");
            return new MethodIsDecoratedBySpecificationAttribute("SerializableAttribute");
        }

        protected override void BecauseOf() {
            result = sut.IsSatisfiedBy(methodToInspect);
        }

        [Test]
        public void should_return_false() {
            result.should_be_equal_to(false);
        }
        }
}