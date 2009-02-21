using System.ComponentModel;
using MbUnit.Framework;
using Spec.Dox.Test;
using Spec.Dox.Test.Extensions;
using Spec.Dox.Test.MetaData;

namespace Spec.Dox.Infrastructure.Container {
    public class ResolveSpecs {}

    [Concern(typeof (Resolve))]
    public class when_attempting_to_resolve_a_dependency : context_spec {
        private ISynchronizeInvoke result;
        private IDependencyRegistry registry;
        private ISynchronizeInvoke item_to_return;

        protected override void UnderTheseConditions() {
            registry = Mock<IDependencyRegistry>();
            item_to_return = Stub<ISynchronizeInvoke>();
            registry
                .setup_result_for(r => r.GetAnImplementationOf<ISynchronizeInvoke>())
                .Return(item_to_return);
            Resolve.IntializeWith(registry);
        }

        protected override void BecauseOf() {
            result = Resolve.AnImplementationOf<ISynchronizeInvoke>();
        }

        [Test]
        public void should_leverage_the_underlying_resolver_to_satisfy_the_dependency() {
            registry.should_have_been_asked_to(r => r.GetAnImplementationOf<ISynchronizeInvoke>());
        }

        [Test]
        public void should_return_the_same_item_retrieve_from_the_registry() {
            result.should_be_equal_to(item_to_return);
        }
    }
}