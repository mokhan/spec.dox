using MbUnit.Framework;
using Rhino.Mocks;

namespace Spec.Dox.Test {
    [TestFixture]
    public abstract class context_spec {
        [SetUp]
        public void SetUp() {
            UnderTheseConditions();
            BecauseOf();
        }

        [TearDown]
        public virtual void Cleanup() {}

        protected abstract void UnderTheseConditions();

        protected abstract void BecauseOf();

        protected TypeToMock Mock<TypeToMock>() {
            return MockRepository.GenerateMock<TypeToMock>();
        }

        protected TypeToMock Stub<TypeToMock>() {
            return MockRepository.GenerateStub<TypeToMock>();
        }
    }

    [TestFixture]
    public abstract class context_spec<SystemUnderTest> {
        [SetUp]
        public void SetUp() {
            sut = UnderTheseConditions();
            BecauseOf();
        }

        [TearDown]
        public virtual void Cleanup() {}

        protected abstract SystemUnderTest UnderTheseConditions();

        protected abstract void BecauseOf();

        protected TypeToMock Dependency<TypeToMock>() {
            return MockRepository.GenerateMock<TypeToMock>();
        }

        protected TypeToMock Stub<TypeToMock>() {
            return MockRepository.GenerateStub<TypeToMock>();
        }

        protected SystemUnderTest sut { get; private set; }
    }
}