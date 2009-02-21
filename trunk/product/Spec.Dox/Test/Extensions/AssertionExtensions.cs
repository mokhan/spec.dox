using MbUnit.Framework;

namespace Spec.Dox.Test.Extensions {
    public static class AssertionExtensions {
        public static void should_be_equal_to<T>(this T itemToCheck, T itemToBeEqualTo) {
            Assert.AreEqual(itemToBeEqualTo, itemToCheck);
        }
    }
}