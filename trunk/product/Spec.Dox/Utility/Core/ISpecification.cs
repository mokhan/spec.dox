namespace Spec.Dox.Utility.Core
{
    public interface ISpecification<TypeToInspect>
    {
        bool IsSatisfiedBy(TypeToInspect item);
    }
}