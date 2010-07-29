using MbUnit.Framework;
using Rhino.Mocks;

namespace Spec.Dox.Test
{
    [TestFixture]
    public abstract class context_spec
    {
        [SetUp]
        public void SetUp()
        {
            UnderTheseConditions();
            BecauseOf();
        }

        [TearDown]
        public virtual void Cleanup() {}

        protected abstract void UnderTheseConditions();

        protected abstract void BecauseOf();

        protected TypeToMock Mock<TypeToMock>() where TypeToMock : class
        {
            return MockRepository.GenerateMock<TypeToMock>();
        }

        protected TypeToMock Stub<TypeToMock>() where TypeToMock : class
        {
            return MockRepository.GenerateStub<TypeToMock>();
        }
    }

    [TestFixture]
    public abstract class context_spec<SystemUnderTest>
    {
        [SetUp]
        public void SetUp()
        {
            sut = EstablishContext();
            Because();
        }

        [TearDown]
        public virtual void Cleanup() {}

        protected abstract SystemUnderTest EstablishContext();

        protected abstract void Because();

        protected TypeToMock Dependency<TypeToMock>() where TypeToMock : class
        {
            return MockRepository.GenerateMock<TypeToMock>();
        }

        protected TypeToMock Stub<TypeToMock>() where TypeToMock : class
        {
            return MockRepository.GenerateStub<TypeToMock>();
        }

        protected SystemUnderTest sut { get; private set; }
    }
}