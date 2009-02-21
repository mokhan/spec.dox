namespace Spec.Dox.Utility.Core {
    public interface IFactory<TypeToCreate> {
        TypeToCreate Create();
    }
}