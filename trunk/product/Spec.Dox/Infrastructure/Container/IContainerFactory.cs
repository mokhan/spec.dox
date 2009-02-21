using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Spec.Dox.Utility.Core;

namespace Spec.Dox.Infrastructure.Container {
    public interface IContainerFactory : IFactory<IWindsorContainer> {}

    public class ContainerFactory : IContainerFactory {
        private static readonly IWindsorContainer container;

        static ContainerFactory() {
            container = new WindsorContainer();
            container.Register(
                AllTypes
                    .Pick()
                    .FromAssembly(typeof (ContainerFactory).Assembly)
                    .WithService.FirstInterface()
                    .Unless(t => t.IsAbstract)
                    .AllowMultipleMatches()
                );
        }

        public IWindsorContainer Create() {
            return container;
        }
    }
}