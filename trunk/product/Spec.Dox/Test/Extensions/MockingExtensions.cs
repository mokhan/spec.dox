using System;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace Spec.Dox.Test.Extensions
{
    static public class MockingExtensions
    {
        static public void received<T>(this T typeToVerify, Action<T> actionToPerform)
        {
            typeToVerify.AssertWasCalled(actionToPerform);
        }

        static public IMethodOptions<R> is_told_to<T, R>(this T typeToVerify, Function<T, R> actionToPerform) where T : class
        {
            return typeToVerify.Stub(actionToPerform);
        }
    }
}