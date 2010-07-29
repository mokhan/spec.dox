using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Spec.Dox.Domain.Repositories
{
    public interface ITestContextRepository
    {
        IEnumerable<ITestContext> All(string path_to_assembly);
    }

    public class TestContextRepository : ITestContextRepository
    {
        ITypeContainsSpecifications criteria;

        public TestContextRepository() : this(new TypeContainsSpecifications()) {}

        public TestContextRepository(ITypeContainsSpecifications criteria)
        {
            this.criteria = criteria;
        }

        public IEnumerable<ITestContext> All(string path_to_assembly)
        {
            return Assembly
                .LoadFrom(path_to_assembly)
                .GetTypes()
                .Where(type => criteria.IsSatisfiedBy(type))
                .Select(type => new TestContext(type))
                .Cast<ITestContext>()
                ;
        }
    }
}