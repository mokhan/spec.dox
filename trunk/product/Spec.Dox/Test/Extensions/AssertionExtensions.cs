using MbUnit.Framework;

namespace Spec.Dox.Test.Extensions
{
    static public class AssertionExtensions
    {
        static public void should_be_equal_to<T>(this T itemToCheck, T itemToBeEqualTo)
        {
            Assert.AreEqual(itemToBeEqualTo, itemToCheck);
        }
    }
}