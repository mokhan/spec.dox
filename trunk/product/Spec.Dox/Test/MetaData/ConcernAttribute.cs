using System;

namespace Spec.Dox.Test.MetaData
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConcernAttribute : Attribute
    {
        public ConcernAttribute(Type systemUnderTest)
        {
            SystemUnderTest = systemUnderTest;
        }

        public Type SystemUnderTest { get; private set; }
    }
}