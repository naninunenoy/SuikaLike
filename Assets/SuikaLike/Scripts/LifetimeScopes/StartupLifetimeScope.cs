using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SuikaLike.LifetimeScopes
{
    public class StartupLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"entry {nameof(StartupLifetimeScope)}#{GetHashCode():x8}#Configure");

            // タイトルへ移動
            if (Container.TryResolve(out IApplicationStateDispatcher dispatcher))
            {
                dispatcher.Dispatch(ApplicationState.Title);
            }
        }
    }
}
