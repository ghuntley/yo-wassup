using PCLMock;
using ReactiveUI;

namespace ReactiveSearch.UnitTests.ReactiveUI.Mocks
{
    public sealed class ScreenMock : MockBase<IScreen>, IScreen
    {
        public ScreenMock(MockBehavior behavior = MockBehavior.Strict)
            : base(behavior)
        {
            if (behavior == MockBehavior.Loose)
                ConfigureLooseBehavior();
        }

        public RoutingState Router => Apply(x => x.Router);

        private void ConfigureLooseBehavior()
        {
            When(x => x.Router)
                .Return(new RoutingState());
        }
    }
}