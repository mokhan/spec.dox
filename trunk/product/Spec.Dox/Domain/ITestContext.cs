using System;
using System.Collections.Generic;

namespace Spec.Dox.Domain
{
    public interface ITestContext
    {
        string Name { get; }
        IEnumerable<ITestSpecification> AllSpecifications();
    }

    public class TestContext : ITestContext
    {
        readonly Type type;
        IMethodIsDecoratedBySpecificationAttribute methodCriteria;

        public TestContext(Type type) : this(type, new MethodIsDecoratedBySpecificationAttribute()) {}

        public TestContext(Type type, IMethodIsDecoratedBySpecificationAttribute methodCriteria)
        {
            this.type = type;
            this.methodCriteria = methodCriteria;
            Name = type.Name;
        }

        public string Name { get; private set; }

        public IEnumerable<ITestSpecification> AllSpecifications()
        {
            foreach (var method in type.GetMethods())
            {
                if (methodCriteria.IsSatisfiedBy(method))
                    yield return new TestSpecification(method);
            }
        }
    }
}