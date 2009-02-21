using System;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace Spec.Dox.Test.Extensions {
    public static class MockingExtensions {
        public static void should_have_been_asked_to<T>(this T typeToVerify, Action<T> actionToPerform) {
            typeToVerify.AssertWasCalled(actionToPerform);
        }

        public static IMethodOptions<R> setup_result_for<T, R>(this T typeToVerify, Func<T, R> actionToPerform) {
            return typeToVerify.Stub(actionToPerform);
        }
    }
}