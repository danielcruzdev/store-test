using AutoFixture;
using AutoFixture.AutoMoq;

namespace API.Store.Test.Helpers
{
    public static class AutoMoqFixtureFactory
    {
        public static IFixture CreateFixture()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize(new SupportMutableValueTypesCustomization());

            fixture?.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(behavior => fixture.Behaviors.Remove(behavior));
            fixture?.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture;
        }
    }
}
