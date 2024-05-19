using VContainer;
using VContainer.Unity;

namespace SuikaLike
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IRandomValueProvider, UnityRandomValueProvider>(Lifetime.Singleton);
        }
    }
}
