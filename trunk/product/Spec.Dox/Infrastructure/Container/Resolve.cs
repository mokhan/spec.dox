namespace Spec.Dox.Infrastructure.Container {
    public static class Resolve {
        private static IDependencyRegistry underlying_registry;

        public static void IntializeWith(IDependencyRegistry registry) {
            underlying_registry = registry;
        }

        public static bool IsInitialized() {
            return null != underlying_registry;
        }

        public static Contract AnImplementationOf<Contract>() {
            if (!IsInitialized()) {
                underlying_registry = new DependencyRegistry();
            }

            return underlying_registry.GetAnImplementationOf<Contract>();
        }
    }
}