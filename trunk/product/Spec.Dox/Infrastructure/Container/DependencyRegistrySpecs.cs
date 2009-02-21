using System.Security.Principal;
using Castle.Windsor;
using MbUnit.Framework;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;

namespace Spec.Dox.Infrastructure.Container {
    public class DependencyRegistrySpecs {}


    [Concern(typeof (DependencyRegistry))]
    public class when_creating_a_new_dependency_registry : context_spec<IDependencyRegistry> {
        private IContainerFactory containerFactory;

        protected override IDependencyRegistry UnderTheseConditions() {
            containerFactory = Dependency<IContainerFactory>();
            return new DependencyRegistry(containerFactory);
        }

        protected override void BecauseOf() {}

        [Test]
        public void should_initialize_the_underlying_container() {
            containerFactory.should_have_been_asked_to(f => f.Create());
        }
    }

    [Concern(typeof (DependencyRegistry))]
    public class when_retrieving_an_implementation_of_a_contract : context_spec<IDependencyRegistry> {
        private IContainerFactory containerFactory;
        private IIdentity result;
        private IIdentity identity_to_return;
        private IWindsorContainer container;

        protected override IDependencyRegistry UnderTheseConditions() {
            containerFactory = Dependency<IContainerFactory>();
            container = Stub<IWindsorContainer>();
            identity_to_return = Stub<IIdentity>();

            containerFactory
                .setup_result_for(f => f.Create())
                .Return(container);
            container.setup_result_for(c => c.Resolve<IIdentity>())
                .Return(identity_to_return);
            return new DependencyRegistry(containerFactory);
        }

        protected override void BecauseOf() {
            result = sut.GetAnImplementationOf<IIdentity>();
        }

        [Test]
        public void should_leverage_the_windsor_container_to_resolve_the_dependency() {
            result.should_be_equal_to(identity_to_return);
        }
    }
}