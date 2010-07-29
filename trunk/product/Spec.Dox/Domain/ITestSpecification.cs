using System.Reflection;

namespace Spec.Dox.Domain
{
    public interface ITestSpecification
    {
        string Name { get; }
    }

    public class TestSpecification : ITestSpecification
    {
        public TestSpecification(MethodInfo method)
        {
            Name = method.Name;
        }

        public string Name { get; private set; }
    }
}