using Conventional;
using Xunit;

namespace Conventions.Opinions
{
    public class OpinionConventions : IClassFixture<BaseFixture>
    {
        public OpinionConventions(BaseFixture baseFixture)
        {
            _baseFixture = baseFixture;
        }

        private readonly BaseFixture _baseFixture;

        [Fact]
        public void AllPropertiesMustBeImmutable()
        {
            _baseFixture.AllAssemblies.MustConformTo(Convention.AllPropertiesMustBeImmutable);
        }

        [Fact]
        public void AllPropertiesMustBeInstantiatedDuringConstruction()
        {
            _baseFixture.AllAssemblies.MustConformTo(Convention.AllPropertiesMustBeAssignedDuringConstruction());
        }

        [Fact]
        public void AsyncMethodsNamesMustEndInAsync()
        {
            _baseFixture.AllAssemblies.MustConformTo(Convention.AsyncMethodsMustHaveAsyncSuffix);
        }

        [Fact]
        public void ClassesMustOnlyContainToDoOrNoteComments()
        {
            ThisSolution.MustConformTo(Convention.MustOnlyContainToDoAndNoteComments);
        }

        [Fact]
        public void CollectionPropertiesMustBeImmutable()
        {
            _baseFixture.AllAssemblies.MustConformTo(Convention.CollectionPropertiesMustBeImmutable);
        }
    }
}