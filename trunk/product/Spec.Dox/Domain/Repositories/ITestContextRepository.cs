using System;
using System.Collections.Generic;
using System.Reflection;
using Spec.Dox.Domain;

namespace Spec.Dox.Domain.Repositories {
    public interface ITestContextRepository {
        IEnumerable<ITestContext> All();
    }

    public class TestContextRepository : ITestContextRepository {
        private readonly Assembly assemblyToInspect;
        private ITypeContainsSpecifications criteria;

        public TestContextRepository(ITypeContainsSpecifications criteria)
            : this(Environment.GetCommandLineArgs()[1], criteria) {}

        public TestContextRepository(string pathToAssembly, ITypeContainsSpecifications criteria) {
            assemblyToInspect = Assembly.LoadFrom(pathToAssembly);
            this.criteria = criteria;
        }

        public IEnumerable<ITestContext> All() {
            foreach (var type in assemblyToInspect.GetTypes()) {
                if (criteria.IsSatisfiedBy(type)) {
                    yield return new TestContext(type);
                }
            }
        }
    }
}