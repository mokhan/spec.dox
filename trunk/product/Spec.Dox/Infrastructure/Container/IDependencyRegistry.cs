using Castle.Windsor;

namespace Spec.Dox.Infrastructure.Container {
    public interface IDependencyRegistry {
        Contract GetAnImplementationOf<Contract>();
    }

    public class DependencyRegistry : IDependencyRegistry {
        private IWindsorContainer container;

        public DependencyRegistry() : this(new ContainerFactory()) {}

        public DependencyRegistry(IContainerFactory containerFactory) {
            container = containerFactory.Create();
        }

        public Contract GetAnImplementationOf<Contract>() {
            return container.Resolve<Contract>();
        }
    }
}